using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //NorthwindContext newlesek de olur ama using daha performanslı
            //USing UDispossable pattern implementasyonu olarak geçer
            using (NorthwindContext context= new NorthwindContext()) //işi bitince direkt garbage collectere gidip kendini bellekten attırır. Newlemekten daha masraflı.
            {
                //git veri kaynağından benim bu gönderdiğim producta nesneyi eşleştir
                var addedEntity = context.Entry(entity);  
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); // 1. referansı yakalı, o aslında eklenelecek bir nesne ve ekle. 
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) 
            {
                //git veri kaynağından benim bu gönderdiğim producta nesneyi eşleştir
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges(); // 1. referansı yakalı, o aslında eklenelecek bir nesne ve ekle. 
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Product tablosuna yerleş ve filter yoksa productı listele
                return context.Set<Product>().SingleOrDefault(filter); // bu bir product döndürür
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null) //buradaki parametre bildiğimiz landa
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                //Product tablosuna yerleş ve filter yoksa productı listele
                return filter == null ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();  
            }
        }
    }
}

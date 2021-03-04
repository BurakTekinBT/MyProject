using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //NorthwindContext newlesek de olur ama using daha performanslı
            //USing UDispossable pattern implementasyonu olarak geçer
            using (TContext context = new TContext()) //işi bitince direkt garbage collectere gidip kendini bellekten attırır. Newlemekten daha masraflı.
            {//2.yol context.Producst.Add(product);
                //context.SaveChanges();


                //git veri kaynağından benim bu gönderdiğim producta nesneyi eşleştir
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); // 1. referansı yakalı, o aslında eklenelecek bir nesne ve ekle. 
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //2.yol
                //context.Products.Remove(context.Products.SingleOrDefault(p=> p.ProductId == product.ProductId);

                //context.SaveChanges();

                //git veri kaynağından benim bu gönderdiğim producta nesneyi eşleştir
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges(); // 1. referansı yakalı, o aslında eklenelecek bir nesne ve ekle. 
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                //Product tablosuna yerleş ve filter yoksa productı listele
                return context.Set<TEntity>().SingleOrDefault(filter); // bu bir product döndürür
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) //buradaki parametre bildiğimiz landa
        {
            using (TContext context = new TContext())
            {
                //Product tablosuna yerleş ve filter yoksa productı listele
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //2.yol
                //var productToUpdate = context.Products.SingleOrDefault/p=> p.ProductId == product.ProductId);
                //productToUpdate.ProductName = product.ProductName
                //context.SaveChanges();
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

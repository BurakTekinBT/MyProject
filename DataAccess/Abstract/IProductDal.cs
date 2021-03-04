using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>

    //interfacein operasyonları public olur kendisine ayrı public atamak lazım
    {
        //List<Product> GetAll();
        //// burada product'ı referanslamamız lazım Entitities'i biz kullanacağız DAL olarak biz entity'e bağımlıyız 
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);

        //List<Product> GetByCategory(int categoryId);
    }
}

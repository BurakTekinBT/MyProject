using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{ // arayüzden bir şeyler gönderiyoruz burada.
    public class ProductManager : IProcudtService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
            //iş kodları //bir iş sınıfı başka bir iş sınıfını newlemez
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal(); //ileriye dönük sıkıntı olur
            //Bu sayede sadece bellekte çalışır geliştirme tarafı sağlıklı olmaz
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <=max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        Product IProcudtService.GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

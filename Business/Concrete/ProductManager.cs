using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
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
    }
}

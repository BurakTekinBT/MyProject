using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        { //ürün eklenmeden önceki şart ve kurallar burada yaızlır.
            if (product.ProductName.Length < 2)
            {// magic strings stringier ayrı ayrı yazmak
                return new ErrorResult(Messages.ProductNameInvalid);
            }           
            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded) ;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
            //iş kodları //bir iş sınıfı başka bir iş sınıfını newlemez
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal(); //ileriye dönük sıkıntı olur
            //Bu sayede sadece bellekte çalışır geliştirme tarafı sağlıklı olmaz
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> ( _productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService //dış dünyaya servis edeceğimiz şeyler
    {
        IResult Add(Product product);
        IDataResult<List<Product>> GetAll();
        //List<Product> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<Product> GetById(int productId);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
    }


}

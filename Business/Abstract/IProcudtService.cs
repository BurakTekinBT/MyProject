using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProcudtService //dış dünyaya servis edeceğimiz şeyler
    {
        List<Product> GetAll();
        Product GetAllByCategoryId(int id);

        List<Product> GetByUnitPrice(decimal min, decimal max);
    }

    
}

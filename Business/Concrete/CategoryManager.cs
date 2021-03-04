using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{//iş kodları yazılır
     //bağlılığımızı azaltıyoruz //Constructer injection
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal; //interface üzerinde

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId); //select * from categories where categoryId =3
        }
    }
}

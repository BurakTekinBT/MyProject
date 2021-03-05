using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {//publicler pascal case, diğerler camel case
        public static string ProductAdded = "Ürün Eklendi.";

        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = " Bakım saati ";
        public static string ProductsListed = " Ürünler Listelendi" ; 
    }
}

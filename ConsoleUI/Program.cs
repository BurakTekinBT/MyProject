using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{ // Open Closed Principle
    class Program
    {

        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            foreach(var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName + " " + product.CategoryId);
            }

            foreach (var product in productManager.GetByUnitPrice(40,100) )
            {
                Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            }


        }
    }
}

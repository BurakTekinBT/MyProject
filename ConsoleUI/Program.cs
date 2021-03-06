﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{ // Open Closed Principle
    class Program
    {

        static void Main(string[] args)
        {
            //Data Tranformation Object DTO - 
            //IoC
            ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //foreach (var item in categoryManager.GetAll())
            //{
            //    Console.WriteLine(item.CategoryName);
            //}
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " " + product.CategoryName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
            

            //foreach (var product in productManager.GetAllByCategoryId(2))
            //{
            //    Console.WriteLine(product.ProductName + " " + product.CategoryId);
            //}

            //foreach (var product in productManager.GetByUnitPrice(40, 100))
            //{
            //    Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            //}
        }
    }
}

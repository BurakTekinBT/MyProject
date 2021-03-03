using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());



        }
    }
}

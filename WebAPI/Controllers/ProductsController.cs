using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]//bize nasıl ulaşsınlar
    [ApiController] //Attribute //bu class bir kontrollerdır ona göre yapılandır demek
    public class ProductsController : ControllerBase
    {
        //loose coupled gevşek bağlılık bir bağımlılık var ama soyuta bağımlılık
       //IoC  Containe -- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {//Dependency chain -- burada IproductService var ve product manager ve productdal'a bağımlı
            //çok fazla bağımlılık mevcut
            //IProductService productService = new ProductManager(new EFProductDal());

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok( result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productID)
        {
            var result = _productService.GetById(productID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product) //post requestlerde 
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
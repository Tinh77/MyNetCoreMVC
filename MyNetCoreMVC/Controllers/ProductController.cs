using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreMVC.Models;

namespace MyNetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult GetList()
        {
            
            return View(_context.Products.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (_context.Products.Count() == 0)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["message"] = "Create success";
            }

            return Redirect("GetList");
        }

        public IActionResult Edit(long id)
        {
           var product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Update(Product product)
        {
            var exisProduct = _context.Products.Find(product.id);
            if(exisProduct == null)
            {
                return NotFound();
            }
            exisProduct.name = product.name;
            exisProduct.price = product.price;
            _context.Products.Update(exisProduct);
            _context.SaveChanges();
            TempData["message"] = "Update success";
            return Redirect("GetList");
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Redirect("GetList");
        }
    }
}
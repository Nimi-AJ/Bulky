using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;


        public CategoryController(ApplicationDbContext db)
        {
            dbContext = db;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = dbContext.Categories;
            Console.WriteLine("2here");
            return View(categoriesList);
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            Console.WriteLine("1here");

            return View();
        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot match the name");
            }
           if(ModelState.IsValid)
            {
                dbContext.Categories.Add(obj);
                dbContext.SaveChanges();
                TempData["success"] = "Catgeory created successfully";
                return RedirectToAction("Index");

            }
            else
            {
                Console.WriteLine("invalid");
            }
            Console.WriteLine("5here");
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            Console.WriteLine("1here");
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryObj = dbContext.Categories.Find(id);
            return View(categoryObj);
        }

        // PUT: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot match the name");
            }
           if(ModelState.IsValid)
            {
                dbContext.Categories.Update(obj);
                dbContext.SaveChanges();
                TempData["success"] = "Catgeory updated successfully";
                return RedirectToAction("Index");

            }
            else
            {
                Console.WriteLine("invalid");
            }
            Console.WriteLine("5here");
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            Console.WriteLine("delete1");
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryObj = dbContext.Categories.Find(id);
            return View(categoryObj);
        }

        // DELETE: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            
            Console.WriteLine("Delete2");
            dbContext.Categories.Remove(obj);
            dbContext.SaveChanges();
            TempData["success"] = "Catgeory deleted successfully";
            Console.WriteLine("Delete2");
            return RedirectToAction("Index");

        }

    }

}


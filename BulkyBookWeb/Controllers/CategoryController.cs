using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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

            var categoryObj = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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

            var categoryObj = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
            return View(categoryObj);
        }

        // DELETE: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            
            Console.WriteLine("Delete2");
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Catgeory deleted successfully";
            Console.WriteLine("Delete2");
            return RedirectToAction("Index");

        }

    }

}


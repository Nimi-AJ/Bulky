using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
          
            return View();
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
        public IActionResult Create(CoverType obj)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Display Order cannot match the name");
            //}
           if(ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type created successfully";
                return RedirectToAction("Index");

            }
            else
            {
                Console.WriteLine("invalid");
            }
            Console.WriteLine("5here");
            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            //Product product = new();
            //Console.WriteLine("1here");
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString()
            //    }

            //    );
            //IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString()
            //    }

            //    );

            //ViewBag.CategoryList = CategoryList;
            //ViewBag.CoverTypeList = CoverTypeList;

            if (id == null || id == 0)
            {
                return View(productVM);
            } else
            {

            }

            var coverTypeObj = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);
            return View(productVM);
        }

        // PUT: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Display Order cannot match the name");
            //}
           if(ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    using(var fileStreams = new FileStream(Path.Combine(uploads, fileName+extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl = @"\images\products\" + fileName + extension;
                }

                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                if(obj.Product.Id == 0)
                {
                TempData["success"] = "Product created successfully";

                }
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

            var coverTypeObj = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);
            return View(coverTypeObj);
        }

        // DELETE: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CoverType obj)
        {
            
            Console.WriteLine("Delete2");
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully";
            Console.WriteLine("Delete2");
            return RedirectToAction("Index");

        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll();

            return Json(new { data = productList });
        }
        #endregion


    }

}


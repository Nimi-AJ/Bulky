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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
          
            return View();
        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Display Order cannot match the name");
            //}
           if(ModelState.IsValid)
            {
                     
                if(obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company created successfully";

                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company updated successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            else
            {
                Console.WriteLine("invalid");
            }
            Console.WriteLine("5here");
            return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();

            return Json(new { data = companyList });
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCompany(int id)
        {
            //if(id == null || id == 0)
            //{
                                
            //}

            Company obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
         
            return Json(new { success = true, message = "Delete successful" });

        }
        #endregion


    }

}


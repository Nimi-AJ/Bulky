﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.ViewModels;

namespace BulkyBookWeb.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IUnitOfWork _unitOfWork; 

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProps: "Category,CoverType");
        return View(productList);
    }

    public IActionResult Details(int id)
    {
        ShoppingCart cartObj = new()
        {
            Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProps: "Category,CoverType"),
            Count = 1
        };
        
        
        return View(cartObj);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


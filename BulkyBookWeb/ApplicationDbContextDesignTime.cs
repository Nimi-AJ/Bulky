//using System;
//using BulkyBook.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using BulkyBook.DataAccess;

//namespace BulkyBook.BulkBookWeb
//{
//    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//                .AddJsonFile("appsettings.json")
//                .Build();
//            Console.WriteLine("tt");
//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

//            return new ApplicationDbContext(optionsBuilder.Options);
//        }
//    }
//}


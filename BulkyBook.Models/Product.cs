﻿
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BulkyBook.Models
{
	public class Product
	{
		//public Category()
		//{
		//}

		[Key]
		public int Id  { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

		//[Required]
		//public string Name { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price100  { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        public int CoverTypeId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ValidateNever]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ValidateNever]
        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }
    }
}


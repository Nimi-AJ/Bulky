using System;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
	public class CoverType
	{
		public CoverType()
		{
		}

		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}


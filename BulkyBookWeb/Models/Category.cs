
using System;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
	public class Category
	{
		//public Category()
		//{
		//}

		[Key]
		public int Id  { get; set; }
		public int DisplayOrder { get; set; }

		public DateTime CreatedDateTime { get; set; } = DateTime.Now;

		[Required]
		public string Name { get; set; }

	}
}


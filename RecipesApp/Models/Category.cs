using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Models
{
	public class Category
	{
		public Category()
		{
		}

		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		public virtual List<Recipe> Recipes { get; set; }
	}
}

using System;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Models
{
	public class Recipe
	{
		public Recipe()
		{
			CreatedDate = DateTime.Now;
		}

		public int RecipeId { get; set; }

		[Required(ErrorMessage = "Please enter title of your recipe")]
		public string Name { get; set; }

		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }

		[MaxLength(1500)]
		[DataType(DataType.MultilineText)]
		public string Ingredients { get; set; }

		[MaxLength(1500)]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Display(Name = "Cooking Time")]
		public int CookingTime { get; set; }

		public string CookingAdvice { get; set; }

		public string Image { get; set; }

		[ScaffoldColumn(false)]
		[DataType(DataType.Date)]
		public DateTime CreatedDate { get; set; }

		public int? Ratings { get; set; }

		public bool IsSalable { get; set; }

		public int Stock { get; set; }

		public decimal Price { get; set; }
	}
}

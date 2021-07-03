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

		[Display(Name = "Category Name")]
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

		[Display(Name = "Cooking Advice")]
		public string CookingAdvice { get; set; }

		public string Image { get; set; }

		[ScaffoldColumn(false)]
		[DataType(DataType.Date)]
		public DateTime CreatedDate { get; set; }

		[Display(Name = "Is Salable?")]
		public bool IsSalable { get; set; }

		public decimal? Price { get; set; }

		public string RecipeUserId { get; set; }

		public virtual RecipeUser RecipeUser { get; set; }
	}
}

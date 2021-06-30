using System;
namespace RecipesApp.Models
{
	public class Recipe
	{
		public Recipe()
		{
		}

		public int RecipeId { get; set; }

		public string Name { get; set; }

		public string Category { get; set; }

		public string Ingredients { get; set; }

		public string Description { get; set; }

		public string CookingAdvic { get; set; }

		public string Images { get; set; } // ?

		public DateTime CreatedDate { get; set; }

		public bool IsSalable { get; set; }

		public int Ratings { get; set; }

		public int Stock { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }
	}
}

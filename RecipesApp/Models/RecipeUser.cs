using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RecipesApp.Models
{
	public class RecipeUser : IdentityUser
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public virtual List<Recipe> Recipes { get; set; }
	}
}

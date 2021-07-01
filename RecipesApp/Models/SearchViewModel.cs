using System;
using System.Collections.Generic;

namespace RecipesApp.Models
{
	public class SearchViewModel
	{
		public SearchViewModel()
		{
		}

		public string SearchText { get; set; }

		public List<Recipe> Result { get; set; }

	}
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Data;

namespace RecipesApp.ViewComponents
{
	public class CategoryMenuViewComponent : ViewComponent
	{
		private readonly ApplicationDbContext dbContext;

		public CategoryMenuViewComponent(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await dbContext.Categories.ToListAsync();
			return View(items);
		}

	}
}

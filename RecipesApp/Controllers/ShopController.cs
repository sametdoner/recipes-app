using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesApp.Controllers
{
	public class ShopController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ShopController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> List()
		{
			return View(await _context.Recipes.Where(t => t.IsSalable).ToListAsync());
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Data;
using RecipesApp.Models;

namespace RecipesApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RecipeUser> _userManager;

        public RecipesController(ApplicationDbContext context, UserManager<RecipeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            List<Recipe> recipes;
            if(User.Identity.IsAuthenticated)
			{
                var recipeUser = await _userManager.GetUserAsync(HttpContext.User);
                var query = _context.Recipes.Include(t => t.Category).Where(t => t.RecipeUserId == recipeUser.Id);

                recipes = await query.ToListAsync();
            }
            else
			{
                recipes = new List<Recipe>();
			}
            
            return View(recipes);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        [Authorize]
        public IActionResult Create()
        {
			ViewBag.CategorySelectList = new SelectList(_context.Categories, "Id", "Name");
			return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("RecipeId,Name,CategoryId,Ingredients,Description,CookingAdvice,Image,Ratings,IsSalable,Stock,Price")] Recipe recipe)
        {
            var recipeUser = await _userManager.GetUserAsync(HttpContext.User);
            recipe.RecipeUserId = recipeUser.Id;

            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", recipe.CategoryId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recipe = await _context.Recipes.FindAsync(id);
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (recipe.RecipeUserId != currentUser.Id)
            {
                return Unauthorized();
            }

            if (recipe == null)
            {
                return NotFound();
            }
            ViewBag.CategorySelectList = new SelectList(_context.Categories, "Id", "Name");
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Name,CategoryId,Ingredients,Description,CookingAdvice,Image,Ratings,IsSalable,Stock,Price, RecipeUserId")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldRecipe = await _context.Recipes.FindAsync(id);
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    if(oldRecipe.RecipeUserId == currentUser.Id)
					{
                        return Unauthorized();
					}
                    oldRecipe.Name = recipe.Name;
                    oldRecipe.Ingredients = recipe.Ingredients;
                    oldRecipe.IsSalable = recipe.IsSalable;
                    oldRecipe.Stock = recipe.Stock;
                    oldRecipe.CookingAdvice = recipe.CookingAdvice;
                    oldRecipe.Description = recipe.Description;
                    oldRecipe.Price = recipe.Price;
                    oldRecipe.Ratings = recipe.Ratings;

                    _context.Update(oldRecipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", recipe.CategoryId);
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (recipe.RecipeUserId != currentUser.Id)
            {
                return Unauthorized();
            }

            if (recipe == null)
            {
                return NotFound();
            }
            ViewBag.CategorySelectList = new SelectList(_context.Categories, "Id", "Name");
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}

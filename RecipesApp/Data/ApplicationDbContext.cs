using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Models;

namespace RecipesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<RecipeUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}

using Cookbook.Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace Cookbook_Infrastructure
{
    public class RecipeContext : DbContext

    {
        public RecipeContext(DbContextOptions<RecipeContext> opt) : base(opt)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
    }
}


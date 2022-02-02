using Cookbook.Domain;
using Cookbook_Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Service
{

    /// <summary>
    /// Default implementation of IRecipeService
    /// </summary>
    public class RecipeService : IRecipeService
    {
        private readonly RecipeContext _recipeContext;

        public RecipeService(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;

        }


        public async Task AddRecipe(Recipe recipe)
        {

            await _recipeContext.Recipes.AddAsync(recipe);
            await _recipeContext.SaveChangesAsync();
        }


        public async Task<List<Recipe>> GetAll()
        {
            return await _recipeContext.Recipes.ToListAsync();
        }


        public async Task<Recipe> GetRecipe(int id)
        {
            return await _recipeContext.Recipes.FindAsync(id);
        }


        public async Task UpdateRecipe(string name, string description)
        {
            var recipeData = _recipeContext.Recipes.ToList().Find(_ => _.Name.Equals(name));
            recipeData.Description = description;
            await _recipeContext.SaveChangesAsync();

        }


        public async Task DeleteAll()
        {
            _recipeContext.Recipes.RemoveRange(_recipeContext.Recipes);
            await _recipeContext.SaveChangesAsync();
        }
    }
}


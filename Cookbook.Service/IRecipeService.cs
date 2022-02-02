using Cookbook.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Service
{
    public interface IRecipeService
    {
        /// <summary>
        /// Delete all recipe from the database
        /// </summary>
        /// <returns></returns>
        Task DeleteAll();

        /// <summary>
        /// Add a recipe to the database
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task AddRecipe(Recipe recipe);

        /// <summary>
        /// Returns a recipe using the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Recipe> GetRecipe(int id);

        /// <summary>
        /// Returns all recipe from the database
        /// </summary>
        /// <returns></returns>
        Task<List<Recipe>> GetAll();
   
        /// <summary>
        /// Update a recipe depending on its name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        Task UpdateRecipe(string name, string description);

    }
}


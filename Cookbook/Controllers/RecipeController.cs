using Cookbook.Domain;
using Cookbook.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cookbook.Application.Controllers
{
    /// <summary>
    /// Controller responsable to implement all endpoints related to Recipe API
    /// </summary>
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }


        /// <summary>
        /// Add a recipe to the database
        /// </summary>
        /// <param name="recipe">Recipe object</param>
        /// <returns></returns>
        [HttpPost("recipe/")]
        public async Task<IActionResult> CreateRecipeasync([FromBody] Recipe recipe)
        {
            try
            {
                await _recipeService.AddRecipe(recipe);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Return certain recipe depending on the ID
        /// </summary>
        /// <param name="id">Recipe ID</param>
        /// <returns></returns>
        [HttpGet("recipe/{id}")]
        public async Task<IActionResult> ShowIdRecipe(int id)
        {
            try
            {
                return Ok(await _recipeService.GetRecipe(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Delete all recipe from the database
        /// </summary>
        /// <returns></returns>
        [HttpDelete("recipe/")]
        public async Task<IActionResult> DeleteRecipe()
        {
            try
            {
                await _recipeService.DeleteAll();
                return Ok("All recipes were deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Update recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>

        [HttpPut("recipe/")]
        public async Task<IActionResult> UpdateRecipe([FromBody] Recipe recipe)
        {
            try
            {
                await _recipeService.UpdateRecipe(recipe.Name, recipe.Description);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }


        /// <summary>
        /// Return all Recipe from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("recipe/")]

        public async Task<IActionResult> ShowAllRecipes()
        {
            try
            {
                return Ok(await _recipeService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cookbook.Domain.RecipeCategoryType;

namespace Cookbook.Domain
{
    /// <summary>
    /// Recipe model class
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Recipe ID - Primary Key on the database
        /// </summary>
        [Key]
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public int Id { get; set; }

        /// <summary>
        /// Recipe Titles
        /// </summary>
        [Required(ErrorMessage = "O campo name é obrigatório")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the Recipe
        /// </summary>
        [Required(ErrorMessage = "O campo Description é obrigatório")]
        public string Description { get; set; }

        public RecipeCategoryType Category { get; set; }

        public List<Recipe> Recipes = new List<Recipe>();

        /// <summary>
        /// Builder that implements the parameters.
        /// </summary>
        public Recipe(string description, RecipeCategoryType category, string name, int id)
        {
            Description = description;
            Category = category;
            Name = name;
            Id = id;
            Recipes = new List<Recipe>();

        }
    }
}
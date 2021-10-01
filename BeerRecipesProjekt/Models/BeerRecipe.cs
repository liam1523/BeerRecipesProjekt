using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeerRecipesProjekt.Models
{
    public class BeerRecipe
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public string tagline { get; set; }
        public string description { get; set; }

        public string ingredients { get; set; }
        public string food_pairing { get; set; }

    }

}

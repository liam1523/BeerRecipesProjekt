using BeerRecipesProjekt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerRecipesProjekt.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BeerRecipesProjektContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BeerRecipesProjektContext>>()))
            {
                if (context.BeerRecipe.Any())
                {
                    return;

                }

                List<JsonData> data = JsonData.GetJsonData("https://api.punkapi.com/v2/beers");
                List<BeerRecipe> beerRecipes = new List<BeerRecipe>();
                foreach (var jsonData in data)
                {
                    string foodpairs = string.Join(", ", jsonData.food_pairing);
                    List<string> maltingredients = new List<string>();
                    List<string> hopsingredients = new List<string>();
                    foreach (var malt in jsonData.ingredients.malt)
                    {
                        maltingredients.Add(malt.name);
                    }
                    //foreach (var hops in jsonData.ingredients.hops)
                    //{
                    //    hopsingredients.Add(hops.name);
                    //}
                    string maltIngre = string.Join(", ", maltingredients.ToArray());
                    //string hopsIngre = string.Join(", ", hopsingredients.ToArray());
                    beerRecipes.Add(new BeerRecipe { 
                        name = jsonData.name, 
                        tagline = jsonData.tagline, 
                        description = jsonData.description, 
                        food_pairing = foodpairs, 
                        ingredients = maltIngre
                    });

                }
                context.BeerRecipe.AddRange(beerRecipes);
                context.SaveChanges();

            }

        }

    }

}

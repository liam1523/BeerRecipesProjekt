using BeerRecipesProjekt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerRecipesAPI
{
    public static class GetDbData
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


            }

        }

    }

}

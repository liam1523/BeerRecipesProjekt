using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeerRecipesProjekt.Models;

namespace BeerRecipeAPI.Data
{
    public class BeerRecipeAPIContext : DbContext
    {
        public BeerRecipeAPIContext (DbContextOptions<BeerRecipeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BeerRecipesProjekt.Models.BeerRecipe> BeerRecipe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeerRecipesProjekt.Models;

namespace BeerRecipesProjekt.Data
{
    public class BeerRecipesProjektContext : DbContext
    {
        public BeerRecipesProjektContext (DbContextOptions<BeerRecipesProjektContext> options)
            : base(options)
        {
        }

        public DbSet<BeerRecipesProjekt.Models.BeerRecipe> BeerRecipe { get; set; }
    }
}

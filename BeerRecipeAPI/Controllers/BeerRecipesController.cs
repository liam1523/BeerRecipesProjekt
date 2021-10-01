using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeerRecipeAPI.Data;
using BeerRecipesProjekt.Models;

namespace BeerRecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerRecipesController : ControllerBase
    {
        private readonly BeerRecipeAPIContext _context;

        public BeerRecipesController(BeerRecipeAPIContext context)
        {
            _context = context;
        }

        // GET: api/BeerRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerRecipe>>> GetBeerRecipe()
        {
            return await _context.BeerRecipe.ToListAsync();
        }

        // GET: api/BeerRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerRecipe>> GetBeerRecipe(int id)
        {
            var beerRecipe = await _context.BeerRecipe.FindAsync(id);

            if (beerRecipe == null)
            {
                return NotFound();
            }

            return beerRecipe;
        }

        // PUT: api/BeerRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBeerRecipe(int id, BeerRecipe beerRecipe)
        //{
        //    if (id != beerRecipe.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(beerRecipe).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BeerRecipeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/BeerRecipes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<BeerRecipe>> PostBeerRecipe(BeerRecipe beerRecipe)
        //{
        //    _context.BeerRecipe.Add(beerRecipe);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetBeerRecipe", new { id = beerRecipe.id }, beerRecipe);
        //}

        //// DELETE: api/BeerRecipes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBeerRecipe(int id)
        //{
        //    var beerRecipe = await _context.BeerRecipe.FindAsync(id);
        //    if (beerRecipe == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.BeerRecipe.Remove(beerRecipe);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool BeerRecipeExists(int id)
        {
            return _context.BeerRecipe.Any(e => e.id == id);
        }
    }
}

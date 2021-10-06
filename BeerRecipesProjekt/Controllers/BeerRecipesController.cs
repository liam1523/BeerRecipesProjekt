using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeerRecipesProjekt.Data;
using BeerRecipesProjekt.Models;

namespace BeerRecipesProjekt.Controllers
{
    public class BeerRecipesController : Controller
    {
        private readonly BeerRecipesProjektContext _context;

        public BeerRecipesController(BeerRecipesProjektContext context)
        {
            _context = context;

        }

        // GET: BeerRecipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BeerRecipe.ToListAsync());

        }

        // GET: BeerRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerRecipe = await _context.BeerRecipe
                .FirstOrDefaultAsync(m => m.id == id);
            if (beerRecipe == null)
            {
                return NotFound();
            }

            return View(beerRecipe);
        }

        // GET: BeerRecipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeerRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,tagline,description,ingredients,food_pairing")] BeerRecipe beerRecipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beerRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beerRecipe);
        }

        // GET: BeerRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerRecipe = await _context.BeerRecipe.FindAsync(id);
            if (beerRecipe == null)
            {
                return NotFound();
            }
            return View(beerRecipe);
        }

        // POST: BeerRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,tagline,description,ingredients,food_pairing")] BeerRecipe beerRecipe)
        {
            if (id != beerRecipe.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beerRecipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerRecipeExists(beerRecipe.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beerRecipe);
        }

        // GET: BeerRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerRecipe = await _context.BeerRecipe
                .FirstOrDefaultAsync(m => m.id == id);
            if (beerRecipe == null)
            {
                return NotFound();
            }

            return View(beerRecipe);
        }

        // POST: BeerRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beerRecipe = await _context.BeerRecipe.FindAsync(id);
            _context.BeerRecipe.Remove(beerRecipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerRecipeExists(int id)
        {
            return _context.BeerRecipe.Any(e => e.id == id);
        }

    }

}

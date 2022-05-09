#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaAplikacjaWebowa.Models;

namespace WypozyczalniaAplikacjaWebowa.Pages.PojazdyF
{
    public class EditModel : PageModel
    {
        private readonly WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext _context;

        public EditModel(WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pojazd Pojazd { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pojazd = await _context.Pojazds
                .Include(p => p.IdKategoriiPojazduNavigation).FirstOrDefaultAsync(m => m.IdPojazdu == id);

            if (Pojazd == null)
            {
                return NotFound();
            }
           ViewData["IdKategoriiPojazdu"] = new SelectList(_context.Kategoria, "IdKategorii", "IdKategorii");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pojazd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PojazdExists(Pojazd.IdPojazdu))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PojazdExists(int id)
        {
            return _context.Pojazds.Any(e => e.IdPojazdu == id);
        }
    }
}

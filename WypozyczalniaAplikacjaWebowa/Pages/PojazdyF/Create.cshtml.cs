#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WypozyczalniaAplikacjaWebowa.Models;

namespace WypozyczalniaAplikacjaWebowa.Pages.PojazdyF
{
    public class CreateModel : PageModel
    {
        private readonly WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext _context;

        public CreateModel(WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdKategoriiPojazdu"] = new SelectList(_context.Kategoria, "IdKategorii", "IdKategorii");
            return Page();
        }

        [BindProperty]
        public Pojazd Pojazd { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Pojazds.Add(Pojazd);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

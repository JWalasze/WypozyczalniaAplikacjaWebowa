#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaAplikacjaWebowa.Models;

namespace WypozyczalniaAplikacjaWebowa.Pages.KategoriaF
{
    public class DeleteModel : PageModel
    {
        private readonly WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext _context;

        public DeleteModel(WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kategorium Kategorium { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kategorium = await _context.Kategoria.FirstOrDefaultAsync(m => m.IdKategorii == id);

            if (Kategorium == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kategorium = await _context.Kategoria.FindAsync(id);

            if (Kategorium != null)
            {
                _context.Kategoria.Remove(Kategorium);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

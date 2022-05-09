#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaAplikacjaWebowa.Models;

namespace WypozyczalniaAplikacjaWebowa.Pages.PojazdyF
{
    public class DetailsModel : PageModel
    {
        private readonly WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext _context;

        public DetailsModel(WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}

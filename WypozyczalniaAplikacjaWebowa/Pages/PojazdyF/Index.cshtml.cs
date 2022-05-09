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
    public class IndexModel : PageModel
    {
        private readonly WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext _context;

        public IndexModel(WypozyczalniaAplikacjaWebowa.Models.MiejskaWypozyczalniaDbContext context)
        {
            _context = context;
        }

        public IList<Pojazd> Pojazd { get;set; }

        public async Task OnGetAsync()
        {
            Pojazd = await _context.Pojazds
                .Include(p => p.IdKategoriiPojazduNavigation).ToListAsync();
        }
    }
}

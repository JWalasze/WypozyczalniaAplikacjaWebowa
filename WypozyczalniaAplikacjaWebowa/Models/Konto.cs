using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class Konto
    {
        public string NazwaUzytkownika { get; set; } = null!;
        public string HasloUzytkownika { get; set; } = null!;
        public decimal StanKonta { get; set; }

        public virtual Uzytkownicy Uzytkownicy { get; set; } = null!;
    }
}

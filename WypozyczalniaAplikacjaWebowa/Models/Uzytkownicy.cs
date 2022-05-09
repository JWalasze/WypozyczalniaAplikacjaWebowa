using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class Uzytkownicy
    {
        public Uzytkownicy()
        {
            Wypozyczenia = new HashSet<Wypozyczenium>();
        }

        public string NazwaUzytkownika { get; set; } = null!;
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NumerTelefonu { get; set; } = null!;
        public string KodPocztowy { get; set; } = null!;
        public string MiastoZamieszkania { get; set; } = null!;

        public virtual Konto NazwaUzytkownikaNavigation { get; set; } = null!;
        public virtual HistoriaUzytkownika HistoriaUzytkownika { get; set; } = null!;
        public virtual ICollection<Wypozyczenium> Wypozyczenia { get; set; }
    }
}

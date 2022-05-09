using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class MiejskaWypozyczalniaDbContext : DbContext
    {
        public MiejskaWypozyczalniaDbContext()
        {
        }

        public MiejskaWypozyczalniaDbContext(DbContextOptions<MiejskaWypozyczalniaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HistoriaUzytkownika> HistoriaUzytkownikas { get; set; } = null!;
        public virtual DbSet<HistoriaWypozyczen> HistoriaWypozyczens { get; set; } = null!;
        public virtual DbSet<Kategorium> Kategoria { get; set; } = null!;
        public virtual DbSet<Konto> Kontos { get; set; } = null!;
        public virtual DbSet<Mapa> Mapas { get; set; } = null!;
        public virtual DbSet<Ofertum> Oferta { get; set; } = null!;
        public virtual DbSet<Pojazd> Pojazds { get; set; } = null!;
        public virtual DbSet<Uzytkownicy> Uzytkownicies { get; set; } = null!;
        public virtual DbSet<Wypozyczenium> Wypozyczenia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D7DV02B\\SQLEXPRESS;Initial Catalog=WypozyczalniaDb;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoriaUzytkownika>(entity =>
            {
                entity.HasKey(e => e.NazwaUzytkownikaHistoria)
                    .HasName("PK__Historia__21D5077586E936AE");

                entity.ToTable("HistoriaUzytkownika");

                entity.Property(e => e.NazwaUzytkownikaHistoria)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nazwa_uzytkownika_historia");

                entity.Property(e => e.IloscWykonanychPrzejazdow).HasColumnName("ilosc_wykonanych_przejazdow");

                entity.Property(e => e.LacznaIloscPrzejechanychKm).HasColumnName("laczna_ilosc_przejechanych_km");

                entity.Property(e => e.LacznaKwotaWydanaNaWypozyczenia)
                    .HasColumnType("money")
                    .HasColumnName("laczna_kwota_wydana_na_wypozyczenia")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LacznyCzasWypozyczaniaSprzetu).HasColumnName("laczny_czas_wypozyczania_sprzetu");

                entity.HasOne(d => d.NazwaUzytkownikaHistoriaNavigation)
                    .WithOne(p => p.HistoriaUzytkownika)
                    .HasForeignKey<HistoriaUzytkownika>(d => d.NazwaUzytkownikaHistoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nazwa_uzytkownika_historiaFK");
            });

            modelBuilder.Entity<HistoriaWypozyczen>(entity =>
            {
                entity.HasKey(e => e.IdWypozyczenia)
                    .HasName("PK__Historia__7C4F36AB7790286B");

                entity.ToTable("HistoriaWypozyczen");

                entity.Property(e => e.IdWypozyczenia)
                    .ValueGeneratedNever()
                    .HasColumnName("id_wypozyczenia_");

                entity.Property(e => e.CzasTrwaniaWypozyczenia).HasColumnName("czas_trwania_wypozyczenia");

                entity.Property(e => e.CzyPrzejazdOplacony).HasColumnName("czy_przejazd_oplacony");

                entity.Property(e => e.DataRozpoczeciaWypozyczenia).HasColumnName("data_rozpoczecia_wypozyczenia");

                entity.Property(e => e.DataZakonczeniaWypozyczenia).HasColumnName("data_zakonczenia_wypozyczenia");

                entity.Property(e => e.KosztPrzejazdu)
                    .HasColumnType("money")
                    .HasColumnName("koszt_przejazdu");

                entity.Property(e => e.PrzejechanyDystans).HasColumnName("przejechany_dystans");

                entity.HasOne(d => d.IdWypozyczeniaNavigation)
                    .WithOne(p => p.HistoriaWypozyczen)
                    .HasForeignKey<HistoriaWypozyczen>(d => d.IdWypozyczenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_wypozyczenia_FK");
            });

            modelBuilder.Entity<Kategorium>(entity =>
            {
                entity.HasKey(e => e.IdKategorii)
                    .HasName("PK__Kategori__EB93B733464A7D6B");

                entity.HasIndex(e => e.NazwaKategorii, "AK_nazwa_kategorii")
                    .IsUnique();

                entity.Property(e => e.IdKategorii).HasColumnName("id_kategorii");

                entity.Property(e => e.NazwaKategorii)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nazwa_kategorii");
            });

            modelBuilder.Entity<Konto>(entity =>
            {
                entity.HasKey(e => e.NazwaUzytkownika)
                    .HasName("PK__Konto__4543FBBFD1AF15ED");

                entity.ToTable("Konto");

                entity.Property(e => e.NazwaUzytkownika)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nazwa_uzytkownika");

                entity.Property(e => e.HasloUzytkownika)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("haslo_Uzytkownika");

                entity.Property(e => e.StanKonta)
                    .HasColumnType("money")
                    .HasColumnName("stan_konta");
            });

            modelBuilder.Entity<Mapa>(entity =>
            {
                entity.HasKey(e => e.IdPojazduWMiescie)
                    .HasName("PK__Mapa__770D1A169E254040");

                entity.ToTable("Mapa");

                entity.Property(e => e.IdPojazduWMiescie)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pojazdu_w_miescie");

                entity.Property(e => e.LokalizacjaGpsPojazdu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("lokalizacja_GPS_pojazdu");

                entity.Property(e => e.Miasto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("miasto");

                entity.Property(e => e.StatusPojazdu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("status_pojazdu")
                    .HasDefaultValueSql("('dostepny')");

                entity.HasOne(d => d.IdPojazduWMiescieNavigation)
                    .WithOne(p => p.Mapa)
                    .HasForeignKey<Mapa>(d => d.IdPojazduWMiescie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_pojazdu_FK");
            });

            modelBuilder.Entity<Ofertum>(entity =>
            {
                entity.HasKey(e => e.IdOfertyPrzejazdu)
                    .HasName("PK__Oferta__096F8416BD084879");

                entity.HasIndex(e => e.CzasPrzejazdu, "UQ__Oferta__8525D084552CA9E8")
                    .IsUnique();

                entity.Property(e => e.IdOfertyPrzejazdu).HasColumnName("id_oferty_przejazdu");

                entity.Property(e => e.CzasPrzejazdu).HasColumnName("czas_przejazdu");

                entity.Property(e => e.KosztPrzejazdu)
                    .HasColumnType("money")
                    .HasColumnName("koszt_przejazdu");
            });

            modelBuilder.Entity<Pojazd>(entity =>
            {
                entity.HasKey(e => e.IdPojazdu)
                    .HasName("PK__Pojazd__536E1FC5AE13B01A");

                entity.ToTable("Pojazd");

                entity.Property(e => e.IdPojazdu)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pojazdu");

                entity.Property(e => e.IdKategoriiPojazdu).HasColumnName("id_kategorii_pojazdu");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status_")
                    .HasDefaultValueSql("('sprawny')");

                entity.Property(e => e.Usterki)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usterki")
                    .HasDefaultValueSql("('brak')");

                entity.HasOne(d => d.IdKategoriiPojazduNavigation)
                    .WithMany(p => p.Pojazds)
                    .HasForeignKey(d => d.IdKategoriiPojazdu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_kategorii");
            });

            modelBuilder.Entity<Uzytkownicy>(entity =>
            {
                entity.HasKey(e => e.NazwaUzytkownika)
                    .HasName("PK__Uzytkown__9CED9CB154CC4451");

                entity.ToTable("Uzytkownicy");

                entity.Property(e => e.NazwaUzytkownika)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nazwa_uzytkownika_");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Imie)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("kod_pocztowy")
                    .IsFixedLength();

                entity.Property(e => e.MiastoZamieszkania)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("miasto_zamieszkania");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.NumerTelefonu)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("numer_telefonu")
                    .IsFixedLength();

                entity.HasOne(d => d.NazwaUzytkownikaNavigation)
                    .WithOne(p => p.Uzytkownicy)
                    .HasForeignKey<Uzytkownicy>(d => d.NazwaUzytkownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nazwa_uzytkownika_uzytkownicyFK");
            });

            modelBuilder.Entity<Wypozyczenium>(entity =>
            {
                entity.HasKey(e => e.IdWypozyczenia)
                    .HasName("PK__Wypozycz__B61B2CF71C3A0D9E");

                entity.HasIndex(e => e.IdPojazduWypozyczenia, "UQ__Wypozycz__7D371BFF4FF31C39")
                    .IsUnique();

                entity.Property(e => e.IdWypozyczenia).HasColumnName("id_wypozyczenia");

                entity.Property(e => e.IdOfertyPrzejazdu).HasColumnName("id_oferty_przejazdu_");

                entity.Property(e => e.IdPojazduWypozyczenia).HasColumnName("id_pojazdu_wypozyczenia");

                entity.Property(e => e.NazwaUzytkownikaWypozyczenia)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nazwa_uzytkownika_wypozyczenia");

                entity.Property(e => e.StatusWypozyczenia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status_wypozyczenia");

                entity.HasOne(d => d.IdOfertyPrzejazduNavigation)
                    .WithMany(p => p.Wypozyczenia)
                    .HasForeignKey(d => d.IdOfertyPrzejazdu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oferta_przejazdu_FK");

                entity.HasOne(d => d.IdPojazduWypozyczeniaNavigation)
                    .WithOne(p => p.Wypozyczenium)
                    .HasForeignKey<Wypozyczenium>(d => d.IdPojazduWypozyczenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_pojazdu_wypozyczenia_FK");

                entity.HasOne(d => d.NazwaUzytkownikaWypozyczeniaNavigation)
                    .WithMany(p => p.Wypozyczenia)
                    .HasForeignKey(d => d.NazwaUzytkownikaWypozyczenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nazwa_uzytkownika_wypozyczenia_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

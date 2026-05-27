using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBLayer;
using VarazdinTourManager.Models;

namespace VarazdinTourManager.Repositories
{
    public class Repozitorij
    {

        public Zaposlenik AutenticirajZaposlenika(string korIme, string korLozinka)
        {
            Zaposlenik zaposlenik = null;
            string sql = $"SELECT * FROM Zaposlenik WHERE KorIme='{korIme}' AND KorLozinka='{korLozinka}'";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            if (reader.HasRows)
            {
                reader.Read();
                zaposlenik = KreirajZaposlenika(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return zaposlenik;
        }

        private Zaposlenik KreirajZaposlenika(SqlDataReader reader)
        {
            return new Zaposlenik
            {
                IdKorisnik = Convert.ToInt32(reader["IdKorisnik"]),
                Ime = reader["Ime"].ToString(),
                Prezime = reader["Prezime"].ToString(),
                KorIme = reader["KorIme"].ToString(),
                KorLozinka = reader["KorLozinka"].ToString(),
                Uloga = reader["Uloga"].ToString()
            };
        }

        public List<Tura> DohvatiTure()
        {
            List<Tura> ture = new List<Tura>();
            string sql = "SELECT * FROM Tura";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                ture.Add(KreirajTuru(reader));
            }

            reader.Close();
            DB.CloseConnection();
            return ture;
        }

        public List<Tura> PretraziTure(string pojam)
        {
            List<Tura> ture = new List<Tura>();
            string sql = $"SELECT * FROM Tura WHERE NazivTure LIKE '%{pojam}%' OR Lokacija LIKE '%{pojam}%'";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                ture.Add(KreirajTuru(reader));
            }

            reader.Close();
            DB.CloseConnection();
            return ture;
        }

        public Tura DohvatiTuru(int idTura)
        {
            Tura tura = null;
            string sql = $"SELECT * FROM Tura WHERE IdTura={idTura}";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            if (reader.HasRows)
            {
                reader.Read();
                tura = KreirajTuru(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return tura;
        }

        public void DodajTuru(Tura t)
        {
            string sql = $"INSERT INTO Tura (NazivTure, Cijena, Kapacitet, Lokacija, RepozitorijTuraID) " +
                         $"VALUES ('{t.NazivTure}', {t.Cijena.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                         $"{t.Kapacitet}, '{t.Lokacija}', {t.RepozitorijTuraID})";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public void AzurirajTuru(Tura t)
        {
            string sql = $"UPDATE Tura SET NazivTure='{t.NazivTure}', " +
                         $"Cijena={t.Cijena.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                         $"Kapacitet={t.Kapacitet}, Lokacija='{t.Lokacija}' " +
                         $"WHERE IdTura={t.IdTura}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public void ObrisiTuru(int idTura)
        {
            string sql = $"DELETE FROM Tura WHERE IdTura={idTura}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        private Tura KreirajTuru(SqlDataReader reader)
        {
            return new Tura
            {
                IdTura = Convert.ToInt32(reader["IdTura"]),
                NazivTure = reader["NazivTure"].ToString(),
                Cijena = Convert.ToDecimal(reader["Cijena"]),
                Kapacitet = Convert.ToInt32(reader["Kapacitet"]),
                Lokacija = reader["Lokacija"].ToString(),
                RepozitorijTuraID = Convert.ToInt32(reader["RepozitorijTuraID"])
            };
        }

        public List<Rezervacija> DohvatiRezervacije(DateTime datumOd, DateTime datumDo)
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            string sql = $"SELECT * FROM Rezervacija WHERE Datum >= '{datumOd:yyyy-MM-dd}' AND Datum <= '{datumDo:yyyy-MM-dd}'";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                rezervacije.Add(KreirajRezervaciju(reader));
            }

            reader.Close();
            DB.CloseConnection();
            return rezervacije;
        }

        private Rezervacija KreirajRezervaciju(SqlDataReader reader)
        {
            return new Rezervacija
            {
                IdRezervacija = Convert.ToInt32(reader["IdRezervacija"]),
                KlijentID = Convert.ToInt32(reader["KlijentID"]),
                TuraID = Convert.ToInt32(reader["TuraID"]),
                ZaposlenikID = Convert.ToInt32(reader["ZaposlenikID"]),
                Datum = Convert.ToDateTime(reader["Datum"]),
                Iznos = Convert.ToDecimal(reader["Iznos"])
            };
        }
    }
}
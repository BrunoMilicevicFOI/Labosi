using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarazdinTourManager.Models
{
    public class Zaposlenik
    {
        public int IdKorisnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorIme { get; set; }
        public string KorLozinka { get; set; }
        public string Uloga { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
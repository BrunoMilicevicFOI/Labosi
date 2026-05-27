using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarazdinTourManager.Models
{
    public class Rezervacija
    {
        public int IdRezervacija { get; set; }
        public int KlijentID { get; set; }
        public int TuraID { get; set; }
        public int ZaposlenikID { get; set; }
        public DateTime Datum { get; set; }
        public decimal Iznos { get; set; }
    }
}

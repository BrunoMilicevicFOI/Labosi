using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarazdinTourManager.Models
{
    public class Tura
    {
        public int IdTura { get; set; }
        public string NazivTure { get; set; }
        public decimal Cijena { get; set; }
        public int Kapacitet { get; set; }
        public string Lokacija { get; set; }
        public int RepozitorijTuraID { get; set; }

        public override string ToString()
        {
            return NazivTure + " - " + Lokacija;
        }
    }
}
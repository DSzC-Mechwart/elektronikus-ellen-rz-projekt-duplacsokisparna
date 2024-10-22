using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikusEllenőrzőProjekt
{
    internal class HConsturctor
    {
        public HConsturctor(string nev, int oM, string matek, string töri, string nyelvtan, string irodalom, string idegen, string szakma, string tesi, string fizika)
        {
            Nev = nev;
            OM = oM;
            Matek = matek;
            Töri = töri;
            Nyelvtan = nyelvtan;
            Irodalom = irodalom;
            Idegen = idegen;
            Szakma = szakma;
            Tesi = tesi;
            Fizika = fizika;
        }

        public string Nev {  get; set; }
        public int OM { get; set; }
        public string Matek { get; set; }
        public string Töri { get; set; }
        public string Nyelvtan { get; set; }
        public string Irodalom { get; set; }
        public string Idegen { get; set; }
        public string Szakma { get; set; }
        public string Tesi { get; set; }
        public string Fizika { get; set; }



    }
}

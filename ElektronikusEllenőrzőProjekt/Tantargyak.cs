using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikusEllenőrzőProjekt
{
    internal class Tantargyak
    {
        public Tantargyak(int id, string? tantargy, string? evfolyam, string? kozSzak, int hetiora, int evesora)
        {
            Id = id;
            Tantargy = tantargy;
            Evfolyam = evfolyam;
            KozSzak = kozSzak;
            Hetiora = hetiora;
            Evesora = evesora;
        }

        public int Id { get; set; }
        public string? Tantargy { get; set; }
        public string? Evfolyam { get; set; }
        public string? KozSzak { get; set; }
        public int Hetiora { get; set; }
        public int Evesora { get; set; }
    }
}

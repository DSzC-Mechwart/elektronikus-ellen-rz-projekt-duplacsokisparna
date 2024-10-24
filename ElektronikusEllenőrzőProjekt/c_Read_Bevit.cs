using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikusEllenőrzőProjekt
{
    public class c_Read_Bevit
    {

        public c_Read_Bevit(string nev, string szulHely, DateTime szulIdo, string anyjanev, string lakcim, DateTime beirIdo, string szak, string osztaly, string kolise, string koli, int naploszam, string torzsszam)
        {
            this.nev = nev;
            this.szulHely = szulHely;
            this.szulIdo = szulIdo;
            this.anyjanev = anyjanev;
            this.lakcim = lakcim;
            this.beirIdo = beirIdo;
            this.szak = szak;
            this.osztaly = osztaly;
            this.kolise = kolise;
            this.koli = koli;
            this.naploszam = naploszam;
            this.torzsszam = torzsszam;
        }

        public string nev { get; set; }
        public string szulHely { get; set; }
        public DateTime szulIdo { get; set; }
        public string anyjanev { get; set; }
        public string lakcim { get; set; }
        public DateTime beirIdo { get; set; }
        public string szak { get; set; }
        public string osztaly { get; set; }
        public string kolise { get; set; }
        public string koli { get; set; }
        public int naploszam { get; set; }
        public string torzsszam { get; set; }

    }
}

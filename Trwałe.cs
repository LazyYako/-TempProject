using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektObiektowka
{
    internal class Trwałe : Zasób
    {
        int ileRazyUżyty;

        public Trwałe(string nazwa, string producent, string typ, int ilość, int ileRazyUżyty) : base(nazwa, producent, typ, ilość)
        {
            this.ileRazyUżyty = ileRazyUżyty;
        }

    }
}

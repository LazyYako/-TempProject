using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektObiektowka
{
    internal class Materiały : Zasób
    {
        int czasPosiadania;

        public Materiały(string nazwa, string producent, string typ, int ilość, int czasPosiadania) : base(nazwa, producent, typ, ilość)
        {
            this.czasPosiadania = czasPosiadania;
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektObiektowka
{
    internal class Zasób
    {
        private string nazwa;
        private string producent;
        private string typ;
        private int ilość;

        public Zasób(string nazwa, string producent, string typ, int ilość)
        {
            this.nazwa = nazwa;
            this.producent = producent;
            this.typ = typ;
            this.ilość = ilość;
        }

        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }

        public string Producent
        {
            get { return producent; }
            set { producent = value; }
        }

        public string Typ
        {
            get { return typ; }
            set { typ = value; }
        }

        public int Ilość
        {
            get { return ilość; }
            set { ilość = value; }
        }
        public override string ToString()
        {
            return "Zasób: " + nazwa + " | " + producent + " | " + typ + " | " + ilość;
        }
    }
}

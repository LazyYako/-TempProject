using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektObiektowka
{
    internal class Zadanie
    {
        private string nazwa;
        List<Zasób> zasoby;

        public Zadanie(string nazwa)
        {
            zasoby = new List<Zasób>();
            this.nazwa = nazwa;
        }

        public void PrzypiszZasób(Zasób zasób)
        {
            zasoby.Add(zasób);
        }

        public void UsuńZasób(Zasób zasób)
        {
            zasoby.Remove(zasób);
        }

        public override string ToString()
        {
            string zasobyString = "";
            foreach (Zasób zasób in zasoby)
            {
                zasobyString += zasób.ToString() + "\n";
            }
            return "Zadanie: " + nazwa + "\nZasoby: " + zasobyString;
        }
        public string Nazwa
        {
            get { return nazwa; }
        }

        public List<Zasób> Zasoby
        {
            get { return zasoby; }
        }
    }
}

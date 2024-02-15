using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;//csv
using System.Globalization;//csv
using System.IO;//csv

namespace ProjektObiektowka
{
    internal class Program
    {
        public static (List<Projekt>, List<Manager>, List<Pracownik>, List<Zadanie>, List<Zasób>) ImportData()
        {
            List<Projekt> projekty = new List<Projekt>();
            string[] lines = System.IO.File.ReadAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\projekty.csv");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string nazwa = data[0];
                string opis = data[1];
                DateTime dataRozpoczecia = DateTime.Parse(data[2]);
                DateTime dataZakonczenia = DateTime.Parse(data[3]);
                Projekt projekt = new Projekt(nazwa, opis, dataRozpoczecia, dataZakonczenia);
                projekty.Add(projekt);
            }
            List<Manager> managerowie = new List<Manager>();
            lines = System.IO.File.ReadAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\managerowie.csv");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string imie = data[0];
                string nazwisko = data[1];
                string telefon = data[2];
                string email = data[3];
                int pensja = int.Parse(data[4]);
                Manager manager = new Manager(imie, nazwisko, telefon, email, pensja);
                managerowie.Add(manager);
            }

            List<Pracownik> pracownicy = new List<Pracownik>();
            lines = System.IO.File.ReadAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\pracownicy.csv");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string imie = data[0];
                string nazwisko = data[1];
                string telefon = data[2];
                string email = data[3];
                string stanowisko = data[4];
                int pensja = int.Parse(data[5]);
                Pracownik pracownik = new Pracownik(imie, nazwisko, telefon, email, stanowisko, pensja);
                pracownicy.Add(pracownik);
            }

            List<Zadanie> zadania = new List<Zadanie>();
            lines = System.IO.File.ReadAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\zadania.csv");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string nazwa = data[0];
                Zadanie zadanie = new Zadanie(nazwa);
                zadania.Add(zadanie);
            }

            List<Zasób> zasoby = new List<Zasób>();
            lines = System.IO.File.ReadAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\zasoby.csv");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string nazwa = data[0];
                string producent = data[1];
                string typ = data[2];
                int ilosc = int.Parse(data[3]);
                Zasób zasob = new Zasób(nazwa, producent, typ, ilosc);
                zasoby.Add(zasob);
            }

            return (projekty, managerowie, pracownicy, zadania, zasoby);
        }

        public static void ExportData(List<Projekt> projekty, List<Manager> managerowie, List<Pracownik> pracownicy, List<Zadanie> zadania, List<Zasób> zasoby)
        {
            string[] lines = new string[projekty.Count];
            for (int i = 0; i < projekty.Count; i++)
            {
                lines[i] = projekty[i].Nazwa + "," + projekty[i].Opis + "," + projekty[i].DataRozpoczecia + "," + projekty[i].DeadLine;
            }

            System.IO.File.WriteAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\projekty.csv", lines);

            lines = new string[managerowie.Count];
            for (int i = 0; i < managerowie.Count; i++)
            {
                lines[i] = managerowie[i].Imie + "," + managerowie[i].Nazwisko + "," + managerowie[i].Telefon + "," + managerowie[i].Email + "," + managerowie[i].Pensja;
            }
          
            System.IO.File.WriteAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\managerowie.csv", lines);

            lines = new string[pracownicy.Count];
            for (int i = 0; i < pracownicy.Count; i++)
            {
                lines[i] = pracownicy[i].Imie + "," + pracownicy[i].Nazwisko + "," + pracownicy[i].Telefon + "," + pracownicy[i].Email + "," + pracownicy[i].Stanowisko + "," + pracownicy[i].Pensja;
            }
            System.IO.File.WriteAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\pracownicy.csv", lines);

            lines = new string[zadania.Count];
            for (int i = 0; i < zadania.Count; i++)
            {
                lines[i] = zadania[i].Nazwa;
            }
            System.IO.File.WriteAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\zadania.csv", lines);

            lines = new string[zasoby.Count];
            for (int i = 0; i < zasoby.Count; i++)
            {
                lines[i] = zasoby[i].Nazwa + "," + zasoby[i].Producent + "," + zasoby[i].Typ + "," + zasoby[i].Ilość;
            }
            System.IO.File.WriteAllLines(@"W:\Offline\Projekt programowanie obiektowe\Projekt\ProjektObiektowka\PlikiCSV\zasoby.csv", lines);
        }
        
    static void Main(string[] args)
        {
            bool Zakoncz = false;
            int wybor = 0;
            List<Projekt> projekty = new List<Projekt>();
            List<Manager> managerowie = new List<Manager>();
            List<Pracownik> pracownicy = new List<Pracownik>();
            List<Zadanie> zadania = new List<Zadanie>();
            List<Zasób> zasoby = new List<Zasób>();

            try {
                (projekty, managerowie, pracownicy, zadania, zasoby) = ImportData();
            } catch (Exception z) {
                Console.WriteLine("Plik nie istnieje");
            }
            /* Projekt projekt = UtwórzProjekt();
             Console.WriteLine(projekt.ToString());//test
             Manager manager = UtwórzManagera();
             projekt.PrzypiszManagera(manager);
             Console.WriteLine(manager.ToString());//test
             Pracownik pracownik = UtwórzPracownika();
             manager.DodajPracownika(pracownik);
             Console.WriteLine(pracownik.ToString());//test
             Console.WriteLine("Podaj zadanie dla pracownika: ");
             string zadanie = Console.ReadLine();
             manager.DodajZadanie(pracownik, zadanie);
             pracownik.DodajZadanie(zadanie);
             projekt.DodajZadanie(new Zadanie(zadanie));
             projekt.WyswietlZadania();
             manager.WyswietlPracownikow();

         }

         static Projekt UtwórzProjekt()
         {
             Console.WriteLine("Podaj nazwę projektu: ");
             string nazwa = Console.ReadLine();
             Console.WriteLine("Podaj opis projektu: ");
             string opis = Console.ReadLine();
             Console.WriteLine("Podaj datę rozpoczęcia projektu (format yyyy-mm-dd): ");
             DateTime dataRozpoczecia = DateTime.Parse(Console.ReadLine());
             Console.WriteLine("Podaj datę zakończenia projektu (format yyyy-mm-dd): ");
             DateTime dataZakonczenia = DateTime.Parse(Console.ReadLine());

             return new Projekt(nazwa, opis, dataRozpoczecia, dataZakonczenia);
         }
         static Manager UtwórzManagera()
         {
             Console.WriteLine("Podaj imię managera: ");
             string imie = Console.ReadLine();
             Console.WriteLine("Podaj nazwisko managera: ");
             string nazwisko = Console.ReadLine();
             Console.WriteLine("Podaj telefon managera: ");
             string telefon = Console.ReadLine();
             Console.WriteLine("Podaj email managera: ");
             string email = Console.ReadLine();
             Console.WriteLine("Podaj pensję managera: ");
             int pensja = int.Parse(Console.ReadLine());

             return new Manager(imie, nazwisko, telefon, email, pensja);
         }
         static Pracownik UtwórzPracownika()
         {
             Console.WriteLine("Podaj imię pracownika: ");
             string imie = Console.ReadLine();
             Console.WriteLine("Podaj nazwisko pracownika: ");
             string nazwisko = Console.ReadLine();
             Console.WriteLine("Podaj telefon pracownika: ");
             string telefon = Console.ReadLine();
             Console.WriteLine("Podaj email pracownika: ");
             string email = Console.ReadLine();
             Console.WriteLine("Podaj stanowisko pracownika: ");
             string stanowisko = Console.ReadLine();
             Console.WriteLine("Podaj pensję pracownika: ");
             int pensja = int.Parse(Console.ReadLine());

             return new Pracownik(imie, nazwisko, telefon, email, stanowisko, pensja);
         }
         */

            do
            {
                Console.WriteLine("1. Dodaj projekt");
                Console.WriteLine("2. Dodaj managera");
                Console.WriteLine("3. Dodaj pracownika");
                Console.WriteLine("4. Dodaj zadanie");
                Console.WriteLine("5. Dodaj zasób do zadania");
                Console.WriteLine("6. Wyświetl projekty");
                Console.WriteLine("7. Wyświetl managerów");
                Console.WriteLine("8. Wyświetl pracowników");
                Console.WriteLine("9. Wyświetl zadania");
                Console.WriteLine("10. Wyświetl zasoby");
                Console.WriteLine("11. Eksportuj dane");
                Console.WriteLine("12. Wyjdź");
                wybor = int.Parse(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwę projektu: ");
                        string nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj opis projektu: ");
                        string opis = Console.ReadLine();
                        Console.WriteLine("Podaj datę rozpoczęcia projektu (format yyyy-mm-dd): ");
                        DateTime dataRozpoczecia = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj datę zakończenia projektu (format yyyy-mm-dd): ");
                        DateTime dataZakonczenia = DateTime.Parse(Console.ReadLine());
                        Projekt projekt = new Projekt(nazwa, opis, dataRozpoczecia, dataZakonczenia);
                        projekty.Add(projekt);
                        break;
                    case 2:
                        Console.WriteLine("Podaj imię managera: ");
                        string imie = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko managera: ");
                        string nazwisko = Console.ReadLine();
                        Console.WriteLine("Podaj telefon managera: ");
                        string telefon = Console.ReadLine();
                        Console.WriteLine("Podaj email managera: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Podaj pensję managera: ");
                        int pensja = int.Parse(Console.ReadLine());
                        Manager manager = new Manager(imie, nazwisko, telefon, email, pensja);
                        Console.WriteLine("Wybierz projekt: ");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        int wyborProjektu = int.Parse(Console.ReadLine());
                        projekty[wyborProjektu].PrzypiszManagera(manager);
                        Console.WriteLine("Dodano managera do projektu: " + projekty[wyborProjektu].Nazwa);
                        managerowie.Add(manager);
                        break;
                    case 3:
                        Console.WriteLine("Podaj imię pracownika: ");
                        imie = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko pracownika: ");
                        nazwisko = Console.ReadLine();
                        Console.WriteLine("Podaj telefon pracownika: ");
                        telefon = Console.ReadLine();
                        Console.WriteLine("Podaj email pracownika: ");
                        email = Console.ReadLine();
                        Console.WriteLine("Podaj stanowisko pracownika: ");
                        string stanowisko = Console.ReadLine();
                        Console.WriteLine("Podaj pensję pracownika: ");
                        pensja = int.Parse(Console.ReadLine());
                        Pracownik pracownik = new Pracownik(imie, nazwisko, telefon, email, stanowisko, pensja);
                        pracownicy.Add(pracownik);
                        Console.WriteLine("Wybierz projekt: ");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        wyborProjektu = int.Parse(Console.ReadLine());
                        projekty[wyborProjektu].Manager.DodajPracownika(pracownik);
                        Console.WriteLine("Dodano pracownika do projektu: " + projekty[wyborProjektu].Nazwa);
                        pracownicy.Add(pracownik);
                        break;
                    case 4:
                        Console.WriteLine("Podaj zadanie dla pracownika: ");
                        string zadanie = Console.ReadLine();
                        Console.WriteLine("Wybierz projekt: ");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        wyborProjektu = int.Parse(Console.ReadLine());
                        Console.WriteLine("Wybierz pracownika: ");
                        for (int i = 0; i < projekty[wyborProjektu].Manager.Pracownicy.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[wyborProjektu].Manager.Pracownicy[i].Imie + " " + projekty[wyborProjektu].Manager.Pracownicy[i].Nazwisko);
                        }
                        int wyborPracownika = int.Parse(Console.ReadLine());
                        projekty[wyborProjektu].Manager.DodajZadanie(projekty[wyborProjektu].Manager.Pracownicy[wyborPracownika], zadanie);
                        projekty[wyborProjektu].DodajZadanie(new Zadanie(zadanie)); // shrek
                        zadania.Add(new Zadanie(zadanie));
                        break;
                    case 5:
                        Console.WriteLine("Podaj nazwę zasobu: ");
                        nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj producenta zasobu: ");
                        string producent = Console.ReadLine();
                        Console.WriteLine("Podaj typ zasobu: ");
                        string typ = Console.ReadLine();
                        Console.WriteLine("Podaj ilość zasobu: ");
                        int ilosc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Wybierz projekt: ");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        wyborProjektu = int.Parse(Console.ReadLine());
                        Console.WriteLine("Wybierz zadanie: ");
                        for (int i = 0; i < projekty[wyborProjektu].Zadania.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[wyborProjektu].Zadania[i].Nazwa);
                        }
                        int wyborZadania = int.Parse(Console.ReadLine());
                        projekty[wyborProjektu].Zadania[wyborZadania].Zasoby.Add(new Zasób(nazwa, producent, typ, ilosc));
                        zasoby.Add(new Zasób(nazwa, producent, typ, ilosc));
                        break;
                    case 6:
                        Console.WriteLine("Format: Nazwa, Opis, DataRozpoczecia, Deadline");
                        foreach (Projekt p in projekty)
                        {
                            Console.WriteLine(p.ToString());
                        }
                        break;
                    case 7:
                        Console.WriteLine("Wybierz projekt: ");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        wyborProjektu = int.Parse(Console.ReadLine());
                        Console.WriteLine("Format: Imie, Nazwisko, Telefon, Email, Pensja");
                        foreach (Projekt p in projekty)
                        {
                            Console.WriteLine(p.Manager.ToString());
                        }
                        break;
                    case 8:
                        Console.WriteLine("Wybierz projekt: ");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        wyborProjektu = int.Parse(Console.ReadLine());
                        foreach (Projekt p in projekty)
                        {
                            foreach (Pracownik pracownikk in p.Manager.Pracownicy)
                            {
                                Console.WriteLine(pracownikk.ToString());
                            }
                        }
                        break;
                    case 9:
                        Console.WriteLine("wybierz projekt:");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        wyborProjektu = int.Parse(Console.ReadLine());
                        foreach (Projekt p in projekty)
                        {
                            p.WyswietlZadania();
                        }
                        break;
                    case 10:
                        Console.WriteLine("Wybierz projekt: ");
                        for (int i = 0; i < projekty.Count; i++)
                        {
                            Console.WriteLine(i + ". " + projekty[i].Nazwa);
                        }
                        wyborProjektu = int.Parse(Console.ReadLine());
                        foreach (Zadanie z in projekty[wyborProjektu].Zadania)
                        {
                            foreach (Zasób zasob in z.Zasoby)
                            {
                                Console.WriteLine(zasob.ToString());
                            }
                        }
                        break;
                    case 11:
                        ExportData(projekty, managerowie, pracownicy, zadania, zasoby);
                        break;
                    case 12:
                        Zakoncz = true;
                        break;
                }
            } while (!Zakoncz);
        }
    } 
    
}
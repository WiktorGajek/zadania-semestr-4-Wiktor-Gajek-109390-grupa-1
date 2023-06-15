using System;
using System.Collections.Generic;

public class Ksiazka
{
    // Deklaracja właściwości klasy Ksiazka
    public string Tytul { get; set; }
    public string Autor { get; set; }
    public int RokWydania { get; set; }
    public string Wydawca { get; set; }
    public string NumerISBN { get; set; }
    public string Gatunek { get; set; }
    public int LiczbaDostepnychEgzemplarzy { get; set; }
}

public class Biblioteka
{
    private List<Ksiazka> inwentarz; // Lista przechowująca książki w bibliotece
    private List<Wypozyczenie> wypozyczenia; // Lista przechowująca informacje o wypożyczeniach

    public Biblioteka()
    {
        // Inicjalizacja list
        inwentarz = new List<Ksiazka>();
        wypozyczenia = new List<Wypozyczenie>();
    }

    public void DodajKsiazke(Ksiazka ksiazka)
    {
        // Dodanie książki do listy inwentarza
        inwentarz.Add(ksiazka);
    }

    public void UsunKsiazke(Ksiazka ksiazka)
    {
        // Usunięcie książki z listy inwentarza
        inwentarz.Remove(ksiazka);
    }

    public void AktualizujKsiazke(Ksiazka ksiazka)
    {
        // Znalezienie książki o tym samym numerze ISBN w inwentarzu i aktualizacja jej danych
        Ksiazka znalezionaKsiazka = inwentarz.Find(k => k.NumerISBN == ksiazka.NumerISBN);
        if (znalezionaKsiazka != null)
        {
            // Aktualizacja danych książki
            znalezionaKsiazka.Tytul = ksiazka.Tytul;
            znalezionaKsiazka.Autor = ksiazka.Autor;
            znalezionaKsiazka.RokWydania = ksiazka.RokWydania;
            znalezionaKsiazka.Wydawca = ksiazka.Wydawca;
            znalezionaKsiazka.Gatunek = ksiazka.Gatunek;
            znalezionaKsiazka.LiczbaDostepnychEgzemplarzy = ksiazka.LiczbaDostepnychEgzemplarzy;
        }
    }

    public List<Ksiazka> WyszukajKsiazki(string kryterium, string wartosc)
    {
        // Wyszukiwanie książek na podstawie określonego kryterium (np. tytuł, autor, gatunek)

        List<Ksiazka> znalezioneKsiazki = new List<Ksiazka>();
        switch (kryterium)
        {
            case "tytul":
                // Wyszukiwanie po tytule
                znalezioneKsiazki = inwentarz.FindAll(k => k.Tytul.ToLower().Contains(wartosc.ToLower()));
                break;
            case "autor":
                // Wyszukiwanie po autorze
                znalezioneKsiazki = inwentarz.FindAll(k => k.Autor.ToLower().Contains(wartosc.ToLower()));
                break;
            case "gatunek":
                // Wyszukiwanie po gatunku
                znalezioneKsiazki = inwentarz.FindAll(k => k.Gatunek.ToLower().Contains(wartosc.ToLower()));
                break;
            default:
                Console.WriteLine("Nieprawidłowe kryterium wyszukiwania.");
                break;
        }
        return znalezioneKsiazki;
    }

    public void WypozyczKsiazke(Ksiazka ksiazka, string imie, string nazwisko, DateTime dataWypozyczenia, DateTime dataZwrotu)
    {
        if (ksiazka.LiczbaDostepnychEgzemplarzy > 0)
        {
            // Zmniejszenie liczby dostępnych egzemplarzy książki
            ksiazka.LiczbaDostepnychEgzemplarzy--;

            // Utworzenie obiektu wypożyczenia i dodanie go do listy wypożyczeń
            Wypozyczenie wypozyczenie = new Wypozyczenie();
            wypozyczenie.Ksiazka = ksiazka;
            wypozyczenie.Imie = imie;
            wypozyczenie.Nazwisko = nazwisko;
            wypozyczenie.DataWypozyczenia = dataWypozyczenia;
            wypozyczenie.DataZwrotu = dataZwrotu;

            wypozyczenia.Add(wypozyczenie);
        }
        else
        {
            Console.WriteLine("Przepraszamy, brak dostępnych egzemplarzy tej książki.");
        }
    }

    public List<Wypozyczenie> PobierzWypozyczenia()
    {
        // Pobranie listy wypożyczeń
        return wypozyczenia;
    }

    public List<Ksiazka> PobierzInwentarz()
    {
        // Pobranie listy książek w inwentarzu
        return inwentarz;
    }
}

public class Wypozyczenie
// Deklaracja właściwości klasy Wypozyczenie
{
    public Ksiazka Ksiazka { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public DateTime DataWypozyczenia { get; set; }
    public DateTime DataZwrotu { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        // Tworzenie obiektu biblioteki
        Biblioteka biblioteka = new Biblioteka();

        // Tworzenie obiektów książek
        Ksiazka ksiazka1 = new Ksiazka()
        {
            Tytul = "Przykładowa Książka 1",
            Autor = "Autor 1",
            RokWydania = 2020,
            Wydawca = "Wydawca 1",
            NumerISBN = "123456789",
            Gatunek = "Przykładowy Gatunek",
            LiczbaDostepnychEgzemplarzy = 2
        };

        Ksiazka ksiazka2 = new Ksiazka()
        {
            Tytul = "Przykładowa Książka 2",
            Autor = "Autor 2",
            RokWydania = 2021,
            Wydawca = "Wydawca 2",
            NumerISBN = "987654321",
            Gatunek = "Inny Gatunek",
            LiczbaDostepnychEgzemplarzy = 1
        };

        // Dodawanie książek do inwentarza biblioteki
        biblioteka.DodajKsiazke(ksiazka1);
        biblioteka.DodajKsiazke(ksiazka2);

        while (true)
        {
            Console.WriteLine("1. Pokaż listę książek");
            Console.WriteLine("2. Dodaj książkę");
            Console.WriteLine("3. Usuń książkę");
            Console.WriteLine("4. Pokaż wypożyczających");
            Console.WriteLine("5. Wyjdź");

            Console.Write("Wybierz opcję: ");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    Console.WriteLine("Lista książek:");
                    List<Ksiazka> inwentarz = biblioteka.PobierzInwentarz();
                    foreach (Ksiazka ksiazka in inwentarz)
                    {
                        Console.WriteLine($"Tytuł: {ksiazka.Tytul}, Autor: {ksiazka.Autor}, Gatunek: {ksiazka.Gatunek}");
                    }
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Write("Podaj tytuł książki: ");
                    string tytul = Console.ReadLine();
                    Console.Write("Podaj autora książki: ");
                    string autor = Console.ReadLine();
                    Console.Write("Podaj rok wydania książki: ");
                    int rokWydania = int.Parse(Console.ReadLine());
                    Console.Write("Podaj wydawcę książki: ");
                    string wydawca = Console.ReadLine();
                    Console.Write("Podaj numer ISBN książki: ");
                    string numerISBN = Console.ReadLine();
                    Console.Write("Podaj gatunek książki: ");
                    string gatunek = Console.ReadLine();
                    Console.Write("Podaj liczbę dostępnych egzemplarzy książki: ");
                    int liczbaEgzemplarzy = int.Parse(Console.ReadLine());

                    Ksiazka nowaKsiazka = new Ksiazka()
                    {
                        Tytul = tytul,
                        Autor = autor,
                        RokWydania = rokWydania,
                        Wydawca = wydawca,
                        NumerISBN = numerISBN,
                        Gatunek = gatunek,
                        LiczbaDostepnychEgzemplarzy = liczbaEgzemplarzy
                    };

                    biblioteka.DodajKsiazke(nowaKsiazka);
                    Console.WriteLine("Książka została dodana do spisu.");
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Write("Podaj numer ISBN książki do usunięcia: ");
                    string isbn = Console.ReadLine();

                    Ksiazka ksiazkaDoUsuniecia = biblioteka.PobierzInwentarz().Find(k => k.NumerISBN == isbn);
                    if (ksiazkaDoUsuniecia != null)
                    {
                        biblioteka.UsunKsiazke(ksiazkaDoUsuniecia);
                        Console.WriteLine("Książka została usunięta ze spisu.");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono książki o podanym numerze ISBN.");
                    }
                    Console.WriteLine();
                    break;
                case "4":
                    List<Wypozyczenie> wypozyczenia = biblioteka.PobierzWypozyczenia();
                    Console.WriteLine("Lista wypożyczających:");
                    foreach (Wypozyczenie wypozyczenie in wypozyczenia)
                    {
                        Console.WriteLine($"Imię i nazwisko: {wypozyczenie.Imie} {wypozyczenie.Nazwisko}, Tytuł książki: {wypozyczenie.Ksiazka.Tytul}");
                    }
                    Console.WriteLine();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Wybierz ponownie.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}

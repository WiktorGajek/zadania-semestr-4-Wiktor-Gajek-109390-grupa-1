using System;
//klasa pokazują zwierze
class Zwierze
{
    // Metoda wirtualna do przedstawiania się zwierzęcia
    public virtual void PrzedstawSie()
    {
        Console.WriteLine("Jestem zwierzęciem.");
    }

    // Metoda wirtualna do wydawania dźwięku przez zwierzę
    public virtual void WydajDzwiek()
    {
        Console.WriteLine("Wydaje dzwięk.");
    }
}

// Klasa pochodna reprezentująca dane zwierze
class Kot : Zwierze
{
    // wywolanie rodzaju zwierzecia
    public override void PrzedstawSie()
    {
        Console.WriteLine("Jestem kotem.");
    }

    // wywolanie dzwieku zwierzecia
    public override void WydajDzwiek()
    {
        Console.WriteLine("Miau");
    }
}

class Pies : Zwierze
{
    public override void PrzedstawSie()
    {
        Console.WriteLine("Jestem psem.");
    }

    public override void WydajDzwiek()
    {
        Console.WriteLine("HAU!");
    }
}

class Ptak : Zwierze
{
    public override void PrzedstawSie()
    {
        Console.WriteLine("Jestem ptakiem.");
    }

    public override void WydajDzwiek()
    {
        Console.WriteLine("Ćwir Ćwir!");
    }
}

class Program
{
    static void Main()
    {
        // Obiekty Różnych zwierząt
        Zwierze zwierze1 = new Zwierze();
        Zwierze zwierze2 = new Kot();
        Zwierze zwierze3 = new Pies();
        Zwierze zwierze4 = new Ptak();

        // Wywołanie metody PrzedstawZwierze() dla każdego obiektu
        PrzedstawZwierze(zwierze1);
        PrzedstawZwierze(zwierze2);
        PrzedstawZwierze(zwierze3);
        PrzedstawZwierze(zwierze4);
    }

    // Metoda polimorficzna do przedstawiania zwierzęcia
    static void PrzedstawZwierze(Zwierze zwierze)
    {
        // Wywołanie metody PrzedstawSie() na obiekcie zwierzęcia
        zwierze.PrzedstawSie();

        // Wywołanie metody WydajDzwiek() na obiekcie zwierzęcia
        zwierze.WydajDzwiek();
    }
}

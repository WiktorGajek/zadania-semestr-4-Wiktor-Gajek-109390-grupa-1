using System;

class Program
{
    static void Main()
    {
        int totalLetters = 0;

        for (int i = 1; i <= 1000; i++)
        {
            string numberWord = NumberToWords(i);

            int lettersCount = CountLetters(numberWord);

            totalLetters += lettersCount;

            // wyświetlenie nazwy danej liczby za pomocą liter
            Console.WriteLine("Liczba: " + i + ", Zapis słowny: " + numberWord + ", Liczba liter: " + lettersCount);
        }

        // Pokazanie ile liter zostało użytych
        Console.WriteLine("Liczba użytych liter: " + totalLetters);
    }

    static string NumberToWords(int number)
    {
        string[] unitsMap = new string[]
        {
            "", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "dziesięć", "jedenaście",
            "dwanaście", "trzynaście", "czternaście", "piętnaście", "szesnaście", "siedemnaście", "osiemnaście", "dziewiętnaście"
        };

        string[] tensMap = new string[]
        {
            "", "", "dwadzieścia", "trzydzieści", "czterdzieści", "pięćdziesiąt", "sześćdziesiąt", "siedemdziesiąt",
            "osiemdziesiąt", "dziewięćdziesiąt"
        };

        string[] hundredsMap = new string[]
        {
            "", "sto", "dwieście", "trzysta", "czterysta", "pięćset", "sześćset", "siedemset", "osiemset", "dziewięćset"
        };

        string[] thousandsMap = new string[]
        {
            "", "tysiąc", "dwa tysiące", "trzy tysiące", "cztery tysiące", "pięć tysięcy", "sześć tysięcy", "siedem tysięcy",
            "osiem tysięcy", "dziewięć tysięcy"
        };

        string numberWord = "";

        if (number == 0)
        {
            numberWord = "zero";
        }
        else if (number < 20)
        {
            numberWord = unitsMap[number];
        }
        else if (number < 100)
        {
            numberWord = tensMap[number / 10] + " " + unitsMap[number % 10];
        }
        else if (number < 1000)
        {
            numberWord = hundredsMap[number / 100] + " " + NumberToWords(number % 100);
        }
        else
        {
            numberWord = thousandsMap[number / 1000] + " " + NumberToWords(number % 1000);
        }

        return numberWord.Trim();
    }

    static int CountLetters(string word)
    {
        int count = 0;

        foreach (char c in word)
        {
            if (char.IsLetter(c))
                count++;
        }

        return count;
    }
}
//Wykonał nr indexu:109390
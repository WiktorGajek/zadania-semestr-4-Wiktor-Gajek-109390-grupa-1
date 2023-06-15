using System;

class Program
{
    static void Main()
    {
        int longestChain = 0; // Długość najdłuższego łańcucha
        int numberWithLongestChain = 0; // Numer startowy dla najdłuższego łańcucha

        for (int i = 1; i < 1000000; i++) // Iteracja od 1 do 999999
        {
            int chainLength = GenerateSequence(i); // Generowanie łańcucha dla liczby startowej i

            if (chainLength > longestChain)  // Sprawdzenie, czy obecna długość łańcucha jest większa od dotychczasowego rekordu
            {
                longestChain = chainLength; // Aktualizacja wartości najdłuższego łańcucha
                numberWithLongestChain = i; // Aktualizacja numeru startowego dla najdłuższego łańcucha
            }
        }

        Console.WriteLine("Najdłuższy łańcuch generowany przez numer startowy: " + numberWithLongestChain);
        Console.WriteLine("Długość najdłuższego łańcucha: " + longestChain);
    }

    static int GenerateSequence(long number)
    {
        int count = 1; // Zaczynamy od 1, bo liczba startowa również jest brana pod uwagę

        while (number != 1)
        {
            if (number % 2 == 0) // Sprawdzenie, czy liczba jest parzysta
                number /= 2;
            else // Jeśli liczba jest nieparzysta
                number = 3 * number + 1;

            count++;
        }

        return count;
    }
}

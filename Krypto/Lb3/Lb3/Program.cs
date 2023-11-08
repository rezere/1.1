using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string ciphertext = "_ясн_емазиутечни_й_м_щ_озитабмерхе_в_нс_іямазиущечно_йе_нетпе_ру_іомжрв_тиіит__бо";

        Console.WriteLine("Зашифрований текст: " + ciphertext);

        List<string> possibleKeys = GenerateColumnPermutations(ciphertext.Length);
        Console.WriteLine(possibleKeys);
        foreach (string key in possibleKeys)
        {
            Console.ReadLine();
            string plaintext = DecryptColumnarTransposition(ciphertext, key);
            Console.WriteLine("Ключ для шифрування: " + key);
            Console.WriteLine("Розмірність матриці: " + GetMatrixDimensions(ciphertext.Length, key.Length));
            Console.WriteLine("Розшифрований текст: " + plaintext);
        }
    }

    static List<string> GenerateColumnPermutations(int length)
    {
        List<string> permutations = new List<string>();
        string baseKey = new string(Enumerable.Range(0, length).Select(i => (char)('A' + i)).ToArray());
        GeneratePermutations(baseKey.ToCharArray(), 0, length - 1, permutations);
        return permutations;
    }

    static void GeneratePermutations(char[] key, int left, int right, List<string> permutations)
    {
        if (left == right)
        {
            permutations.Add(new string(key));
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                Swap(ref key[left], ref key[i]);
                GeneratePermutations(key, left + 1, right, permutations);
                Swap(ref key[left], ref key[i]); // Backtrack
            }
        }
    }

    static void Swap(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }

    static string DecryptColumnarTransposition(string ciphertext, string key)
    {
        int numColumns = key.Length;
        int numRows = ciphertext.Length / numColumns;

        char[,] matrix = new char[numRows, numColumns];
        int currentIndex = 0;

        for (int col = 0; col < numColumns; col++)
        {
            for (int row = 0; row < numRows; row++)
            {
                matrix[row, col] = ciphertext[currentIndex];
                currentIndex++;
            }
        }

        char[] decryptedText = new char[ciphertext.Length];
        currentIndex = 0;

        for (int col = 0; col < numColumns; col++)
        {
            int originalIndex = key.IndexOf((char)('A' + col));
            for (int row = 0; row < numRows; row++)
            {
                decryptedText[currentIndex] = matrix[row, originalIndex];
                currentIndex++;
            }
        }

        return new string(decryptedText);
    }

    static string GetMatrixDimensions(int textLength, int keyLength)
    {
        int numRows = textLength / keyLength;
        return numRows + "x" + keyLength;
    }
}

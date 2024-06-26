﻿using System.Text;

class Day1
{
    private static IEnumerable<int> ExtractDigits(IEnumerable<string> lines)
    {
        List<int> digits = new List<int>();
        foreach (string line in lines) 
        {
            var digit = new StringBuilder();
            foreach (char c in line)
            {
                if (Char.IsDigit(c))
                {
                    digit.Append(c);
                    break;
                }
            }

            char[] enil = line.ToCharArray();
            Array.Reverse(enil);
            foreach (char c in enil) 
            {
                if (Char.IsDigit(c))
                {
                    digit.Append(c);
                    break;
                }
            }

            digits.Add(Int32.Parse(digit.ToString()));
        }

        return digits;
    } 

    public static void Main(string[] args)
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day1\\Day1_inputs.txt");
        IEnumerable<int> digits = ExtractDigits(inputs);
        Console.WriteLine(digits.Sum());
    }
}
﻿using Day15;

class Day15main
{
    public static async Task Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day15\\Day15_input.txt");
        SequenceHandler sequenceHandler = new SequenceHandler();
        List<string> sequence = sequenceHandler.SetUpSequence(inputs);
        List<int> hashSequence = await sequenceHandler.HashSequence(sequence);
        Console.WriteLine(hashSequence.Sum());
    }
}
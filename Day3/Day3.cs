using Day3;
using System.Numerics;
using System.Text;

class Day3Part1
{
    public static string[] engineSchematicMatrix;
    private static List<int> ExtractNumbers()
    {
        List<int> engineCode = new List<int>();
        for (int i = 0; i < engineSchematicMatrix.Length; i++)
        {
            string schematicRow = engineSchematicMatrix[i];
            var digit = new StringBuilder();
            bool digitFound = false;
            int digitStartIndex = 0;

            for (int j = 0; j < schematicRow.Length; j++)
            {
                if (Char.IsDigit(schematicRow[j]))
                {
                    if (!digitFound)
                        digitStartIndex = j;

                    digit.Append(schematicRow[j]);
                    digitFound = true;

                    if (j + 1 == schematicRow.Length)
                    {
                        try
                        {
                            if (engineSchematicMatrix[i][digitStartIndex - 1] != '.')
                            {
                                engineCode.Add(Int32.Parse(digit.ToString()));
                            }
                        }
                        catch (Exception) { }

                        engineCode.Add(FindAdjecent(i, j, digit, digitStartIndex));

                        digitFound = false;
                        digit = new StringBuilder();
                    }
                }
                else if (digitFound)
                {
                    try
                    {
                        if (engineSchematicMatrix[i][digitStartIndex - 1] != '.' || engineSchematicMatrix[i][j] != '.')
                        {
                            engineCode.Add(Int32.Parse(digit.ToString()));
                        }
                    }
                    catch (Exception) { }

                    engineCode.Add(FindAdjecent(i, j, digit, digitStartIndex));

                    digitFound = false;
                    digit = new StringBuilder();
                }
            }
        }
        return engineCode;
    }

    private static int FindAdjecent(int level, int j, StringBuilder digit, int digitStartIndex)
    {
        for (int k = digitStartIndex - 1; k <= j; k++)
        {
            try
            {
                if (engineSchematicMatrix[level + 1][k] != '.')
                    return Int32.Parse(digit.ToString());

            }
            catch (Exception) { }
            try
            {
                if (engineSchematicMatrix[level - 1][k] != '.')
                    return Int32.Parse(digit.ToString());

            }
            catch (Exception) { }
        }
        return 0;
    }

    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day3\\Day3_inputs.txt");
        engineSchematicMatrix = input.ToArray();
        IEnumerable<int> engineCodes = ExtractNumbers();
        Console.WriteLine(engineCodes.Sum());
        new CalculateGearRatio();
    }
}

using System.Text;

class Day3
{
    private static List<int> ExtractNumbers(string[] engineSchematicMatrix)
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

                    if (j+1 == schematicRow.Length && digitFound) 
                    {
                        Console.WriteLine(Int32.Parse(digit.ToString()));
                        try
                        {
                            if (engineSchematicMatrix[i][digitStartIndex - 1] != '.')
                            {
                                engineCode.Add(Int32.Parse(digit.ToString()));
                            }

                        }
                        catch (Exception) { }

                        for (int k = digitStartIndex - 1; k <= j; k++)
                        {
                            try
                            {
                                if (engineSchematicMatrix[i + 1][k] != '.')
                                {
                                    engineCode.Add(Int32.Parse(digit.ToString()));
                                    break;
                                }
                            }
                            catch (Exception) { }
                            try
                            {
                                if (engineSchematicMatrix[i - 1][k] != '.')
                                {
                                    engineCode.Add(Int32.Parse(digit.ToString()));
                                    break;
                                }
                            }
                            catch (Exception) { }
                        }
                        digitFound = false;
                        digit = new StringBuilder();
                    }
                }
                else if (digitFound) 
                {
                    try
                    {
                        if (engineSchematicMatrix[i][digitStartIndex-1] != '.' || engineSchematicMatrix[i][j] != '.')
                        {
                            engineCode.Add(Int32.Parse(digit.ToString()));
                        }

                    }
                    catch (Exception) { }
                    
                    for (int k = digitStartIndex - 1; k <= j; k++)
                    {
                        try
                        {
                            if (engineSchematicMatrix[i + 1][k] != '.')
                            {
                                engineCode.Add(Int32.Parse(digit.ToString()));
                                break;
                            }
                        }
                        catch (Exception) { }
                        try
                        {
                            if (engineSchematicMatrix[i - 1][k] != '.')
                            {
                                engineCode.Add(Int32.Parse(digit.ToString()));
                                break;
                            }
                        }
                        catch (Exception) { }
                    }
                    digitFound = false;
                    digit = new StringBuilder();
                }
            }
        }
        return engineCode;
    }


    public static void Main(string[] args)
    {
        IEnumerable<string> engineSchematicMatrix = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day3\\Day3_inputs.txt");

        foreach (var row in engineSchematicMatrix)
        {
            Console.WriteLine(row);
        }

        IEnumerable<int> engineCodes = ExtractNumbers(engineSchematicMatrix.ToArray());

        foreach (var engineCode in engineCodes) 
        {
            Console.WriteLine(engineCode);
        }

        Console.WriteLine(engineCodes.Sum());
    }
}
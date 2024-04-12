using System.Text;

namespace Day3
{
    internal class CalculateGearRatio
    {
        private static string[] engineSchematicMatrix;
        public CalculateGearRatio() 
        {
            engineSchematicMatrix = Day3Part1.engineSchematicMatrix;

            IEnumerable<int> gearRatio = GearRatios();
            Console.WriteLine(gearRatio.Sum());
        }
        private static int BreadthSearch(string schematicRow, int index)
        {
            var digit = new StringBuilder();
            for (int i = index; i < schematicRow.Length; i++)
            {
                try
                {
                    if (Char.IsDigit(schematicRow[i]))
                        digit.Append(schematicRow[i]);

                    else
                        break;
                }
                catch (Exception) { break; }
            }

            if (0 == digit.Length) return 0;

            for (int i = index - 1; i < schematicRow.Length; i--)
            {
                try
                {
                    if (Char.IsDigit(schematicRow[i]))
                        digit.Insert(0, schematicRow[i]);

                    else
                        break;
                }
                catch (Exception) { break; }
            }
            try
            {
                return Int32.Parse(digit.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static List<int> GearRatios()
        {
            for (int i = 0; i < engineSchematicMatrix.Length; i++)
            {
                Console.WriteLine(engineSchematicMatrix[i]);
            }
            List<int> gearRatio = new List<int>();
            for (int i = 0; i < engineSchematicMatrix.Length; i++)
            {
                string schematicRow = engineSchematicMatrix[i];
                for (int j = 0; j < schematicRow.Length; j++)
                {
                    if (schematicRow[j] == '*')
                    {
                        List<int> gears = new List<int>();
                        try
                        {
                            if (Char.IsDigit(schematicRow[j - 1]))
                            {
                                gears.Add(BreadthSearch(schematicRow, j - 1));
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (Char.IsDigit(schematicRow[j + 1]))
                            {
                                gears.Add(BreadthSearch(schematicRow, j + 1));
                            }
                        }
                        catch (Exception) { }

                        for (int k = j - 1; k <= j + 1; k++)
                        {
                            try
                            {
                                if (Char.IsDigit(engineSchematicMatrix[i - 1][k]))
                                {
                                    gears.Add(BreadthSearch(engineSchematicMatrix[i - 1], k));
                                    if (engineSchematicMatrix[i - 1][k + 1] != '.')
                                        break;
                                }
                            }
                            catch (Exception) { }
                        }
                        for (int k = j - 1; k <= j + 1; k++)
                        {
                            try
                            {
                                if (Char.IsDigit(engineSchematicMatrix[i + 1][k]))
                                {
                                    gears.Add(BreadthSearch(engineSchematicMatrix[i + 1], k));
                                    if (engineSchematicMatrix[i + 1][k + 1] != '.')
                                        break;
                                }
                            }
                            catch (Exception) { }
                        }

                        if (gears.Count() == 2)
                        {
                            int ratio = gears.Aggregate((a, b) => a * b);
                            gearRatio.Add(ratio);
                        }
                    }
                }
            }
            return gearRatio;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9;

internal class LackOfCreativity
{

    public static IEnumerable<int> FindNextInPattern(IEnumerable<int> pattern)
    {
        IEnumerable<int> newPattern = new List<int>();

        foreach (int index in pattern)
        {
            Console.Write(index + ", ");
        }

        return newPattern;
    }
}


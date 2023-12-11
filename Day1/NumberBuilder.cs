using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public static class NumberBuilder
    {
        public static IEnumerable<int> BuildTwoDigitNumbers(IEnumerable<(int first, int last)> digitPairs)
        {
            var output = new List<int>();

            foreach (var digitPair in digitPairs) 
            {
                var twoDigitNumber = (digitPair.first * 10) + digitPair.last;
                output.Add(twoDigitNumber);
            }

            return output;
        }
    }
}

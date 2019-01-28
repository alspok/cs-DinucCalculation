using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculation
{
    class Rrogram26
    {
        static void Main()
        {

            var testTuple = new Tuple<int, string, string, double>(1, "one", "two", (double)2);
            var testString = testTuple.ToString();
            char[] trimChars = { '(', ')' };
            testString = testString.Trim(trimChars);
            Console.WriteLine(testTuple);
            Console.WriteLine(testString);

            var testListTuple = new List<Tuple<string, int, string, double>>();
            testListTuple.Add(Tuple.Create("one", 1, "another one", (double)1));
            testListTuple.Add(Tuple.Create("two", 2, "another two", (double)2));

            foreach(var listItem in testListTuple)
            {
                string textItem = listItem.ToString();
                Console.WriteLine(textItem.Trim(trimChars));
            }
            EndRun.End();
        }
    }
}

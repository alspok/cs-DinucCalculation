/*******************************************************************
 *                                                                 * 
 * Class calculates probabilities of dinucleotides in second frame *
 * from probabilities of dinucleotides in first frame.             *
 *                                                                 *
 * *****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bio.Extensions;

namespace DinucCalculation
{
    class DinucProbCalc
    {
        public struct dinucProb
        {
            public string firstDinuc;
            public double firstDinucFrq;
            public string secondDinuc;
            public double secondDinucFrq;
        };

        public List<Tuple<string, double, double, double>> DinucProbInit(List<Tuple<string, int, int, double, double>> _dinucFrqTable)
        {
            var dinucFrqTable = _dinucFrqTable;

            dinucProb[] dinucProbArray = new dinucProb[]
            {
                 new dinucProb { firstDinuc = "aa", firstDinucFrq = (double)0, secondDinuc = "aa", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ca", firstDinucFrq = (double)0, secondDinuc = "ac", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ga", firstDinucFrq = (double)0, secondDinuc = "ag", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ta", firstDinucFrq = (double)0, secondDinuc = "at", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "aa", firstDinucFrq = (double)0, secondDinuc = "ca", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ca", firstDinucFrq = (double)0, secondDinuc = "cc", secondDinucFrq = (double)0} ,
                 new dinucProb { firstDinuc = "ga", firstDinucFrq = (double)0, secondDinuc = "cg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ta", firstDinucFrq = (double)0, secondDinuc = "ct", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "aa", firstDinucFrq = (double)0, secondDinuc = "ga", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ca", firstDinucFrq = (double)0, secondDinuc = "gc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ga", firstDinucFrq = (double)0, secondDinuc = "gg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ta", firstDinucFrq = (double)0, secondDinuc = "gt", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "aa", firstDinucFrq = (double)0, secondDinuc = "ta", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ca", firstDinucFrq = (double)0, secondDinuc = "tc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ga", firstDinucFrq = (double)0, secondDinuc = "tg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ta", firstDinucFrq = (double)0, secondDinuc = "tt", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ac", firstDinucFrq = (double)0, secondDinuc = "aa", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cc", firstDinucFrq = (double)0, secondDinuc = "ac", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gc", firstDinucFrq = (double)0, secondDinuc = "ag", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tc", firstDinucFrq = (double)0, secondDinuc = "at", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ac", firstDinucFrq = (double)0, secondDinuc = "ca", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cc", firstDinucFrq = (double)0, secondDinuc = "cc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gc", firstDinucFrq = (double)0, secondDinuc = "cg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tc", firstDinucFrq = (double)0, secondDinuc = "ct", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ac", firstDinucFrq = (double)0, secondDinuc = "ga", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cc", firstDinucFrq = (double)0, secondDinuc = "gc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gc", firstDinucFrq = (double)0, secondDinuc = "gg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tc", firstDinucFrq = (double)0, secondDinuc = "gt", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ac", firstDinucFrq = (double)0, secondDinuc = "ta", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cc", firstDinucFrq = (double)0, secondDinuc = "tc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gc", firstDinucFrq = (double)0, secondDinuc = "tg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tc", firstDinucFrq = (double)0, secondDinuc = "tt", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ag", firstDinucFrq = (double)0, secondDinuc = "aa", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cg", firstDinucFrq = (double)0, secondDinuc = "ac", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gg", firstDinucFrq = (double)0, secondDinuc = "ag", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tg", firstDinucFrq = (double)0, secondDinuc = "at", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ag", firstDinucFrq = (double)0, secondDinuc = "ca", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cg", firstDinucFrq = (double)0, secondDinuc = "cc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gg", firstDinucFrq = (double)0, secondDinuc = "cg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tg", firstDinucFrq = (double)0, secondDinuc = "ct", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ag", firstDinucFrq = (double)0, secondDinuc = "ga", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cg", firstDinucFrq = (double)0, secondDinuc = "gc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gg", firstDinucFrq = (double)0, secondDinuc = "gg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tg", firstDinucFrq = (double)0, secondDinuc = "gt", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "ag", firstDinucFrq = (double)0, secondDinuc = "ta", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "cg", firstDinucFrq = (double)0, secondDinuc = "tc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gg", firstDinucFrq = (double)0, secondDinuc = "tg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tg", firstDinucFrq = (double)0, secondDinuc = "tt", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "at", firstDinucFrq = (double)0, secondDinuc = "aa", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ct", firstDinucFrq = (double)0, secondDinuc = "ac", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gt", firstDinucFrq = (double)0, secondDinuc = "ag", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tt", firstDinucFrq = (double)0, secondDinuc = "at", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "at", firstDinucFrq = (double)0, secondDinuc = "ca", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ct", firstDinucFrq = (double)0, secondDinuc = "cc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gt", firstDinucFrq = (double)0, secondDinuc = "cg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tt", firstDinucFrq = (double)0, secondDinuc = "ct", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "at", firstDinucFrq = (double)0, secondDinuc = "ga", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ct", firstDinucFrq = (double)0, secondDinuc = "gc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gt", firstDinucFrq = (double)0, secondDinuc = "gg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tt", firstDinucFrq = (double)0, secondDinuc = "gt", secondDinucFrq = (double)0 },

                 new dinucProb { firstDinuc = "at", firstDinucFrq = (double)0, secondDinuc = "ta", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "ct", firstDinucFrq = (double)0, secondDinuc = "tc", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "gt", firstDinucFrq = (double)0, secondDinuc = "tg", secondDinucFrq = (double)0 },
                 new dinucProb { firstDinuc = "tt", firstDinucFrq = (double)0, secondDinuc = "tt", secondDinucFrq = (double)0 }
            };

            foreach(var item1 in dinucFrqTable)
            {
                for(int i = 0; i < dinucProbArray.Length; i++)
                {
                    if (item1.Item1 == dinucProbArray[i].firstDinuc) dinucProbArray[i].firstDinucFrq = item1.Item4;
                    if (item1.Item1 == dinucProbArray[i].secondDinuc) dinucProbArray[i].secondDinucFrq = item1.Item4;
                }
            }
/*
            for (int m = 0; m < dinucProbArray.Length; m++)
                {
                Console.WriteLine(dinucProbArray[m].firstDinuc + "\t" + dinucProbArray[m].firstDinucFrq.ToString() + "\t" +
                                  dinucProbArray[m].secondDinuc + "\t" + dinucProbArray[m].secondDinucFrq.ToString());
                if ((m + 1) % 4 == 0) Console.WriteLine();
                }
*/
            List<double> probSecond = new List<double>();
            double probFrq = 0;
            int tmpj = 0;
            int nr = 1;
            for(int j = 0; j < dinucProbArray.Length; j++)
            {
                if (j % 4 == 0) { tmpj = j; }
                for (int k = tmpj; k < tmpj + 4; k++)
                {
                    probFrq += dinucProbArray[j].firstDinucFrq * dinucProbArray[k].secondDinucFrq;
/*                    Console.WriteLine(nr + "\t" +
                                      "j = " + j + "\t" + dinucProbArray[j].firstDinucFrq + "\t" + dinucProbArray[k].secondDinucFrq + "\t" +
                                      "k = " + k + "\t" + dinucProbArray[j].firstDinucFrq * dinucProbArray[k].secondDinucFrq + "\t" +
                                      probFrq);
*/
                    if (nr++ % 16 == 0) { probSecond.Add(probFrq); probFrq = 0; }
                }
            }

            List<Tuple<string, double, double, double>> diDoubleFrq = new List<Tuple<string, double, double, double>>();
            int m = 0;
            foreach (var item in dinucFrqTable)
            {
                diDoubleFrq.Add(Tuple.Create(item.Item1, item.Item4, item.Item5, probSecond[m++]));
            }

            return diDoubleFrq;
        }


        public void DinucProbOutput(List<Tuple<string, double, double, double>> _dinucSecondFrq, string _rowcoldiff)
        {
            var dinucSecondFrq = _dinucSecondFrq;
            var rowcoldiff = _rowcoldiff;

            if (rowcoldiff == "col")
            {
                double realDiff = 0;
                double probDiff = 0;
                foreach (var item in dinucSecondFrq)
                {
                    Console.WriteLine(item.Item1 + "\t" +
                                      item.Item2.ToString("0.00000") + "\t" +
                                      item.Item3.ToString("0.00000") + "\t" +
                                      Math.Abs(item.Item2 - item.Item3).ToString("0.00000") + "\t" +
                                      item.Item4.ToString("0.00000") + "\t" +
                                      Math.Abs(item.Item2 - item.Item4).ToString("0.00000")
                                      );
                    realDiff += Math.Abs(item.Item2 - item.Item3);
                    probDiff += Math.Abs(item.Item2 - item.Item4);
                }
                Console.WriteLine("\n\t\t\t\t\tReal diff: " + realDiff.ToString("0.00000"));
                Console.WriteLine("\t\t\t\t\tProb diff: " + probDiff.ToString("0.00000") + "\n");
            }

            if(rowcoldiff == "row")
            {
                double realDiff = 0;
                double probDiff = 0;
                foreach (var item1 in dinucSecondFrq) Console.Write(item1.Item1 + "\t"); Console.WriteLine("\n");
                foreach (var item1 in dinucSecondFrq) Console.Write(item1.Item2.ToString("0.00000") + "\t"); Console.WriteLine("\n");
                foreach (var item1 in dinucSecondFrq) Console.Write(item1.Item3.ToString("0.00000") + "\t"); Console.WriteLine();
                foreach (var item1 in dinucSecondFrq)
                {
                    realDiff += Math.Abs(item1.Item2 - item1.Item3);
                    Console.Write(Math.Abs(item1.Item2 - item1.Item3).ToString("0.00000") + "\t");
                }
                Console.WriteLine(realDiff.ToString("0.00000") + "\n");
                foreach (var item1 in dinucSecondFrq) Console.Write(item1.Item4.ToString("0.00000") + "\t"); Console.WriteLine();
                foreach (var item1 in dinucSecondFrq)
                {
                    probDiff += Math.Abs(item1.Item2 - item1.Item4);
                    Console.Write(Math.Abs(item1.Item2 - item1.Item4).ToString("0.00000") + "\t");
                }
                Console.WriteLine(probDiff.ToString("0.00000"));
                Console.WriteLine();
            }

            if (rowcoldiff == "diff")
            {
                double realDiff = 0;
                double probDiff = 0;
                foreach(var item1 in dinucSecondFrq)
                {
                    realDiff += Math.Abs(item1.Item2 - item1.Item3);
                    probDiff += Math.Abs(item1.Item2 - item1.Item4);
                }
                Console.WriteLine("\t\tReal diff: " + realDiff.ToString("0.00000") + "\t" + 
                                  "Prob diff: " + probDiff.ToString("0.00000"));
            }
        }
    }
}


            

        
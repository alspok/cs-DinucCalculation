using System;
using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;
using DinucCalculation;

namespace Dinuc1
{
    class Class1
    {
        public class DinucDiff
        {
            public string dinucleotide { get; set; }
            public int dinucleotideDiff { get; set; }
        }

        static void Main()
        {
            string seq = "cggtagagctggtgatgcggatgacagatgcgatgcagtttacataacgt";
            Console.WriteLine(seq + "\n");

            MonoDiCalc dinucCalc = new MonoDiCalc();
            var dinuc = dinucCalc.DiCalcReturn(seq);

            List<DinucDiff> dinucDiff = new List<DinucDiff>();

            foreach(var item in dinuc)
            {
                dinucDiff.Add(new DinucDiff { dinucleotide = item.Item1, dinucleotideDiff = item.Item2 - item.Item3 });
            }

            foreach(var item in dinucDiff) Console.Write(item.dinucleotide + "\t");
            Console.WriteLine();
            foreach (var item in dinucDiff) Console.Write(item.dinucleotideDiff + "\t");
            Console.WriteLine("\n\n");

            //dinucDiff = dinucDiff.OrderBy(x => x.dinucleotideDiff).ToList();
            dinucDiff = dinucDiff.OrderByDescending(x => x.dinucleotideDiff).ToList();
            foreach (var item in dinucDiff)
            {
                if(item.dinucleotideDiff != 0)
                {
                    Console.Write(item.dinucleotide + "\t");
                }
            }
            Console.WriteLine();
            foreach (var item in dinucDiff)
            {
                if (item.dinucleotideDiff != 0)
                {
                    Console.Write(item.dinucleotideDiff + "\t");
                }
            }

            List<string> dinucList = new List<string>();
            foreach (var item in dinucDiff)
            {
                if (item.dinucleotideDiff < 0) dinucList.Add(item.dinucleotide);
            }
            Console.WriteLine();

            var permutateDinuc = new Variations <string>(dinucList, 2, GenerateOption.WithRepetition);
            foreach (var item in permutateDinuc) Console.WriteLine(string.Join("", item));

            EndRun.End();
        }
    }
}

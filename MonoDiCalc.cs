using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DinucCalculation
{
    public class MonoDiCalc
    {
        public MonoDiCalc() { }
        public MonoDiCalc(string _seq) { }
        public MonoDiCalc(string _seq, int _seqLength) { }

        public string[] monoNucArray = { "a", "c", "g", "t" };
        public string[] diNucArray = { "aa", "ac", "ag", "at",
                                       "ca", "cc", "cg", "ct",
                                       "ga", "gc", "gg", "gt",
                                       "ta", "tc", "tg", "tt" };
        
        // Mononucleotides a, c, g, t calculation in seq
        public void MonoCalc(string _seq)
        {
            string seq = _seq.ToLower();

            var seqFragLength = seq.Length;

            List<Tuple<string, int>> mono = new List<Tuple<string, int>>();

            foreach(string str in monoNucArray)
            {
                int matchCount = 0;
                foreach (Match match in Regex.Matches(seq, str)) matchCount += 1;
                mono.Add(Tuple.Create(str, matchCount));
            }
            foreach (var item in mono) Console.Write(item.Item1 + "\t");
            Console.WriteLine();
            foreach (var item in mono) Console.Write(item.Item2 + "\t");
            Console.WriteLine();
            foreach (var item in mono) Console.Write(((double)item.Item2 / (double)seq.Length).ToString("0.0000") + "\t");
            Console.WriteLine();
        }

        //Mononucleotides a, c, g, t frq calculation in part of seq according to whole seq
        public void MonoCalc(string _seq, int _seqLength)
        {
            string seq = _seq.ToLower();
            int seqLength = _seqLength;

            List<Tuple<string, int>> mono = new List<Tuple<string, int>>();

            foreach (string str in monoNucArray)
            {
                int matchCount = 0;
                foreach (Match match in Regex.Matches(seq, str)) matchCount += 1;
                mono.Add(Tuple.Create(str, matchCount));
            }
            foreach (var item in mono) Console.Write(item.Item1 + "\t");
            Console.WriteLine();
            foreach (var item in mono) Console.Write(item.Item2 + "\t");
            Console.WriteLine();
            foreach (var item in mono) Console.Write(((double)item.Item2 / (double)seqLength).ToString("0.0000") + "\t");
            Console.WriteLine();
        }
        
        // Mononucleotides a, c, g, t calculation in seq. Return rezults in List<Tuple<>>.
        public List<Tuple<string, int, double>> MonoCalcReturn(string _seq)
        {
            string seq = _seq.ToLower();

            List<Tuple<string, int, double>> mono = new List<Tuple<string, int, double>>();

            foreach (string str in monoNucArray)
            {
                int matchCount = 0;
                foreach (Match match in Regex.Matches(seq, str)) matchCount += 1;
                mono.Add(Tuple.Create(str, matchCount, (double)matchCount / (double)seq.Length));
            }
            return mono;
        }

        // Dinucleotides calculation in seq. in two frames.
        public void DiCalc(string _seq)
        {
            string seq = _seq;

            List<Tuple<string, int, int, double, double>> di = new List<Tuple<string, int, int, double, double>>();

            foreach(string str in diNucArray)
            {
                int matchCount1st = 0;
                int matchCount2nd = 0;
                double matchFrq1st = 0;
                double matchFrq2nd = 0;
                int index = 0;
                do
                {
                    index = seq.IndexOf(str, index);
                    if (index != -1)
                    {
                        if (index % 2 == 0) matchCount1st += 1;
                        else matchCount2nd += 1;
                        index++;
                    }
                } while (index != -1);

                matchFrq1st = (double)matchCount1st / ((double)seq.Length / (double)str.Length);
                matchFrq2nd = (double)matchCount2nd / ((double)seq.Length / (double)str.Length);
                di.Add(Tuple.Create(str, matchCount1st, matchCount2nd, matchFrq1st, matchFrq2nd));
            }
            foreach (var item in di) Console.Write(item.Item1 + "\t");
            Console.WriteLine();
            foreach (var item in di) Console.Write(item.Item2 + "\t");
            Console.WriteLine();
            foreach (var item in di) Console.Write(item.Item3 + "\t");
            Console.WriteLine();
            foreach (var item in di) Console.Write(item.Item2 - item.Item3 + "\t");
            Console.WriteLine("\n");
            foreach (var item in di) Console.Write((item.Item4.ToString("0.0000") + "\t"));
            Console.WriteLine();
            foreach (var item in di) Console.Write((item.Item5.ToString("0.0000") + "\t"));
            Console.WriteLine();
            foreach (var item in di) Console.Write((item.Item4 - item.Item5).ToString("0.0000") + "\t");
            Console.WriteLine();
        }

        public List<Tuple<string, int, int, double, double>> DiCalcReturn(string _seq)
        {
            string seq = _seq.ToLower();

            List<Tuple<string, int, int, double, double>> di = new List<Tuple<string, int, int, double, double>>();

            foreach (string str in diNucArray)
            { 
                int matchCount1st = 0;
                int matchCount2nd = 0;
                double matchFrq1st = 0;
                double matchFrq2nd = 0;
                int index = 0;
                do
                {
                    index = seq.IndexOf(str, index);
                    if (index != -1)
                    {
                        if (index % 2 == 0) matchCount1st += 1;
                        else matchCount2nd += 1;
                        index++;
                    }
                } while (index != -1);

                matchFrq1st = (double)matchCount1st / ((double)seq.Length / (double)str.Length);
                matchFrq2nd = (double)matchCount2nd / ((double)seq.Length / (double)str.Length);
                di.Add(Tuple.Create(str, matchCount1st, matchCount2nd, matchFrq1st, matchFrq2nd));
            }
            return di;
        }

        public List<Tuple<string, int, int, int, double, double, double>> DiCalcReturnDiff(string _seq)
        {
            string seq = _seq.ToLower();

            List<Tuple<string, int, int, int, double, double, double>> di = new List<Tuple<string, int, int, int, double, double, double>>();

            foreach (string str in diNucArray)
            {
                int matchCount1st = 0;
                int matchCount2nd = 0;
                double matchFrq1st = 0;
                double matchFrq2nd = 0;
                int index = 0;
                do
                {
                    index = seq.IndexOf(str, index);
                    if (index != -1)
                    {
                        if (index % 2 == 0) matchCount1st += 1;
                        else matchCount2nd += 1;
                        index++;
                    }
                } while (index != -1);

                matchFrq1st = (double)matchCount1st / ((double)seq.Length / (double)str.Length);
                matchFrq2nd = (double)matchCount2nd / ((double)seq.Length / (double)str.Length);
                di.Add(Tuple.Create(str,
                                    matchCount1st,
                                    matchCount2nd,
                                    matchCount1st - matchCount2nd,
                                    matchFrq1st, matchFrq2nd,
                                    matchFrq1st - matchFrq2nd));
            }
            return di;
        }

        public List<Tuple<string, int, int, double, double>> DiCalcReturnCircle (string _seq)
        {
            string seq = _seq.ToLower();
            double seqLength = seq.Length;

            if (seq.Length % 2 == 0)
            {
                seq = seq + seq.Substring(0, 1);
                seqLength = seq.Length - 1;
            }

            List<Tuple<string, int, int, double, double>> di = new List<Tuple<string, int, int, double, double>>();

            foreach (string str in diNucArray)
            {
                int matchCount1st = 0;
                int matchCount2nd = 0;
                double matchFrq1st = 0;
                double matchFrq2nd = 0;
                int index = 0;
                do
                {
                    index = seq.IndexOf(str, index);
                    if (index != -1)
                    {
                        if (index % 2 == 0) matchCount1st += 1;
                        else matchCount2nd += 1;
                        index++;
                    }
                } while (index != -1);

                matchFrq1st = (double)matchCount1st / ((double)seqLength / (double)str.Length);
                matchFrq2nd = (double)matchCount2nd / ((double)seqLength / (double)str. Length);
                di.Add(Tuple.Create(str, matchCount1st, matchCount2nd, matchFrq1st, matchFrq2nd));
            }
            return di;
        }

        public List<Tuple<string, int, int, int, double, double, double>> DiCalcReturnCircleDiff(string _seq)
        {
            string seq = _seq.ToLower();
            double seqLength = seq.Length;

            if (seq.Length % 2 == 0)
            {
                seq = seq + seq.Substring(0, 1);
                seqLength = seq.Length - 1;
            }

            List<Tuple<string, int, int, int, double, double, double>> di = new List<Tuple<string, int, int, int, double, double, double>>();

            foreach (string str in diNucArray)
            {
                int matchCount1st = 0;
                int matchCount2nd = 0;
                double matchFrq1st = 0;
                double matchFrq2nd = 0;
                int index = 0;
                do
                {
                    index = seq.IndexOf(str, index);
                    if (index != -1)
                    {
                        if (index % 2 == 0) matchCount1st += 1;
                        else matchCount2nd += 1;
                        index++;
                    }
                } while (index != -1);

                matchFrq1st = (double)matchCount1st / ((double)seqLength / (double)str.Length);
                matchFrq2nd = (double)matchCount2nd / ((double)seqLength / (double)str.Length);
                di.Add(Tuple.Create(str,
                                    matchCount1st,
                                    matchCount2nd,
                                    matchCount1st - matchCount2nd,
                                    matchFrq1st,
                                    matchFrq2nd,
                                    matchFrq1st - matchFrq2nd));
            }
            return di;
        }

        public Tuple<int, double> DiDiffReturn(List<Tuple<string, int, int, double, double>> _di)
        {
            var di = _di;
            Tuple<int, double> diff;

            int diffSum = 0;
            double diffFrqSum = 0;

            foreach(var item in di)
            {
                diffSum += Math.Abs(item.Item2 - item.Item3);
                diffFrqSum += Math.Abs(item.Item4 - item.Item5);
            }

            diff = Tuple.Create(diffSum, diffFrqSum);

            return diff;
        }
    }
}

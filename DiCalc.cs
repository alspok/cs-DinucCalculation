/* Dinucleotides calculation in two frames.
 * Dinuc count, frq, differences, sum of frq differences.
 * void DinucCalcPrint() - console output.
 * List<> DinucCalcOut() - table output.
 * void DinucCalcDiffSum() - dinuc diff console output.
 * void DinucCalcFrqDiffSum() - dinuc frq diff console output.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculation
{
    public class DiCalc
    {
        public string dinuc { get; set; }
        public int[] dinucCount { get; set; }
        public double[] dinucFrq { get; set; }
    }

    public class DinuCalc
    {
        public List<DiCalc> diCalcList = new List<DiCalc>();

        public List<DiCalc> DinucCalc(string _seq)
        {
            string seq = _seq;
            string seq1stFrame = string.Empty;
            string seq2ndFrame = string.Empty;
            int seqLength = 0;
            string[] dinucleotides = { "aa", "ac", "ag", "at", "ca", "cc", "cg", "ct", "ga", "gc", "gg", "gt", "ta", "tc", "tg", "tt" };

            if(seq.Length % 2 == 0)
            {
                seq1stFrame = seq;
                string seq1stNuc = seq.Substring(0, 1);
                seq2ndFrame = seq.Remove(0, 1) + seq1stNuc;
                seqLength = seq.Length / 2;
            }
            else
            {
                seq1stFrame = seq.Substring(0, seq.Length - 1);
                seq2ndFrame = seq.Remove(0, 1);
                seqLength = (seq.Length - 1) / 2;
            }

            double dinucFrqDiffSum = 0;
            foreach (var item in dinucleotides)
            {
                int dinuc1stFrame = 0;
                int dinuc2ndFrame = 0;

                for (int i = 0; i < seq1stFrame.Length; i += 2)
                {
                    if (item == seq1stFrame.Substring(i, 2)) dinuc1stFrame++;
                }
                
                for (int i = 0; i < seq2ndFrame.Length; i += 2)
                {
                    if (item == seq2ndFrame.Substring(i, 2)) dinuc2ndFrame++;
                }
                

                int[] diCount = new int[] { dinuc1stFrame, dinuc2ndFrame, dinuc1stFrame - dinuc2ndFrame };
                double[] diFrq = new double[]
                    {
                        (double)dinuc1stFrame / seqLength,
                        (double)dinuc2ndFrame / seqLength,
                        ((double)dinuc1stFrame / (double)seqLength) - ((double)dinuc2ndFrame / (double)seqLength)
                    };
                dinucFrqDiffSum += Math.Abs(((double)dinuc1stFrame / (double)seqLength) - ((double)dinuc2ndFrame / (double)seqLength));

                diCalcList.Add(new DiCalc() {dinuc = item, dinucCount = diCount, dinucFrq = diFrq});
            }
            /*
            foreach (var item in diCalcList) Console.Write(item.dinuc + "\t"); Console.WriteLine("\n");

            foreach (var item in diCalcList) Console.Write(item.dinucCount[0] + "\t"); Console.WriteLine();
            foreach (var item in diCalcList) Console.Write(item.dinucCount[1] + "\t"); Console.WriteLine();
            foreach (var item in diCalcList) Console.Write(item.dinucCount[2] + "\t"); Console.WriteLine();

            foreach (var item in diCalcList) Console.Write(item.dinucFrq[0].ToString("0.0000") + "\t"); Console.WriteLine();
            foreach (var item in diCalcList) Console.Write(item.dinucFrq[1].ToString("0.0000") + "\t"); Console.WriteLine();
            foreach (var item in diCalcList) Console.Write(item.dinucFrq[2].ToString("0.0000") + "\t"); Console.WriteLine("\n");
            
            Console.WriteLine("\n" + "DinucFrqDiffSum: " + dinucFrqDiffSum.ToString("0.0000") + "\n");
            */
            return diCalcList;
        }



        public static void DinucCalcPrint(string _seq)
        {
            string seq = _seq.ToLower();

            var di = new DinuCalc();
            var diList = di.DinucCalc(seq);

            foreach (var item in diList) Console.Write(item.dinuc + "\t"); Console.WriteLine("\n");

            foreach (var item in diList) Console.Write(item.dinucCount[0] + "\t"); Console.WriteLine();
            foreach (var item in diList) Console.Write(item.dinucCount[1] + "\t"); Console.WriteLine();
            foreach (var item in diList) Console.Write(item.dinucCount[2] + "\t"); Console.WriteLine();

            foreach (var item in diList) Console.Write(item.dinucFrq[0].ToString("0.0000") + "\t"); Console.WriteLine();
            foreach (var item in diList) Console.Write(item.dinucFrq[1].ToString("0.0000") + "\t"); Console.WriteLine();
            foreach (var item in diList) Console.Write(item.dinucFrq[2].ToString("0.0000") + "\t"); Console.WriteLine("\n");
        }

        public static List<DiCalc> DinucCalcOut(string _seq)
        {
            string seq = _seq.ToLower();
            var di = new DinuCalc();

            var diList = di.DinucCalc(seq);

            return diList;
        }

        public static void DinucCalcDiffSum(string _seq)
        {
            string seq = _seq.ToLower();
            int diCountSum = 0;
            var di = new DinuCalc();

            var diList = di.DinucCalc(seq);
            foreach(var item in diList)
            {
                diCountSum += Math.Abs(item.dinucCount[2]);
            }
            Console.WriteLine("\nDinuc diff sum: " + diCountSum.ToString());
        }

        public static void DinucCalcFrqDiffSum(string _seq)
        {
            string seq = _seq.ToLower();
            double diFrqSum = 0;
            var di = new DinuCalc();

            var diList = di.DinucCalc(seq);
            foreach(var item in diList)
            {
                diFrqSum += Math.Abs(item.dinucFrq[2]);
            }
            Console.WriteLine("\nDinuc frq diff sum: " + diFrqSum.ToString("0.0000"));
        }

        public static double DinucCalcFrqDiffSumOut (string _seq)
        {
            string seq = _seq.ToLower();
            double diFrqSum = 0;
            var di = new DinuCalc();

            var diList = di.DinucCalc(seq);
            foreach (var item in diList)
            {
                diFrqSum += Math.Abs(item.dinucFrq[2]);
            }
            return diFrqSum;
        }
    }
}
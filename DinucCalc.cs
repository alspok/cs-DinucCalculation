using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculation
{
    class DinucCalculation
    {
        public DinucCalculation() { }
        public DinucCalculation(string _seq) { }

        public struct DinucStruct
        {
            
            public string dinuc;
            public int[] dinucCount;
            public int dinucCountSum;
            public float[] dinucFrq;
            public float dinucFrqSum;

            public DinucStruct (string _dinuc, int[] _dinucCount, int _dinucCountSum, float[] _dinucFrq, float _dinucFrqSum)
            {
                dinuc = _dinuc;
                dinucCount = _dinucCount;
                dinucCountSum = _dinucCountSum;
                dinucFrq = _dinucFrq;
                dinucFrqSum = _dinucFrqSum;
            }
        }

        //Dinuc count and freq calculation in two dinuc frames.
        public DinucStruct[] dinucStr = new DinucStruct[]
        {
            new DinucStruct ("aa", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("ac", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("ag", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("at", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
                                                                                       
            new DinucStruct ("ca", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("cc", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("cg", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("ct", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
                                                                                       
            new DinucStruct ("ga", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("gc", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("gg", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("gt", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
                                                                                       
            new DinucStruct ("ta", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("tc", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("tg", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
            new DinucStruct ("tt", new int[] { 0, 0, 0 }, 0, new float[] { 0F, 0F, 0F }, 0F),
        };

        //Dinuc count and frq in twq dinuc frames calculation.
        public DinucStruct[] DinucCalc(string _seq)
        {
            string seq = _seq;
            int dinucLength = seq.Length / 2;

            if (seq.Length % 2 != 0)
            {
                seq = seq.Remove(seq.Length - 1);
            }
            
            seq = string.Concat(seq, "**");
            while (seq.Length > 2)
            {
                string dinucFirst = seq.Remove(2);
                foreach (var item in dinucStr)
                {
                    if (dinucFirst == item.dinuc)
                    {
                        item.dinucCount[0] += 1;
                        item.dinucFrq[0] = (float) item.dinucCount[0] / dinucLength;
                    }
                }
                seq = seq.Substring(2);
                int length = seq.Length;
            }

            seq = _seq;
            if (seq.Length % 2 != 0)
            {
                seq = seq.Remove(seq.Length - 1);
            }

            string nuc = seq.Substring(0, 1);

            seq = seq.Substring(1, seq.Length - 1);
            seq = string.Concat(seq, nuc);
            seq = string.Concat(seq, "**");
            
            while (seq.Length > 2)
            {
                string dinucSecond = seq.Remove(2);
                foreach (var item in dinucStr)
                {
                    if (dinucSecond == item.dinuc)
                    {
                        item.dinucCount[1] += 1;
                        item.dinucFrq[1] = (float)item.dinucCount[1] / dinucLength;
                    }
                }
                seq = seq.Substring(2);
                int length = seq.Length;
            }

            foreach (var item in dinucStr)
            {
                item.dinucCount[2] = Math.Abs(item.dinucCount[0] - item.dinucCount[1]);
                item.dinucFrq[2] = Math.Abs(item.dinucFrq[0] - item.dinucFrq[1]);
            }

            return dinucStr;
        }

    //Dinuc count and frq difference sum calculation.
    public Tuple<int, float> DinucDiffSum(DinucStruct[] _dinucStr)
        {
            var dinucStr = _dinucStr;
            int countDiffSum = 0;
            float frqDiffSum = 0;

            foreach (var item in dinucStr)
            {
                countDiffSum += item.dinucCount[2];
                frqDiffSum += item.dinucFrq[2];
            }

            return new Tuple<int, float>(countDiffSum, frqDiffSum);
        }

        // Dinuc struct printout.
        public void PrintDinucTable(DinucStruct[] diStruct)
        {
            foreach (var item in diStruct)
            {
                Console.Write(item.dinuc + "\t");
            }
            Console.WriteLine("\n");

            foreach (var item in diStruct)
            {
                Console.Write(item.dinucCount[0].ToString() + "\t");
            }
            Console.WriteLine();

            foreach (var item in diStruct)
            {
                Console.Write(item.dinucCount[1].ToString() + "\t");
            }
            Console.WriteLine();

            foreach (var item in diStruct)
            {
                Console.Write(item.dinucCount[2].ToString() + "\t");
            }
            Console.WriteLine("\n");

            foreach (var item in diStruct)
            {
                Console.Write(item.dinucFrq[0].ToString("0.0000") + "\t");
            }
            Console.WriteLine();

            foreach (var item in diStruct)
            {
                Console.Write(item.dinucFrq[1].ToString("0.0000") + "\t");
            }
            Console.WriteLine();

            foreach (var item in diStruct)
            {
                Console.Write(item.dinucFrq[2].ToString("0.0000") + "\t");
            }
            Console.WriteLine();

            int dinucCountDiffSum = 0;
            float dinucFrqDiffSum = 0;
            foreach (var item in diStruct)
            {
                dinucCountDiffSum += item.dinucCount[2];
                dinucFrqDiffSum += item.dinucFrq[2];
            }
            Console.WriteLine();
            Console.WriteLine("Dinuc diff count sum: " + dinucCountDiffSum.ToString());
            Console.WriteLine("Dinuc diff frq sum: " + dinucFrqDiffSum.ToString("0.000000"));
            Console.WriteLine();
        }
    }
}

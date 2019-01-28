using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculation
{
    public class DinucCountCalc
    {
        public Dictionary<string, int[]> dinucTable;
        
        public DinucCountCalc()
        {
            Dictionary<string, int[]> _dinucTable = new Dictionary<string, int[]>();

            _dinucTable.Add("aa", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("ac", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("ag", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("at", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("ca", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("cc", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("cg", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("ct", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("ga", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("gc", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("gg", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("gt", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("ta", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("tc", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("tg", new int[]{ 0, 0, 0, 0 });
            _dinucTable.Add("tt", new int[]{ 0, 0, 0, 0 });

            dinucTable = _dinucTable;
        }

        public void DinucCount (string seqIn)
        {

            string seq = seqIn;
            if (seq.Length % 2 != 0)
            {
                seq = seq.Remove(seq.Length - 1);
            }

            int seqDinucLength = seq.Length / 2;

            seq = string.Concat(seq, "**");                     //Dinuc count in first frame.
            List<string> dinucListFirst = new List<string>();
            while (seq.Length != 2)
            {
                string dinuc = seq.Remove(2);
                dinucListFirst.Add(dinuc);
                seq = seq.Substring(2);
                int length = seq.Length;
            }

            foreach (var dinucTableKey in dinucTable)
            {
                foreach (var item in dinucListFirst)
                {
                    if (item == dinucTableKey.Key)
                    {
                        dinucTableKey.Value[0] += 1;
                    }
                }
            }

            seq = seqIn;                                        //Dinuc count in second frame.
            if (seq.Length % 2 != 0)
            {
                seq = seq.Remove(seq.Length - 1);
            }

            string nuc = seq.Substring(0, 1);
            
            seq = seq.Substring(1, seq.Length - 1);
            seq = string.Concat(seq, nuc);

            seq = string.Concat(seq, "**");
            List<string> dinucListSecond = new List<string>();
            while (seq.Length != 2)
            {
                string dinuc = seq.Remove(2);
                dinucListSecond.Add(dinuc);
                seq = seq.Substring(2);
                int length = seq.Length;
            }

            foreach (var dinucTableKey in dinucTable)
            {
                foreach (var dinu in dinucListSecond)
                {
                    if (dinu == dinucTableKey.Key)
                    {
                        dinucTableKey.Value[1] += 1;
                    }
                }
            }

            foreach (var diff in dinucTable)                        //Dinuc in frame difference.
            {
                diff.Value[2] = diff.Value[0] - diff.Value[1];
            }

            foreach (var diff in dinucTable)                        //Dinuc in frame abs difference.
            {
                diff.Value[3] = Math.Abs(diff.Value[0] - diff.Value[1]);
            }

            PrintDinucCountTable();
        }


        public Dictionary<string, int[]> DinucCountOut(string seqIn)
        {

            string seq = seqIn;
            if (seq.Length % 2 != 0)
            {
                seq = seq.Remove(seq.Length - 1);
            }

            int seqDinucLength = seq.Length / 2;

            seq = string.Concat(seq, "**");                     //Dinuc count in first frame.
            List<string> dinucListFirst = new List<string>();
            while (seq.Length != 2)
            {
                string dinuc = seq.Remove(2);
                dinucListFirst.Add(dinuc);
                seq = seq.Substring(2);
                int length = seq.Length;
            }

            foreach (var dinucTableKey in dinucTable)
            {
                foreach (var item in dinucListFirst)
                {
                    if (item == dinucTableKey.Key)
                    {
                        dinucTableKey.Value[0] += 1;
                    }
                }
            }

            seq = seqIn;                                        //Dinuc count in second frame.
            if (seq.Length % 2 != 0)
            {
                seq = seq.Remove(seq.Length - 1);
            }

            string nuc = seq.Substring(0, 1);

            seq = seq.Substring(1, seq.Length - 1);
            seq = string.Concat(seq, nuc);

            seq = string.Concat(seq, "**");
            List<string> dinucListSecond = new List<string>();
            while (seq.Length != 2)
            {
                string dinuc = seq.Remove(2);
                dinucListSecond.Add(dinuc);
                seq = seq.Substring(2);
                int length = seq.Length;
            }

            foreach (var dinucTableKey in dinucTable)
            {
                foreach (var dinu in dinucListSecond)
                {
                    if (dinu == dinucTableKey.Key)
                    {
                        dinucTableKey.Value[1] += 1;
                    }
                }
            }

            foreach (var diff in dinucTable)                        //Dinuc in frame difference.
            {
                diff.Value[2] = diff.Value[0] - diff.Value[1];
            }

            foreach (var diff in dinucTable)                        //Dinuc in frame abs difference.
            {
                diff.Value[3] = Math.Abs(diff.Value[0] - diff.Value[1]);
            }

            return dinucTable;
        }

        //Print out dinuc table.
        public void PrintDinucCountTable()
        {   
            foreach (var item in dinucTable)
            {
                Console.Write("{0}\t", item.Key);
            }
            Console.WriteLine();

            foreach (var item in dinucTable)
            {
                Console.Write("{0}\t", item.Value[0].ToString("0"));
            }
            Console.WriteLine();

            foreach (var item in dinucTable)
            {
                Console.Write("{0}\t", item.Value[1].ToString("0"));
            }
            Console.WriteLine();

            foreach (var item in dinucTable)
            {
                Console.Write("{0}\t", item.Value[2].ToString("0"));
            }
             Console.WriteLine();

            foreach (var item in dinucTable)
            {
                Console.Write("{0}\t", item.Value[3].ToString("0"));
            }
            Console.WriteLine();
        }
    }

    class DinucCountDiffSum
    {
        public int dinucCountSum(Dictionary<string, int[]> _countTable)
        {
            int diffSumAbs = 0;
            foreach (var item in _countTable)
            {
                diffSumAbs += item.Value[3];
            }
            return diffSumAbs;
        }
    }
}

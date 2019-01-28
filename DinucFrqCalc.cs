using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculation
{
    class DinucFrqCalc
    {
        Dictionary<string, float[]> dinucFrqTable = new Dictionary<string, float[]>();

        public DinucFrqCalc()
        {
            Dictionary<string, float[]> _dinucFrqTable = new Dictionary<string, float[]>();

            _dinucFrqTable.Add("aa", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("ac", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("ag", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("at", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("ca", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("cc", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("cg", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("ct", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("ga", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("gc", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("gg", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("gt", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("ta", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("tc", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("tg", new float[] { 0f, 0f, 0f, 0f });
            _dinucFrqTable.Add("tt", new float[] { 0f, 0f, 0f, 0f });

            dinucFrqTable = _dinucFrqTable;
        }

        //Input - seq, output - print dinuc frq table.
        public void DinucFrq(string _seq)
        {
            string seq = _seq;

            int dinucLength = seq.Length / 2;
            if (seq.Length % 2 != 0)
            {
                seq = seq.Remove(seq.Length - 1);
            }


            seq = string.Concat(seq, "**");
            List<string> dinucListFirst = new List<string>();
            while (seq.Length != 2)
            {
                string dinuc = seq.Remove(2);
                dinucListFirst.Add(dinuc);
                seq = seq.Substring(2);
                int length = seq.Length;
            }

            foreach (var item in dinucFrqTable)
            {
                foreach (var dinu in dinucListFirst)
                {
                    if (dinu == item.Key)
                    {
                        item.Value[0] += 1;
                    }
                }
            }

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

            foreach (var item in dinucFrqTable)
            {
                foreach (var dinu in dinucListSecond)
                {
                    if (dinu == item.Key)
                    {
                        item.Value[1] += 1;
                    }
                }
            }

            foreach (var diff in dinucFrqTable)
            {
                diff.Value[2] = diff.Value[0] - diff.Value[1];
            }

            foreach (var diff in dinucFrqTable)
            {
                diff.Value[3] = Math.Abs(diff.Value[0] - diff.Value[1]);
            }
            
            foreach (var diffFrq in dinucFrqTable)
            {
                diffFrq.Value[2] = diffFrq.Value[0] / dinucLength - diffFrq.Value[1] / dinucLength;
            }

            foreach (var diffFrqAbs in dinucFrqTable)
            {
                diffFrqAbs.Value[3] = Math.Abs(diffFrqAbs.Value[0] / dinucLength - diffFrqAbs.Value[1] / dinucLength);
            }
            
            PrintDinucFrqTable();
        }

        //Print out dinuc frequencies table.
        public void PrintDinucFrqTable()
        {
            foreach (var item in dinucFrqTable)
            {
                Console.Write("{0}\t", item.Key);
            }
            Console.WriteLine();

            foreach (var item in dinucFrqTable)
            {
                float itemFrq = item.Value[0];
                Console.Write("{0}\t", itemFrq.ToString("0.0000"));
            }
            Console.WriteLine();

            foreach (var item in dinucFrqTable)
            {
                float itemFrq = item.Value[1];
                Console.Write("{0}\t", itemFrq.ToString("0.0000"));
            }
            Console.WriteLine();

            foreach (var item in dinucFrqTable)
            {
                Console.Write("{0}\t", item.Value[2].ToString("0.0000"));
            }
            Console.WriteLine();

            foreach (var item in dinucFrqTable)
            {
                Console.Write("{0}\t", item.Value[3].ToString("0.0000"));
            }
            Console.WriteLine();
        }


        // Input - seq, output -  dinuc frq table.
        public Dictionary<string, float[]> DinucFrqOut(string _seq)
        {
            string seqFst = _seq;
            float dinucLength = seqFst.Length / 2;

            if (seqFst.Length % 2 != 0)
            {
                seqFst = seqFst.Remove(seqFst.Length - 1);
            }

            seqFst = string.Concat(seqFst, "**");
            List<string> dinucListFirst = new List<string>();
            while (seqFst.Length != 2)
            {
                string dinuc = seqFst.Remove(2);
                dinucListFirst.Add(dinuc);
                seqFst = seqFst.Substring(2);
                int length = seqFst.Length;
            }

            foreach (var item in dinucFrqTable)
            {
                float tempValue = 0;
                foreach (var dinu in dinucListFirst)
                {
                    if (dinu == item.Key)
                    {
                        tempValue += 1;
                    }
                }
                item.Value[0] = tempValue / dinucLength;
            }

            string seqSnd = _seq;
            if (seqSnd.Length % 2 != 0)
            {
                seqSnd = seqSnd.Remove(seqSnd.Length - 1);
            }

            string nuc = seqSnd.Substring(0, 1);

            seqSnd = seqSnd.Substring(1, seqSnd.Length - 1);
            seqSnd = string.Concat(seqSnd, nuc);

            seqSnd = string.Concat(seqSnd, "**");
            List<string> dinucListSecond = new List<string>();
            while (seqSnd.Length != 2)
            {
                string dinuc = seqSnd.Remove(2);
                dinucListSecond.Add(dinuc);
                seqSnd = seqSnd.Substring(2);
                int length = seqSnd.Length;
            }

            foreach (var item in dinucFrqTable)
            {
                float tempValue = 0;
                foreach (var dinu in dinucListSecond)
                {
                    if (dinu == item.Key)
                    {
                        tempValue += 1;
                    }
                }
                item.Value[1] = tempValue / dinucLength;
            }

            foreach (var item in dinucFrqTable)
            {
                item.Value[2] = item.Value[0] - item.Value[1];
            }

            foreach (var item in dinucFrqTable)
            {
                item.Value[3] = Math.Abs(item.Value[0] - item.Value[1]);
            }
            return dinucFrqTable;
        }
    }


    class DinucFrqDiffSum
    {
        public float dinucfrqSum(Dictionary<string, float[]> _frqShTable)
        {
            float frqDiffSumAbs = 0f;
            foreach (var sht in _frqShTable)
            {
                frqDiffSumAbs += sht.Value[3];
            }
            //Console.WriteLine("Difference sum\t" + diffSumAbs.ToString("0.0000") + "\n");
            return frqDiffSumAbs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculationTMP
{
    public class DinuCalc
    {
        public Dictionary<String, float[]> dinucTable;

        public DinuCalc()
        {
            
            Dictionary<string, float[]> dinuTable = new Dictionary<string, float[]>();

            dinuTable["aa"] = new float[] { 0, 0, 0 };
            dinuTable["ac"] = new float[] { 0, 0, 0 };
            dinuTable["ag"] = new float[] { 0, 0, 5 };
            dinuTable["at"] = new float[] { 0, 0, 6 };
            dinuTable["ca"] = new float[] { 0, 0, 8 };
            dinuTable["cc"] = new float[] { 0, 4, 0 };
            dinuTable["cg"] = new float[] { 0, 0, 0 };
            dinuTable["ct"] = new float[] { 0, 0, 0 };
            dinuTable["ga"] = new float[] { 0, 0, 0 };
            dinuTable["gc"] = new float[] { 0, 0, 0 };
            dinuTable["gg"] = new float[] { 0, 0, 0 };
            dinuTable["gt"] = new float[] { 0, 0, 0 };
            dinuTable["ta"] = new float[] { 0, 0, 0 };
            dinuTable["tc"] = new float[] { 0, 0, 0 };
            dinuTable["tg"] = new float[] { 0, 0, 0 };
            dinuTable["tt"] = new float[] { 0, 0, 0 };

            dinucTable = dinuTable;
        }

        public void DinucOut() {

            foreach (KeyValuePair<string, float[]> item in dinucTable) {
                Console.Write("{0}\t", item.Key);
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in dinucTable) {
                Console.Write("{0}\t", item.Value[0].ToString("0.0000"));
            }
            Console.WriteLine();
            
            foreach (KeyValuePair<string, float[]> item in dinucTable) {
                Console.Write("{0}\t", item.Value[1].ToString("0.0000"));
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in dinucTable) {
                Console.Write("{0}\t", item.Value[2].ToString("0.0000"));
            }
            Console.WriteLine();
        }

        public Dictionary<String, float[]> DinucCount (string seq)
            {
            
            return dinucTable;
            }

        public Dictionary<String, float[]> DinucFirstFrameCount (string seq)
            {
            char[] seqCharArray = seq.ToCharArray();
            string[] seqMonoArray = new string[seq.Length];
            int j = 0;
            foreach (char ch in seqCharArray)
            {
                seqMonoArray[j++] = ch.ToString();
            }

            string[] seqDiArray = new string[seq.Length / 2];
            int k = 0;
            for (int i = 0; i < seq.Length - 1; i += 2)
            {
                seqDiArray[k++] = seqMonoArray[i] + seqMonoArray[i + 1];
            }

            foreach (KeyValuePair<string, float[]> item in dinucTable)
            {
                int diCount = 0;
                foreach (string di in seqDiArray)
                {
                    if (item.Key == di) { diCount += 1; }
                }
                item.Value[0] = diCount;
            }
            //foreach (KeyValuePair<string, float[]> item in dinucTable ) {
            //  Console.WriteLine(item.Key + "\t" + item.Value[0]);
            //}
            return dinucTable;
        }

        
        public Dictionary<String, float[]> DinucSecondFrameCount (string seq)
        {
            char[] seqCharArray = seq.ToCharArray();
            Array.Reverse(seqCharArray, 1, seqCharArray.Length - 1);
            Array.Reverse(seqCharArray);

            string[] seqMonoArray = new string[seqCharArray.Length];
            int j = 0;
            foreach (char ch in seqCharArray)
            {
                seqMonoArray[j++] = ch.ToString();
            }

            string[] seqDiArray = new string[seq.Length / 2];
            int k = 0;
            for (int i = 0; i < seq.Length - 1; i += 2)
            {
                seqDiArray[k++] = seqMonoArray[i] + seqMonoArray[i + 1];
            }

            foreach (KeyValuePair<string, float[]> item in dinucTable)
            {
                int diCount = 0;
                foreach (string di in seqDiArray)
                {
                    if (item.Key == di) { diCount += 1; }
                }
                item.Value[1] = diCount;
            }
            //foreach (KeyValuePair<string, float[]> item in dinucTable)
            //{
            //    Console.WriteLine(item.Key + "\t" + item.Value[1]);
            //}
            return dinucTable;
        }

//---------Method calculates dinucleotides in two frames at once------------//

        public Dictionary<String, float[]> DinucTwoFrameCount(string seq)
        {
            // Seq array constraction and calculation by dinucleotides in first frame.

            char[] seqCharArrayFirst = seq.ToCharArray();
            string[] seqMonoArrayFirst = new string[seq.Length];
            int j = 0;
            foreach (char ch in seqCharArrayFirst)
            {
                seqMonoArrayFirst[j++] = ch.ToString();
            }

            string[] seqDinucArrayFirst = new string[seq.Length / 2];
            int k = 0;
            for (int i = 0; i < seq.Length - 1; i += 2)
            {
                seqDinucArrayFirst[k++] = seqMonoArrayFirst[i] + seqMonoArrayFirst[i + 1];
            }

            foreach (KeyValuePair<string, float[]> item in dinucTable)
            {
                int diCount = 0;
                foreach (string di in seqDinucArrayFirst)
                {
                    if (item.Key == di) { diCount += 1; }
                }
                item.Value[0] = diCount;
            }

            // Seq array constraction and calculation by dinucleotides in second frame.

            char[] seqCharArraySecond = seq.ToCharArray();
            Array.Reverse(seqCharArraySecond, 1, seqCharArraySecond.Length - 1);
            Array.Reverse(seqCharArraySecond);

            string[] seqMonoArraySecond = new string[seqCharArraySecond.Length];
            int n = 0;
            foreach (char ch in seqCharArraySecond)
            {
                seqMonoArraySecond[n++] = ch.ToString();
            }

            string[] seqDinucArraySecond = new string[seq.Length / 2];
            int m = 0;
            for (int i = 0; i < seq.Length - 1; i += 2)
            {
                seqDinucArraySecond[m++] = seqMonoArraySecond[i] + seqMonoArraySecond[i + 1];
            }

            foreach (KeyValuePair<string, float[]> item in dinucTable)
            {
                int diCount = 0;
                foreach (string di in seqDinucArraySecond)
                {
                    if (item.Key == di) { diCount += 1; }
                }
                item.Value[1] = diCount;
            }

            return dinucTable;
        }

        // Printout dinucleotides count table.

        public void DinucTablePrint (Dictionary<String, float[]> table)
        {

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write(item.Key + "\t");
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write(item.Value[0] + "\t");
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write(item.Value[1] + "\t");
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write(Math.Abs(item.Value[0] - item.Value[1]) + "\t");
            }
            Console.WriteLine();
        }

        // Printout dinucleotides frequencies table.

        public void DinucTableFrqPrint(Dictionary<String, float[]> table, int seqLength)
        {

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write(item.Key + "\t");
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write((item.Value[0]/seqLength).ToString("0.0000") + "\t");
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write((item.Value[1] / seqLength).ToString("0.0000") + "\t");
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, float[]> item in table)
            {
                Console.Write((Math.Abs(item.Value[0] - item.Value[1])/ seqLength).ToString("0.0000") + "\t");
            }
            Console.WriteLine();
        }
    }
}

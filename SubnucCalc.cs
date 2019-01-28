using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DinucCalculation
{
    class SubnucCalc
    {
        public SubnucCalc() { }
        public SubnucCalc (string _seq) { }
        public SubnucCalc (string _seq, int _nucLength) { }

        public void NucCalc (string _seq, int _nucLength)
        {
            string seq = _seq;
            int ncl = _nucLength;
            double slength = seq.Length / ncl;

            int ind = 0;
            List<string> subSeq = new List<string>();
            for(int i = 0; i < seq.Length / ncl; i++)
            {
                subSeq.Add(seq.Substring(ind, ncl));
                ind += ncl;
            }
            subSeq.Sort();
            subSeq.Add("###");

            List<Tuple<string, int, double>> countList = new List<Tuple<string, int, double>>();
            int count = 0;
            string tempSeq = subSeq[0];
            foreach(var item in subSeq)
            {
                if(tempSeq == item)
                {
                    count++;
                    continue;
                }
                else
                {
                    countList.Add(Tuple.Create(tempSeq, count, count / slength));
                    tempSeq = item;
                    count = 1;
                }
            }

            int nr = 1;
            foreach(var item in countList)
            {
                Console.WriteLine(nr++ + "\t" + item.Item1 + "\t" + item.Item2 +"\t" + item.Item3);
            }
            Console.Write("\n\nPress any key to quite");
            Console.ReadKey();
        }
    }
}

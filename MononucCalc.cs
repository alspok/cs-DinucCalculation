using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculation
{
    class MonoNucCalc
    {
        public MonoNucCalc() { }
        public MonoNucCalc(string _sq) { }

        public void MonoNuc (string _seq)
        {
            List<Tuple<char, int, float, float>> monoNucTable = new List<Tuple<char, int, float, float>>();
            string seq = _seq;
            int seqLength = seq.Length;
            char[] nucArray = { 'a', 'c', 'g', 't' };
            char[] seqCharArray = seq.ToCharArray();

            foreach (var nuc in nucArray)
            {
                int nucCount = 0;
                foreach (var nucseq in seqCharArray)
                {
                    if (nuc == nucseq) { nucCount += 1; }
                }
                monoNucTable.Add(Tuple.Create(nuc, nucCount, (float)nucCount / (float)seqLength, (float)(100 * nucCount) / (float)seqLength));
            }
            foreach (var item in monoNucTable)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Item1, item.Item2, item.Item3, item.Item4);
            }
        }

        public List<Tuple<char, int, double, double>> MonoNucReturn (string _seq)
        {
            List<Tuple<char, int, double, double>> monoNucTable = new List<Tuple<char, int, double, double>>();
            string seq = _seq;
            int seqLength = seq.Length;
            char[] nucArray = { 'a', 'c', 'g', 't' };
            char[] seqCharArray = seq.ToCharArray();

            foreach (var nuc in nucArray)
            {
                int nucCount = 0;
                foreach (var nucseq in seqCharArray)
                {
                    if (nuc == nucseq) { nucCount += 1; }
                }
                monoNucTable.Add(Tuple.Create(nuc, nucCount, ((double)nucCount / (double)seqLength), (double)(100 * nucCount) / (double)seqLength));
            }
            return monoNucTable;
        }
    }
}

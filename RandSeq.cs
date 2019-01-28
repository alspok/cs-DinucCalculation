using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinucCalculation
{
    class RandSeq
    {
        public RandSeq() { }

        //Random rnd = new Random() must be decleard in the body of script
        public void RandMonoSeqPrint(Random _rnd, int _randSeqLength)
        {
            Random rnd = _rnd;
            int randSeqLength = _randSeqLength;

            string randSeq = string.Empty;
            var monoNuc = new string[] { "a", "c", "g", "t" };
            //Random rnd = new Random();
            for (int i = 0; i < randSeqLength; i++)
            {
                int rand = rnd.Next(0, 3);
                randSeq = string.Concat(randSeq, monoNuc[rand]);
            }
            Console.WriteLine(randSeq);
        }

        //Random rnd = new Random() must be decleard in the body of script
        public string RandMonoSeq(Random _rnd, int _randSeqLength)
        {
            Random rnd = _rnd;
            int randSeqLength = _randSeqLength;
            string randSeq = string.Empty;

            var monoNuc = new string[] { "a", "c", "g", "t" };
            for (int i = 0; i < randSeqLength; i++)
            {
                int rand = rnd.Next(0, 3);
                randSeq = string.Concat(randSeq, monoNuc[rand]);
            }
            return randSeq;
        }

        //Random rnd = new Random() must be decleard in the body of script
        public string RandMonoSeq(Random _rnd, int _randSeqLength, double[] _nucFrq)
        {
            Random rnd = _rnd;
            int randSeqLength = _randSeqLength;
            double[] nucFrq = _nucFrq;
            string randSeq = string.Empty;
            double[] nucFrqMod = new double[nucFrq.Length];

            double nucSum = 0;
            foreach (var item in nucFrq) nucSum += item;
            if (nucSum > 1.1 || nucSum < 0.9)
            {
                Console.WriteLine("Wrong argument sum.");
                EndRun.End();
                System.Environment.Exit(1);
            }

            for(int i = 0; i < _nucFrq.Length; i++)
            {
                if(i == 0)
                {
                    nucFrqMod[i] = nucFrq[i];
                    continue;
                }
                nucFrqMod[i] = nucFrqMod[i - 1] + nucFrq[i];
            }

            var monoNuc = new string[] { "a", "c", "g", "t" };

            for(int i = 0; i < randSeqLength; i++)
            {
                double rand = rnd.NextDouble();
                for(int j = 0; j < nucFrqMod.Length; j++)
                {
                    if (rand <= nucFrqMod[j])
                    {
                        randSeq = string.Concat(randSeq, monoNuc[j]);
                        break;
                    }
                }
            }

            return randSeq;
        }
    }
}

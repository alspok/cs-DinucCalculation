using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Bio;
using Bio.IO;
using Bio.IO.FastA;
using Bio.Extensions;

// public void SeqInputFasta () - input seq fasta file name inside. output - console.
// public void SeqInputFasta (string fileName) - input seq fasta file name. output - console.
// public string SeqInputFastaOut(string fileName) - input seq fasta file name. output - seq string.
// public List<string> SeqInputFastaOutDinucList (string seq) - input seq string. output - list of seq dinucleotides in frame.

namespace DinucCalculation
{
    public class SeqIO
    {
        public SeqIO() { }
        public SeqIO(string s) { }

        public void SeqInputFasta()
        {
            string seqFileName = @"C:\Perl64\Sequences\HBoV\HBoV-VP2.fasta";
            StreamReader seqFile = new StreamReader(seqFileName);
            string seqLine = string.Empty;
            string seq = string.Empty;
            while ((seqLine = seqFile.ReadLine()) != null)
            {
                if (seqLine.Contains(">")) { continue; }
                else { seq = seq + seqLine; seqLine = string.Empty; }
            }
            seqFile.Close();
            Console.WriteLine(seq);
            Console.WriteLine("\nSeq length - " + seq.Length + " bp");
        }

        public string SeqInputFasta(string _fileName)
        {
            string seqFileName = _fileName;
            StreamReader seqFile = new StreamReader(seqFileName);
            string seqLine = string.Empty;
            string seq = string.Empty;
            while ((seqLine = seqFile.ReadLine()) != null)
            {
                if (seqLine.Contains(">")) { continue; }
                else { seq = seq + seqLine; seqLine = string.Empty; }
            }
            seqFile.Close();
            return seq.ToLower();
        }

        public string SeqInputFastaReader(string _fileName)
        {
            string fileName = _fileName;
            StringBuilder seq = new StringBuilder();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string sq = string.Empty;
                while ((sq = sr.ReadLine()) != null)
                {
                    if (sq.Contains(">")) continue;
                    seq.Append(sq);
                }
            }
            //seq = sb.ToString();
            //Console.WriteLine(seq);
            //seq = sb.ToString().ToLower();
            return seq.ToString().ToLower();
        }

        public List<string> SeqInputFastaOutDinucList(string seq)
        {
            if (seq.Length % 2 != 0)
            {
                seq = seq.Substring(0, seq.Length - 1);
            }
            var seqDinucList = new List<string>();
            for (int j = 0; j < seq.Length; j += 2)
            {
                seqDinucList.Add(seq.Substring(j, 2));
            }
            return seqDinucList;
        }

        public IEnumerable<ISequence> ParsedSeqIO(string _seqFileName)
        {
            string seqFileName = _seqFileName;

            ISequenceParser parser = new FastAParser();
            parser.Open(seqFileName);
            IEnumerable<ISequence> sequences = parser.Parse().ToList();

            return sequences;
        }

        public static IEnumerable<ISequence> ParsedSSeqIO(string _seqFileName)
        {
            string seqFileName = _seqFileName;

            ISequenceParser parser = new FastAParser();
            parser.Open(seqFileName);
            IEnumerable<ISequence> sequences = parser.Parse().ToList();

            return sequences;
         }

        public static List<string> ParsedLSeqIO(string _seqFileName)
        {
            var seqFileName = _seqFileName;
            List<string> sequencesList = new List<string>();

            ISequenceParser parser = new FastAParser();
            parser.Open(seqFileName);
            IEnumerable<ISequence> sequences = parser.Parse().ToList();
            foreach(var item in sequences)
            {
                var seq = item.ConvertToString().ToLower();
                sequencesList.Add(seq);
            }

            //List<string> sequencesList = new List<string>(sequences.Cast<string>());

            return sequencesList;
        }
    }
}

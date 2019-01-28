/*************************************************************************************************************************
class SeqTools:
public string SeqShuffleFisher(List<string> seqDinucList) - seq shuffle using Fisher algorith, input - dinucleotide list.
public string MonoShuffleFicher(string _seq) - seq shuffle by monucleotides, inpup - sequence.
public string DinucShuffleFisher(string _seq) - seq shuffle by dinucleotides, input - sequence.
public string TrinucShuffleFisher(string _seq) - seq shuffle by trinucleotides, input - sequence.
public void Polindrom(string _seq) - polindrom finder, polindrom length 6bp.
public string RandomMonoSeq(int _length, Random _random) - random seq production.
public string RandomPercentSeq(Dictionary<string, int> _seqNucPercent, int _length, Random _random) - random seq, particular percent of nucleotides.
public string RandomFrqSeq(Dictionary<string, int> _seqNucPercent, int _length, Random _random) - random seq, particular frq of nucleotides.
public List<Tuple<string, string>> RestrictionList() - init restriction list.
public List<Tuple<string, string>> PureRestrictionList() - init restriction list only with A, C, G, T.
public List<Tuple<string, string>> HexRestrictionList() - init restriction list of hex nucleotides.

static class StringReverse:
public static string Reverse(this string input) - reverse seq.

static class RandomSeq:
public static void RandMonoSeq(int randLength, Random rnd) - 

***************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bio.Util;
using System.Threading.Tasks;

namespace DinucCalculation
{
    class SeqTools
    {
        public SeqTools() { }

        public string SeqShuffleFisher(List<string> seqDinucList)
        {
            Random rand = new Random();
            for (int m = seqDinucList.Count; m > 1; m--)
            {
                int index = rand.Next(m);
                string tmp = seqDinucList[index];
                seqDinucList[index] = seqDinucList[m - 1];
                seqDinucList[m - 1] = tmp;
            }

            string sq = string.Concat(seqDinucList);
            //Console.WriteLine(sq);
            return sq;
        }

        public string MononucShuffleFisher(string _seq)
        {
            string seq = _seq.ToLower();
            var seqMonoList = new List<string>();
            for (int j = 0; j < seq.Length; j++) seqMonoList.Add(seq.Substring(j, 1));

            Random rand = new Random();
            for (int m = seqMonoList.Count; m > 1; m--)
            {
                int index = rand.Next(m);
                string tmp = seqMonoList[index];
                seqMonoList[index] = seqMonoList[m - 1];
                seqMonoList[m - 1] = tmp;
            }

            string sq = string.Concat(seqMonoList);
            return sq;
        }

        public string DinucShuffleFisher(string _seq)
        {
            string seq = _seq.ToLower();
            if (seq.Length % 2 != 0)
            {
                seq = seq.Substring(0, seq.Length - 1);
            }
            var seqDinucList = new List<string>();
            for (int j = 0; j < seq.Length; j += 2) seqDinucList.Add(seq.Substring(j, 2));

            Random rand = new Random();
            for (int m = seqDinucList.Count; m > 1; m--)
            {
                int index = rand.Next(m);
                string tmp = seqDinucList[index];
                seqDinucList[index] = seqDinucList[m - 1];
                seqDinucList[m - 1] = tmp;
            }

             string sq = string.Concat(seqDinucList);
            //Console.WriteLine(sq);
            return sq;
        }

        public string TrinucShuffleFisher(string _seq)
        {
            string seq = _seq;
            if (seq.Length % 3 == 0) seq = seq.Substring(0);
            if ((seq.Length - 1) % 3 == 0) seq = seq.Substring(0, seq.Length - 1);
            if ((seq.Length - 2) % 3 == 0) seq = seq.Substring(0, seq.Length - 2);

            var seqTrinucList = new List<string>();
            for (int j = 0; j < seq.Length; j += 3) seqTrinucList.Add(seq.Substring(j, 3));

            Random rand = new Random();
            for (int m = seqTrinucList.Count; m > 1; m--)
            {
                int index = rand.Next(m);
                string tmp = seqTrinucList[index];
                seqTrinucList[index] = seqTrinucList[m - 1];
                seqTrinucList[m - 1] = tmp;
            }

            string sq = string.Concat(seqTrinucList);
            return sq;
        }

        public void Polindrom(string _seq, int _polLength)
        {
            string seq = _seq;
            int polLength = _polLength;
            //string sq = seq.Substring(start, stop - start);

            //seq = "aaaacagctgtttt";
            string compSeq = string.Empty;
            char[] seqArray = seq.ToCharArray();

            foreach (char nuc in seqArray)
            {
                if (nuc == 'a') { compSeq = compSeq + "t"; }
                if (nuc == 'c') { compSeq = compSeq + "g"; }
                if (nuc == 'g') { compSeq = compSeq + "c"; }
                if (nuc == 't') { compSeq = compSeq + "a"; }
            }

            int count = 1;
            for (int i = 0; i < seq.Length - polLength; i++)
            {
                string subSeq = seq.Substring(i, polLength);
                string subCompSeq = compSeq.Substring(i, polLength);
                string revSubCompSeq = subCompSeq.Reverse();

                if (subSeq == revSubCompSeq)
                {
                    Console.WriteLine(count + "\t" + subSeq + " at pos " + i);
                    count++;
                }
            }
        }

        public string RandomMonoSeq(int _length, Random _random)
        {
            int randLength = _length;
            Random random = _random;
            string randSeq = string.Empty;

            var monoNuc = new string[] { "a", "c", "g", "t" };
            for (int i = 0; i < randLength; i++)
            {
                int rnd = random.Next(0, 3);
                randSeq = string.Concat(randSeq, monoNuc[rnd]);
            }
            return randSeq;
        }

        public string RandomFrqSeq(List<Tuple<string, double>> _seqNucFrq, int _length, Random _random)
        {
            var seqNucFrq = _seqNucFrq;
            List<Tuple<string, double>> modSeqNucFrq = new List<Tuple<string, double>>();
            int randLength = _length;
            Random random = _random;
            string randSeq = string.Empty;

            //int i = 0;
            double tempValue = 0;
            foreach (var item in seqNucFrq)
            {
                modSeqNucFrq.Add(Tuple.Create(item.Item1, item.Item2 + tempValue));
                tempValue = item.Item2 + tempValue;
            }

            double listMin = modSeqNucFrq[0].Item2;
            double listMax = modSeqNucFrq[modSeqNucFrq.Count - 1].Item2;
            //GetRandom getRnd = new GetRandom();

            for (int i = 0; i < randLength; i++)
            {
                double rnd = random.NextDouble();
                foreach (var item in modSeqNucFrq)
                {
                    if (rnd <= item.Item2) { randSeq += item.Item1; break; }
                }
            }
            return randSeq;
        }

        public string RandomFrqSeq(Dictionary<string, float> _seqNucFrq, int _length, Random _random)
        {
            var seqNucFrq = _seqNucFrq;
            Dictionary<string, float> mseqNucFrq = new Dictionary<string, float>();
            int randLength = _length;
            Random random = _random;
            string randSeq = string.Empty;

            //int i = 0;
            float tempValue = 0;
            foreach (KeyValuePair<string, float> item in seqNucFrq)
            {
                mseqNucFrq.Add(item.Key, item.Value + tempValue);
                tempValue = item.Value + tempValue;
            }

            for (int i = 0; i < randLength; i++)
            {
                double rnd = random.NextDouble();
                foreach (KeyValuePair<string, float> item in mseqNucFrq)
                {
                    if (rnd <= item.Value) { randSeq += item.Key; break; }
                }
            }
            return randSeq;
        }

        public List<Tuple<string, string>> RestrictionList()
        {
            var restrictList = new List<Tuple<string, string>>
            {
                Tuple.Create("RAATTY", "AcsI/ApoI"),
                Tuple.Create("AAGCTT", "HindIII"),
                Tuple.Create("AACGTT", "Psp1406I"),
                Tuple.Create("AATATT", "SspI"),
                Tuple.Create("ACRYGT", "AflIII"),
                Tuple.Create("ACCGGT", "AgeI"),
                Tuple.Create("ACATGT", "BspLU11I"),
                Tuple.Create("ACCTGC", "BspMI"),
                Tuple.Create("ACTGG", "BsrI"),
                Tuple.Create("RCCGGY", "BsrFI/Cfr10I"),
                Tuple.Create("ACGT", "MaeII"),
                Tuple.Create("ACGCGT", "MluI"),
                Tuple.Create("RCATGY", "NspI"),
                Tuple.Create("ACCGGT", "PinAI"),
                Tuple.Create("ACCWGGT", "SexAI"),
                Tuple.Create("ACTAGT", "SpeI"),
                Tuple.Create("AGGCCT", "AatI        "),
                Tuple.Create("AGCT", "AluI"),
                Tuple.Create("AGATCT", "BglII"),
                Tuple.Create("RGATCY", "BstYI"),
                Tuple.Create("RGGNCCY", "DraII"),
                Tuple.Create("AGCGCT", "Eco47III"),
                Tuple.Create("RGGNCCY", "EcoO109I"),
                Tuple.Create("RGCGCY", "HaeII"),
                Tuple.Create("RGGWCCY", "PpuMI"),
                Tuple.Create("AGTACT", "ScaI"),
                Tuple.Create("AGGCCT", "StuI"),
                Tuple.Create("RGATCY", "XhoII"),
                Tuple.Create("ATTAAT", "AseI/AsnI"),
                Tuple.Create("ATCGAT", "BspDI/ClaI/NsiI"),
                Tuple.Create("ATTTAAAT", "SwaI"),
                Tuple.Create("CAGNNNCTG", "AlwNI"),
                Tuple.Create("CACGTG", "BbrPI"),
                Tuple.Create("CACNNNGTG", "DraIII"),
                Tuple.Create("YACGTR", "BsaAI"),
                Tuple.Create("CAATTG", "MfeI/MunI"),
                Tuple.Create("CATATG", "NdeI"),
                Tuple.Create("CATG", "NlaIII"),
                Tuple.Create("CMGCKG", "NspBII"),
                Tuple.Create("CACGTG", "PmaCI/PmlI"),
                Tuple.Create("CAGCTG", "PvuII"),
                Tuple.Create("CRCCGGYG", "SgrAI"),
                Tuple.Create("CATCC", "FokI   "),
                Tuple.Create("CCGC", "AciI"),
                Tuple.Create("CCTNAGG", "AocI"),
                Tuple.Create("CCWGG", "ApyI"),
                Tuple.Create("CCTAGG", "AvrII/BinI"),
                Tuple.Create("CCNNGG", "BsaJI"),
                Tuple.Create("CCNNNNNNNGG", "BsiYI/BslI"),
                Tuple.Create("CCANNNNNNTGG", "BssGI"),
                Tuple.Create("CCWGG", "BstNI"),
                Tuple.Create("CCANNNNNNTGG", "BstXI"),
                Tuple.Create("CCTNAGG", "Bsu36I"),
                Tuple.Create("CCRYGG", "DsaI"),
                Tuple.Create("CYCGRG", "AvaI"),
                Tuple.Create("CCTNNNNNAGG", "EcoNI"),
                Tuple.Create("CCWGG", "EcoRII"),
                Tuple.Create("CCGG", "HpaII"),
                Tuple.Create("CCGCGG", "KspI"),
                Tuple.Create("CCTC", "MnlI"),
                Tuple.Create("CCGG", "MspI"),
                Tuple.Create("CCTNAGG", "MstII"),
                Tuple.Create("CCWGG", "MvaI"),
                Tuple.Create("CCSGG", "NciI"),
                Tuple.Create("CCATGG", "NcoI"),
                Tuple.Create("CMGCKG", "NspBII"),
                Tuple.Create("CCANNNNNTGG", "PflMI"),
                Tuple.Create("CCGCGG", "SacII"),
                Tuple.Create("CCTNAGG", "SauI"),
                Tuple.Create("CCNGG", "ScrFI"),
                Tuple.Create("CCCGGG", "SmaI"),
                Tuple.Create("CCTGCAGG", "Sse8387I"),
                Tuple.Create("CCGCGG", "SstII"),
                Tuple.Create("CCWWGG", "StyI"),
                Tuple.Create("CCANNNNNTGG", "Van91I"),
                Tuple.Create("CCANNNNNNNNNTGG", "XcmI"),
                Tuple.Create("CCCGGG", "XmaI/XcmI"),
                Tuple.Create("CCAGT", "BsrI   "),
                Tuple.Create("CGANNNNNNTGC", "BcgI"),
                Tuple.Create("CGRYCG", "BsiEI"),
                Tuple.Create("CGTACG", "BsiWI"),
                Tuple.Create("CGCG", "BstUI"),
                Tuple.Create("CGGCCG", "EagI "),
                Tuple.Create("YGGCCR", "CfrI/EaeI"),
                Tuple.Create("CGGCCG", "EclXI"),
                Tuple.Create("CGTCTC", "Esp3I"),
                Tuple.Create("CGCG", "FnuDII/MvnI"),
                Tuple.Create("CGATCG", "PvuI"),
                Tuple.Create("CGGWCCG", "RsrII"),
                Tuple.Create("CRCCGGYG", "SgrAI"),
                Tuple.Create("CGCG", "ThaI"),
                Tuple.Create("CGGCCG", "XmaIII"),
                Tuple.Create("CTTAAG", "AflII"),
                Tuple.Create("CTAG", "BfaI"),
                Tuple.Create("CTTAAG", "BfrI"),
                Tuple.Create("CTGGAG", "BpmI"),
                Tuple.Create("CTNAG", "DdeI"),
                Tuple.Create("CTCTTC", "EarI"),
                Tuple.Create("CYCGRG", "AvaI"),
                Tuple.Create("CTGAAG", "Eco57I"),
                Tuple.Create("CTGGAG", "GsuI"),
                Tuple.Create("CTAG", "MaeI"),
                Tuple.Create("CTCGAG", "PaeR7I"),
                Tuple.Create("CTGCAG", "PstI"),
                Tuple.Create("CTAG", "RmaI"),
                Tuple.Create("CTRYAG", "SfcI"),
                Tuple.Create("CTCGAG", "XhoI"),
                Tuple.Create("CTCCAG", "BpmI "),
                Tuple.Create("CTGCAC", "BsgI "),
                Tuple.Create("CTTCAG", "Eco57I  "),
                Tuple.Create("CTCCAG", "GsuI     "),
                Tuple.Create("GACGTC", "AatII"),
                Tuple.Create("GACNNNGTC", "AspI"),
                Tuple.Create("GAANNNNTTC", "Asp700"),
                Tuple.Create("GACNNNNNGTC", "AspEI"),
                Tuple.Create("GAAGAC", "BbsI/BpuAI"),
                Tuple.Create("GATNNNNATC", "BsaBI"),
                Tuple.Create("GAATGC", "BsmI"),
                Tuple.Create("GATC", "DpnI-if-G-Me/DpnII"),
                Tuple.Create("GACNNNNNNGTC", "DrdI"),
                Tuple.Create("GACNNNNNGTC", "Eam1105I"),
                Tuple.Create("GAGCTC", "Ecl136II"),
                Tuple.Create("RAATTY", "AcsI"),
                Tuple.Create("GRCGYC", "AcyI/AhaII"),
                Tuple.Create("RAATTY", "ApoI"),
                Tuple.Create("GWGCWC", "AspHI"),
                Tuple.Create("GRGCYC", "BanII"),
                Tuple.Create("GDGCHC", "BmyI"),
                Tuple.Create("GRCGYC", "BsaHI"),
                Tuple.Create("GDGCHC", "Bsp1286I"),
                Tuple.Create("GAATTC", "EcoRI"),
                Tuple.Create("GATATC", "EcoRV"),
                Tuple.Create("GACGC", "HgaI"),
                Tuple.Create("GWGCWC", "HgiAI"),
                Tuple.Create("GANTC", "HinfI"),
                Tuple.Create("GATNNNNATC", "MamI"),
                Tuple.Create("GATC", "MboI/NdeII"),
                Tuple.Create("GAAGA", "MboII"),
                Tuple.Create("GDGCHC", "NspII"),
                Tuple.Create("GAGTC", "PleI"),
                Tuple.Create("GAGCTC", "SacI"),
                Tuple.Create("GATC", "Sau3AI"),
                Tuple.Create("GAGCTC", "SstI"),
                Tuple.Create("GAWTC", "TfiI"),
                Tuple.Create("GACNNNGTC", "Tth111I"),
                Tuple.Create("GAANNNNTTC", "XmnI        "),
                Tuple.Create("GATGC", "SfaNI"),
                Tuple.Create("GATCC", "AlwI          "),
                Tuple.Create("GAGACC", "BsaI        "),
                Tuple.Create("GAGAC", "BsmAI     "),
                Tuple.Create("GAAGAG", "EarI "),
                Tuple.Create("GAGACG", "Esp3I "),
                Tuple.Create("GAGG", "MnlI     "),
                Tuple.Create("GACTC", "PleI    "),
                Tuple.Create("GCAGC", "BbvI"),
                Tuple.Create("GCCNNNNNGGC", "BglI"),
                Tuple.Create("GCTNAGC", "Bpu1102I"),
                Tuple.Create("GCGCGC", "BsePI/BssHII"),
                Tuple.Create("GCTNAGC", "CelII"),
                Tuple.Create("GCGC", "CfoI/HhaI/HinPI"),
                Tuple.Create("RCCGGY", "BsrFI/Cfr10I"),
                Tuple.Create("GCTNAGC", "EspI"),
                Tuple.Create("GCNGC", "Fnu4HI"),
                Tuple.Create("GCNGC", "ItaI"),
                Tuple.Create("GCCGGC", "NaeI/NgoMI"),
                Tuple.Create("GCTAGC", "NheI"),
                Tuple.Create("GCGGCCGC", "NotI"),
                Tuple.Create("RCATGY", "NspI"),
                Tuple.Create("GCATC", "SfaNI"),
                Tuple.Create("GCATGC", "SphI"),
                Tuple.Create("GCCCGGGC", "SrfI"),
                Tuple.Create("GCGG", "AciI            "),
                Tuple.Create("GCTGC", "BbvI   "),
                Tuple.Create("GCANNNNNNTCG", "BcgI      "),
                Tuple.Create("GCATTC", "BsmI        "),
                Tuple.Create("GCAGGT", "BspMI    "),
                Tuple.Create("GCGTC", "HgaI  "),
                Tuple.Create("GGTACC", "Acc65I"),
                Tuple.Create("GGWCC", "AflI"),
                Tuple.Create("GGATC", "AlwI"),
                Tuple.Create("GGGCCC", "ApaI"),
                Tuple.Create("GGCGCGCC", "AscI"),
                Tuple.Create("GGTACC", "Asp718"),
                Tuple.Create("GGWCC", "AvaII"),
                Tuple.Create("GGATCC", "BamHI"),
                Tuple.Create("GGYRCC", "BanI"),
                Tuple.Create("GGTCTC", "BsaI"),
                Tuple.Create("GGTNACC", "BstEII"),
                Tuple.Create("RGATCY", "BstYI"),
                Tuple.Create("GRCGYC", "AcyI"),
                Tuple.Create("GRCGYC", "AhaII"),
                Tuple.Create("GRGCYC", "BanII"),
                Tuple.Create("GDGCHC", "BmyI"),
                Tuple.Create("GRCGYC", "BsaHI"),
                Tuple.Create("GDGCHC", "Bsp1286I"),
                Tuple.Create("RGGNCCY", "DraII"),
                Tuple.Create("RGGNCCY", "EcoO109I"),
                Tuple.Create("GGATG", "FokI"),
                Tuple.Create("GGCCGGCC", "FseI"),
                Tuple.Create("RGCGCY", "HaeII"),
                Tuple.Create("GGCC", "HaeIII"),
                Tuple.Create("GGTGA", "HphI"),
                Tuple.Create("GGCGCC", "KasI"),
                Tuple.Create("GGTACC", "KpnI"),
                Tuple.Create("GGCGCC", "NarI"),
                Tuple.Create("GGNNCC", "NlaIV"),
                Tuple.Create("GDGCHC", "NspII"),
                Tuple.Create("RGGWCCY", "PpuMI"),
                Tuple.Create("GGNCC", "Sau96I"),
                Tuple.Create("GGCCNNNNNGGCC", "SfiI"),
                Tuple.Create("RGATCY", "XhoII"),
                Tuple.Create("GTMKAC", "AccI"),
                Tuple.Create("GTGCAC", "Alw44I/ApaLI"),
                Tuple.Create("GTGCAG", "BsgI"),
                Tuple.Create("GTCTC", "BsmAI"),
                Tuple.Create("GTATAC", "Bst1107I"),
                Tuple.Create("GWGCWC", "AspHI"),
                Tuple.Create("GDGCHC", "BmyI"),
                Tuple.Create("GDGCHC", "Bsp1286I"),
                Tuple.Create("GWGCWC", "HgiAI"),
                Tuple.Create("GTYRAC", "HincII/HindII"),
                Tuple.Create("GTTAAC", "HpaI"),
                Tuple.Create("GTNAC", "MaeIII"),
                Tuple.Create("GDGCHC", "NspII"),
                Tuple.Create("GTTTAAAC", "PmeI"),
                Tuple.Create("GTAC", "RsaI"),
                Tuple.Create("GTCGAC", "SalI"),
                Tuple.Create("GTGCAC", "SnoI"),
                Tuple.Create("GTCTTC", "BbsI/BpuAI"),
                Tuple.Create("YACGTR", "BsaAI"),
                Tuple.Create("TACGTA", "SnaBI"),
                Tuple.Create("TCCGGA", "AccII/BseAI"),
                Tuple.Create("TCCGGA", "BspEI"),
                Tuple.Create("TCATGA", "BspHI"),
                Tuple.Create("TCCGGA", "MroI"),
                Tuple.Create("TCGCGA", "NruI"),
                Tuple.Create("TCATGA", "RcaI"),
                Tuple.Create("TCGA", "TaqI"),
                Tuple.Create("TCTAGA", "XbaI"),
                Tuple.Create("TCACC", "HphI       "),
                Tuple.Create("TCTTC", "MboII  "),
                Tuple.Create("TGCGCA", "AosI"),
                Tuple.Create("TGCGCA", "AviII"),
                Tuple.Create("TGGCCA", "BalI"),
                Tuple.Create("TGATCA", "BclI"),
                Tuple.Create("TGTACA", "Bsp1407I"),
                Tuple.Create("YGGCCR", "CfrI/EaeI"),
                Tuple.Create("TGCGCA", "FspI"),
                Tuple.Create("TGGCCA", "MluNI/MscI"),
                Tuple.Create("TGCGCA", "MstI"),
                Tuple.Create("TGTACA", "SspBI"),
                Tuple.Create("TTTAAA", "AhaIII"),
                Tuple.Create("TTCGAA", "AsuII/BstBI"),
                Tuple.Create("TTTAAA", "DraI"),
                Tuple.Create("TTAA", "MseI"),
                Tuple.Create("TTCGAA", "NspV"),
                Tuple.Create("TTAATTAA", "PacI"),
                Tuple.Create("TTCGAA", "SfuI"),
                Tuple.Create("TTAA", "Tru9I"),
            };

            return restrictList;
        }

        public List<Tuple<string, string>> PureRestrictionList()
        {
            var pureRestrictList = new List<Tuple<string, string>>
            {
                Tuple.Create("AAGCTT", "HindIII"),
                Tuple.Create("AACGTT", "Psp1406I"),
                Tuple.Create("AATATT", "SspI"),
                Tuple.Create("ACCGGT", "AgeI"),
                Tuple.Create("ACATGT", "BspLU11I"),
                Tuple.Create("ACCTGC", "BspMI"),
                Tuple.Create("ACTGG", "BsrI"),
                Tuple.Create("ACGT", "MaeII"),
                Tuple.Create("ACGCGT", "MluI"),
                Tuple.Create("ACCGGT", "PinAI"),
                Tuple.Create("ACTAGT", "SpeI"),
                Tuple.Create("AGGCCT", "AatI"),
                Tuple.Create("AGCT", "AluI"),
                Tuple.Create("AGATCT", "BglII"),
                Tuple.Create("AGCGCT", "Eco47III"),
                Tuple.Create("AGTACT", "ScaI"),
                Tuple.Create("AGGCCT", "StuI"),
                Tuple.Create("ATTAAT", "AseI/AsnI"),
                Tuple.Create("ATCGAT", "BspDI/ClaI/NsiI"),
                Tuple.Create("ATTTAAAT", "SwaI"),
                Tuple.Create("CACGTG", "BbrPI"),
                Tuple.Create("CAATTG", "MfeI/MunI"),
                Tuple.Create("CATATG", "NdeI"),
                Tuple.Create("CATG", "NlaIII"),
                Tuple.Create("CACGTG", "PmaCI/PmlI"),
                Tuple.Create("CAGCTG", "PvuII"),
                Tuple.Create("CATCC", "FokI   "),
                Tuple.Create("CCGC", "AciI"),
                Tuple.Create("CCTAGG", "AvrII/BinI"),
                Tuple.Create("CCGG", "HpaII"),
                Tuple.Create("CCGCGG", "KspI"),
                Tuple.Create("CCTC", "MnlI"),
                Tuple.Create("CCGG", "MspI"),
                Tuple.Create("CCATGG", "NcoI"),
                Tuple.Create("CCGCGG", "SacII"),
                Tuple.Create("CCCGGG", "SmaI"),
                Tuple.Create("CCTGCAGG", "Sse8387I"),
                Tuple.Create("CCGCGG", "SstII"),
                Tuple.Create("CCCGGG", "XmaI/XcmI"),
                Tuple.Create("CCAGT", "BsrI   "),
                Tuple.Create("CGTACG", "BsiWI"),
                Tuple.Create("CGCG", "BstUI"),
                Tuple.Create("CGGCCG", "EagI "),
                Tuple.Create("CGGCCG", "EclXI"),
                Tuple.Create("CGTCTC", "Esp3I"),
                Tuple.Create("CGCG", "FnuDII/MvnI"),
                Tuple.Create("CGATCG", "PvuI"),
                Tuple.Create("CGCG", "ThaI"),
                Tuple.Create("CGGCCG", "XmaIII"),
                Tuple.Create("CTTAAG", "AflII"),
                Tuple.Create("CTAG", "BfaI"),
                Tuple.Create("CTTAAG", "BfrI"),
                Tuple.Create("CTGGAG", "BpmI"),
                Tuple.Create("CTCTTC", "EarI"),
                Tuple.Create("CTGAAG", "Eco57I"),
                Tuple.Create("CTGGAG", "GsuI"),
                Tuple.Create("CTAG", "MaeI"),
                Tuple.Create("CTCGAG", "PaeR7I"),
                Tuple.Create("CTGCAG", "PstI"),
                Tuple.Create("CTAG", "RmaI"),
                Tuple.Create("CTCGAG", "XhoI"),
                Tuple.Create("CTCCAG", "BpmI "),
                Tuple.Create("CTGCAC", "BsgI "),
                Tuple.Create("CTTCAG", "Eco57I  "),
                Tuple.Create("CTCCAG", "GsuI     "),
                Tuple.Create("GACGTC", "AatII"),
                Tuple.Create("GAAGAC", "BbsI/BpuAI"),
                Tuple.Create("GAATGC", "BsmI"),
                Tuple.Create("GATC", "DpnI-if-G-Me/DpnII"),
                Tuple.Create("GAGCTC", "Ecl136II"),
                Tuple.Create("GAATTC", "EcoRI"),
                Tuple.Create("GATATC", "EcoRV"),
                Tuple.Create("GACGC", "HgaI"),
                Tuple.Create("GATC", "MboI/NdeII"),
                Tuple.Create("GAAGA", "MboII"),
                Tuple.Create("GAGTC", "PleI"),
                Tuple.Create("GAGCTC", "SacI"),
                Tuple.Create("GATC", "Sau3AI"),
                Tuple.Create("GAGCTC", "SstI"),
                Tuple.Create("GATGC", "SfaNI"),
                Tuple.Create("GATCC", "AlwI"),
                Tuple.Create("GAGACC", "BsaI"),
                Tuple.Create("GAGAC", "BsmAI"),
                Tuple.Create("GAAGAG", "EarI"),
                Tuple.Create("GAGACG", "Esp3I"),
                Tuple.Create("GAGG", "MnlI"),
                Tuple.Create("GACTC", "PleI"),
                Tuple.Create("GCAGC", "BbvI"),
                Tuple.Create("GCGCGC", "BsePI/BssHII"),
                Tuple.Create("GCGC", "CfoI/HhaI/HinPI"),
                Tuple.Create("GCCGGC", "NaeI/NgoMI"),
                Tuple.Create("GCTAGC", "NheI"),
                Tuple.Create("GCGGCCGC", "NotI"),
                Tuple.Create("GCATC", "SfaNI"),
                Tuple.Create("GCATGC", "SphI"),
                Tuple.Create("GCCCGGGC", "SrfI"),
                Tuple.Create("GCGG", "AciI"),
                Tuple.Create("GCTGC", "BbvI"),
                Tuple.Create("GCATTC", "BsmI"),
                Tuple.Create("GCAGGT", "BspMI"),
                Tuple.Create("GCGTC", "HgaI"),
                Tuple.Create("GGTACC", "Acc65I"),
                Tuple.Create("GGATC", "AlwI"),
                Tuple.Create("GGGCCC", "ApaI"),
                Tuple.Create("GGCGCGCC", "AscI"),
                Tuple.Create("GGTACC", "Asp718"),
                Tuple.Create("GGATCC", "BamHI"),
                Tuple.Create("GGTCTC", "BsaI"),
                Tuple.Create("GGATG", "FokI"),
                Tuple.Create("GGCCGGCC", "FseI"),
                Tuple.Create("GGCC", "HaeIII"),
                Tuple.Create("GGTGA", "HphI"),
                Tuple.Create("GGCGCC", "KasI"),
                Tuple.Create("GGTACC", "KpnI"),
                Tuple.Create("GGCGCC", "NarI"),
                Tuple.Create("GTGCAC", "Alw44I/ApaLI"),
                Tuple.Create("GTGCAG", "BsgI"),
                Tuple.Create("GTCTC", "BsmAI"),
                Tuple.Create("GTATAC", "Bst1107I"),
                Tuple.Create("GTTAAC", "HpaI"),
                Tuple.Create("GTTTAAAC", "PmeI"),
                Tuple.Create("GTAC", "RsaI"),
                Tuple.Create("GTCGAC", "SalI"),
                Tuple.Create("GTGCAC", "SnoI"),
                Tuple.Create("GTCTTC", "BbsI/BpuAI"),
                Tuple.Create("TACGTA", "SnaBI"),
                Tuple.Create("TCCGGA", "AccII/BseAI"),
                Tuple.Create("TCCGGA", "BspEI"),
                Tuple.Create("TCATGA", "BspHI"),
                Tuple.Create("TCCGGA", "MroI"),
                Tuple.Create("TCGCGA", "NruI"),
                Tuple.Create("TCATGA", "RcaI"),
                Tuple.Create("TCGA", "TaqI"),
                Tuple.Create("TCTAGA", "XbaI"),
                Tuple.Create("TCACC", "HphI"),
                Tuple.Create("TCTTC", "MboII"),
                Tuple.Create("TGCGCA", "AosI"),
                Tuple.Create("TGCGCA", "AviII"),
                Tuple.Create("TGGCCA", "BalI"),
                Tuple.Create("TGATCA", "BclI"),
                Tuple.Create("TGTACA", "Bsp1407I"),
                Tuple.Create("TGCGCA", "FspI"),
                Tuple.Create("TGGCCA", "MluNI/MscI"),
                Tuple.Create("TGCGCA", "MstI"),
                Tuple.Create("TGTACA", "SspBI"),
                Tuple.Create("TTTAAA", "AhaIII"),
                Tuple.Create("TTCGAA", "AsuII/BstBI"),
                Tuple.Create("TTTAAA", "DraI"),
                Tuple.Create("TTAA", "MseI"),
                Tuple.Create("TTCGAA", "NspV"),
                Tuple.Create("TTAATTAA", "PacI"),
                Tuple.Create("TTCGAA", "SfuI"),
                Tuple.Create("TTAA", "Tru9I"),
            };

            return pureRestrictList;
        }

        public List<Tuple<string, string>> HexRestrictionList()
        {
            var hexRestictList = new List<Tuple<string, string>>
            {
                Tuple.Create("AAGCTT", "HindIII"),
                Tuple.Create("AACGTT", "Psp1406I"),
                Tuple.Create("AATATT", "SspI"),
                Tuple.Create("ACCGGT", "AgeI/PinAI"),
                Tuple.Create("ACATGT", "BspLU11I"),
                Tuple.Create("ACCTGC", "BspMI"),
                Tuple.Create("ACGCGT", "MluI"),
                Tuple.Create("ACTAGT", "SpeI"),
                Tuple.Create("AGGCCT", "AatI"),
                Tuple.Create("AGATCT", "BglII"),
                Tuple.Create("AGCGCT", "Eco47III"),
                Tuple.Create("AGTACT", "ScaI"),
                Tuple.Create("AGGCCT", "StuI"),
                Tuple.Create("ATTAAT", "AseI/AsnI"),
                Tuple.Create("ATCGAT", "BspDI/ClaI/NsiI"),
                Tuple.Create("CACGTG", "BbrPI"),
                Tuple.Create("CAATTG", "MfeI/MunI"),
                Tuple.Create("CATATG", "NdeI"),
                Tuple.Create("CACGTG", "PmaCI/PmlI"),
                Tuple.Create("CAGCTG", "PvuII"),
                Tuple.Create("CCTAGG", "AvrII/BinI"),
                Tuple.Create("CCGCGG", "KspI"),
                Tuple.Create("CCATGG", "NcoI"),
                Tuple.Create("CCGCGG", "SacII"),
                Tuple.Create("CCCGGG", "SmaI"),
                Tuple.Create("CCGCGG", "SstII"),
                Tuple.Create("CCCGGG", "XmaI/XcmI"),
                Tuple.Create("CGTACG", "BsiWI"),
                Tuple.Create("CGGCCG", "EagI "),
                Tuple.Create("CGGCCG", "EclXI"),
                Tuple.Create("CGTCTC", "Esp3I"),
                Tuple.Create("CGATCG", "PvuI"),
                Tuple.Create("CGGCCG", "XmaIII"),
                Tuple.Create("CTTAAG", "AflII"),
                Tuple.Create("CTTAAG", "BfrI"),
                Tuple.Create("CTGGAG", "BpmI/GsuI"),
                Tuple.Create("CTCTTC", "EarI"),
                Tuple.Create("CTGAAG", "Eco57I"),
                Tuple.Create("CTCGAG", "PaeR7I"),
                Tuple.Create("CTGCAG", "PstI"),
                Tuple.Create("CTCGAG", "XhoI"),
                Tuple.Create("CTCCAG", "BpmI "),
                Tuple.Create("CTGCAC", "BsgI "),
                Tuple.Create("CTTCAG", "Eco57I  "),
                Tuple.Create("CTCCAG", "GsuI     "),
                Tuple.Create("GACGTC", "AatII"),
                Tuple.Create("GAAGAC", "BbsI/BpuAI"),
                Tuple.Create("GAATGC", "BsmI"),
                Tuple.Create("GAATTC", "EcoRI"),
                Tuple.Create("GATATC", "EcoRV"),
                Tuple.Create("GAGCTC", "SacI/SstI/Ecl136II"),
                Tuple.Create("GAGACC", "BsaI"),
                Tuple.Create("GAAGAG", "EarI"),
                Tuple.Create("GAGACG", "Esp3I"),
                Tuple.Create("GCGCGC", "BsePI/BssHII"),
                Tuple.Create("GCCGGC", "NaeI/NgoMI"),
                Tuple.Create("GCATGC", "SphI"),
                Tuple.Create("GCATTC", "BsmI"),
                Tuple.Create("GCAGGT", "BspMI"),
                Tuple.Create("GGTACC", "Acc65I/Asp718/KpnI"),
                Tuple.Create("GGGCCC", "ApaI"),
                Tuple.Create("GGATCC", "BamHI"),
                Tuple.Create("GGTCTC", "BsaI"),
                Tuple.Create("GGCGCC", "KasI/NarI"),
                Tuple.Create("GTGCAC", "Alw44I/ApaLI/SnoI"),
                Tuple.Create("GTGCAG", "BsgI"),
                Tuple.Create("GTATAC", "Bst1107I"),
                Tuple.Create("GTTAAC", "HpaI"),
                Tuple.Create("GTCTTC", "BbsI/BpuAI"),
                Tuple.Create("TACGTA", "SnaBI"),
                Tuple.Create("TCCGGA", "AccII/BseAI"),
                Tuple.Create("TCCGGA", "BspEI"),
                Tuple.Create("TCATGA", "BspHI/RcaI"),
                Tuple.Create("TCCGGA", "MroI"),
                Tuple.Create("TCGCGA", "NruI"),
                Tuple.Create("TCTAGA", "XbaI"),
                Tuple.Create("TGCGCA", "AosI/AviII/MstI/FspI"),
                Tuple.Create("TGGCCA", "BalI"),
                Tuple.Create("TGATCA", "BclI"),
                Tuple.Create("TGTACA", "Bsp1407I"),
                Tuple.Create("TGGCCA", "MluNI/MscI"),
                Tuple.Create("TGTACA", "SspBI"),
                Tuple.Create("TTTAAA", "AhaIII/DraI"),
                Tuple.Create("TTCGAA", "AsuII/BstBI/NspV/SfuI"),
            };

            return hexRestictList;
        }

        /* Prepears sequence for shuffle by mono-, di-, tri-nucleotides in for loop */
        public IEnumerable<string> SeqFragment(string _seqString, int _subNucLength)
        {
            string seqString = _seqString.ToLower();
            int subNucLength = _subNucLength;
            IEnumerable<string> ieSeq = null;
            List<string> iSeq = new List<string>();

            long nucCount = seqString.Length;

            if (subNucLength == 1)
            {
                for (int i = 0; i < nucCount; i += 1) iSeq.Add(seqString.Substring(i, 1));
                ieSeq = iSeq;
            }

            if (subNucLength == 2)
            {
                if (nucCount % 2 == 0)
                {
                    for (int i = 0; i < nucCount; i += 2) iSeq.Add(seqString.Substring(i, 2));
                    ieSeq = iSeq;
                }
                else
                {
                    for (int i = 0; i < nucCount - 1; i += 2) iSeq.Add(seqString.Substring(i, 2));
                    ieSeq = iSeq;
                }
            }

            if (subNucLength == 3)
            {
                if (nucCount % 3 == 0)
                {
                    for (int i = 0; i < nucCount; i += 3) iSeq.Add(seqString.Substring(i, 3));
                    ieSeq = iSeq;
                }
                else if ((nucCount - 1) % 3 == 0)
                {
                    for (int i = 0; i < nucCount - 1; i += 3) iSeq.Add(seqString.Substring(i, 3));
                    ieSeq = iSeq;
                }
                else if ((nucCount - 2) % 3 == 0)
                {
                    for (int i = 0; i < nucCount; i += 3) iSeq.Add(seqString.Substring(i, 3));
                    ieSeq = iSeq;
                }
            }

            return ieSeq;
        }

/* Prepears sequence for shuffle by mono-, di-, tri-nucleotides in while loop */
        public IEnumerable<string> SeqAllFragment(string _seqString, int _subNucLength)
        {
            string seqString = _seqString.ToLower();
            int subNucLength = _subNucLength;
            IEnumerable<string> ieSeq = null;
            List<string> iSeq = new List<string>();

            int i = 0;
            string subSeq = string.Empty;

            //while ((subSeq = seqString.Substring(i, subNucLength)) != IsNullOrEmpty)
            //while (!String.IsNullOrEmpty(subSeq = seqString.Substring(i, subNucLength)))
            while (i < (seqString.Length - subNucLength))
            {
                iSeq.Add(seqString.Substring(i, subNucLength));
                i += subNucLength;
            }     
    
            return ieSeq = iSeq;
        }
    } // End of class SeqTools.

        static class StringReverse
    {
        public static string Reverse(this string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }
    }

    static class RandomSeq
    {
        public static void RandMonoSeq(int randLength, Random rnd)
        {
            string randSeq = string.Empty;
            var monoNuc = new string[] { "a", "c", "g", "t" };
            //Random rnd = new Random();
            for (int i = 0; i < randLength; i++)
            {
                int rand = rnd.Next(0, 3);
                randSeq = string.Concat(randSeq, monoNuc[rand]);
            }
        Console.WriteLine(randSeq);
        }
    }

    class GetRandom
    {
        public double GetRand(double _max, double _min, Random _random)
        {
            double max = _max;
            double min = _min;
            Random random = _random;

            min = 0.001;
            double rand = min + random.NextDouble() * (max - min);
            return rand;
        }
    }

    static class AllIndexes
    {
        public static List<Tuple<string, int>> AllIndexOf (string _str, string _searchStr)
        {
            string str = _str;
            string searchStr = _searchStr;

            List<Tuple<string, int>> allIndexList = new List<Tuple<string, int>>();

            int index = str.IndexOf(searchStr, StringComparison.OrdinalIgnoreCase);
            while(index != -1)
            {
                allIndexList.Add(Tuple.Create(searchStr, index));
                index = str.IndexOf(searchStr, index + searchStr.Length, StringComparison.OrdinalIgnoreCase);
            }

            return allIndexList;
        }
    }



    static class SeqShuffle
    {
        public static string SeqNucShuffle (IEnumerable<string> _seqItem, Random _rnd)
        {
            var seqItem = _seqItem;
            var rnd = _rnd;

            var seqShuffleList = seqItem.Shuffle(rnd);
            var seqShuffle = String.Join("", seqShuffleList);

            return seqShuffle;
        }
    }

    static class EndRun
    {
        public static void End()
        {
            Console.Write("\n\nPress any key to quite. ");
            Console.ReadKey();
        }
    }
}

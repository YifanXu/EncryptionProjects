using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricalEncyptionForm
{
    [Obsolete]
    public class KeySet
    {
        public readonly char[] specialChars = new char[] { '\n', '\t', 'r' };
        public const int ASCIIRangeStart = 32;
        public const int ASCIIRangeEnd = 126;

        public readonly string name;
        public readonly int charLength;
        private readonly int seed;
        public Random r;
        public Dictionary<char, string> EncryptKey { get; private set; }
        public Dictionary<string, char> DecryptKey { get; private set; }

        public KeySet(string name, int charLength)
        {
            this.name = name;
            this.charLength = charLength;
            this.seed = name.GetHashCode()*charLength;
            r = new Random(seed);
            EncryptKey = new Dictionary<char, string>();
            DecryptKey = new Dictionary<string, char>();

            //Deal with special values
            foreach(char input in specialChars)
            {
                AppendNewValue(input);
            }
            
            //Generate
            for(int i = ASCIIRangeStart; i <= ASCIIRangeEnd; i++)
            {
                AppendNewValue((char)i);
            }
        }

        private void AppendNewValue(char input)
        {
            StringBuilder output = new StringBuilder();
            do
            {
                output.Clear();
                for (int j = 0; j < charLength; j++)
                {
                    output.Append((char)r.Next(ASCIIRangeStart, ASCIIRangeEnd + 1));
                }
            } while (DecryptKey.ContainsKey(output.ToString()));
            //Append key value
            EncryptKey.Add(input, output.ToString());
            DecryptKey.Add(output.ToString(), input);
        }

        public override string ToString()
        {
            return $"\"{name}\"({charLength})";
        }
    }
}

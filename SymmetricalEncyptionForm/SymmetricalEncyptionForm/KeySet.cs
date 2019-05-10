using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricalEncyptionForm
{
    public class KeySet
    {
        public readonly char[] specialChars = new char[] { '\n' };
        public const int ASCIIRangeStart = 32;
        public const int ASCIIRangeEnd = 126;

        public readonly string name;
        public readonly int charLength;
        private readonly int intSeed;
        public Random r;
        public Dictionary<char, string> EncryptKey { get; private set; }
        public Dictionary<string, char> DecryptKey { get; private set; }

        public KeySet(string name, int charLength)
        {
            this.name = name;
            this.charLength = charLength;
            this.intSeed = name.GetHashCode();
            r = new Random(intSeed*charLength);
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
            string output = string.Empty;
            do
            {
                StringBuilder val = new StringBuilder();
                for (int j = 0; j < charLength; j++)
                {
                    val.Append((char)r.Next(ASCIIRangeStart, ASCIIRangeEnd + 1));
                }
                output = val.ToString();
            } while (DecryptKey.ContainsKey(output));
            //Append key value
            EncryptKey.Add(input, output);
            DecryptKey.Add(output, input);
        }

        public override string ToString()
        {
            return $"\"{name}\"({charLength})";
        }
    }
}

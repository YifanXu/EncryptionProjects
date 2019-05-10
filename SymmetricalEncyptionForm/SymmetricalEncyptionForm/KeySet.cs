using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricalEncyptionForm
{
    public class KeySet
    {
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

            //Generate
            for(int i = ASCIIRangeStart; i <= ASCIIRangeEnd; i++)
            {
                char input = (char)i;
                string output = string.Empty;
                //Generate Corresponding Value that is unique
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
        }

        public override string ToString()
        {
            return $"\"{name}\"({charLength})";
        }
    }
}

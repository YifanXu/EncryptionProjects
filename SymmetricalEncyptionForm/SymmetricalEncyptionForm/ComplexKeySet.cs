using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricalEncyptionForm
{
    public class ComplexKeySet
    {
        public struct Pair
        {
            public char key;
            public string value;
            public Pair(char key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public static List<char> usableChars;

        public readonly string name;
        public readonly int charLength;
        private readonly int seed;
        private readonly int headerShift;
        public Pair[] key;
        private Dictionary<string, int> stringGuide;
        private Dictionary<char, int> charGuide;
        
        public ComplexKeySet(string name, int charLength)
        {
            //Init
            this.name = name;
            this.charLength = charLength;
            this.seed = name.GetHashCode() * charLength;
            Random r = new Random(seed);

            //Fill usuable characters
            if(usableChars == null)
            {
                usableChars = new List<char>();
                for (int i = 0; i < byte.MaxValue/2; i++)
                {
                    char c = (char)i;
                    if (char.IsLetterOrDigit(c) || char.IsPunctuation(c) || (char.IsWhiteSpace(c) && c != '\n' && c != '\r'))
                    {
                        usableChars.Add(c);
                    }
                }
            }

            //Calculate Header Shift
            headerShift = r.Next(usableChars.Count);

            //Populate key
            key = new Pair[usableChars.Count];
            stringGuide = new Dictionary<string, int>(usableChars.Count);
            charGuide = new Dictionary<char, int>(usableChars.Count);
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < usableChars.Count; i++)
            {
                char newChar = usableChars[i];
                //Generate new value string
                do
                {
                    output.Clear();
                    for (int j = 0; j < charLength; j++)
                    {
                        output.Append(usableChars[(char)r.Next(usableChars.Count)]);
                    }
                } while (stringGuide.ContainsKey(output.ToString()));
                //Append to dictionary
                key[i] = new Pair(newChar, output.ToString());
                stringGuide.Add(output.ToString(), i);
                charGuide.Add(newChar, i);
            }
        }

        public string Encrypt (string message, Random r)
        {
            StringBuilder output = new StringBuilder();
            //Determine Header
            int shiftLength = r.Next(1, 5);
            int shiftMagnitude = r.Next(1, usableChars.Count);
            int currentShift = r.Next(1, usableChars.Count);
            //Append Header
            output.Append(EncryptID(shiftLength, headerShift));
            output.Append(EncryptID(shiftMagnitude, headerShift));
            output.Append(EncryptID(currentShift,headerShift));
            //EncryptBody
            for(int i = 0; i < message.Length; i++)
            {
                if (i % shiftLength == 0) currentShift += shiftMagnitude;
                output.Append(EncryptChar(message[i], currentShift));
            }
            //Append Tail
            int tailLength = r.Next(charLength);
            for(int i = 0; i < tailLength; i++)
            {
                output.Append(usableChars[r.Next(usableChars.Count)]);
            }
            //Return
            return output.ToString();
        }

        public string Decrypt (string message)
        {
            if (message.Length < charLength * 3) throw new Exception("Message is less than minimum required length");
            //Determine Header
            int shiftLength = DecryptID(message.Substring(0,charLength), headerShift);
            int shiftMagnitude = DecryptID(message.Substring(charLength, charLength), headerShift);
            int currentShift = DecryptID(message.Substring(charLength*2, charLength), headerShift);
            //DecryptBody
            StringBuilder output = new StringBuilder();
            for(int i = 3; i < message.Length/charLength; i++)
            {
                if ((i-3) % shiftLength == 0) currentShift += shiftMagnitude;
                var substring = message.Substring(i * charLength, charLength);
                output.Append(DecryptChar(substring, currentShift));
            }
            return output.ToString();
        }

        private string EncryptChar (char c, int shift)
        {
            int id;
            if(!charGuide.TryGetValue(c,out id))
            {
                throw new ArgumentException($"Character '{c}' is not supported");
            }
            return key[(id + shift)%key.Length].value;
        }

        private char DecryptChar (string s, int shift)
        {
            int id;
            if (!stringGuide.TryGetValue(s, out id))
            {
                throw new ArgumentException($"String '{s}' is not an expected value");
            }
            id = (id - shift) % key.Length;
            return key[id >= 0 ? id : id + key.Length].key;
        }

        private string EncryptID (int id, int shift)
        {
            return key[(id + shift) % key.Length].value;
        }

        private int DecryptID (string s, int shift)
        {
            int id;
            if (!stringGuide.TryGetValue(s, out id))
            {
                throw new ArgumentException($"String '{s}' is not an expected value");
            }
            id = (id - shift) % key.Length;
            return id >= 0 ? id : id + key.Length;
        }

        public override string ToString()
        {
            return $"\"{name}\"({charLength})";
        }
    }
}

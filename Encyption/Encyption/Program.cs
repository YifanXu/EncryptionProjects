using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Encyption
{
    class Program
    {
        /// <summary>
        /// All characters that are encoded. Used to Generate Key
        /// </summary>
        public const string SupportedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789,.;:`~!@#$%^&*-_+=/?()<>[]{}|\\\"\' ";

        //Oh Lord Forgive me
        private static Dictionary<char, string> keySet = null;
        private static string KeySetName = "null";
        private static Exception lastException;

        public static Random r = new System.Random();

        private static Dictionary<string, Func<string[], string>> commands = new Dictionary<string, Func<string[], string>>()
        {
            {"newkey", _GetKey },
            {"getkey", _GetKey },
            {"generatekey", _GetKey },
            {"setkeyname", _SetKeyName },
            {"keyname", _SetKeyName },
            {"name", _SetKeyName },
            {"encode", _Encode},
            {"decode", _Decode },
            {"load", _Import },
            {"import", _Import },
            {"importkey", _Import },
            {"export", _Export },
            {"exportkey", _Export },
            {"debug", _ShowError },
            {"error", _ShowError },
            {"showerror", _ShowError },
            {"show", _ShowKey }
        };

        public static void Main(string[] args)
        {
            bool isError = false;
            string lastMessage = "";
            while(true)
            {
                Console.Clear();
                //Top Line: KeySet Name
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Current KeySet: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(keySet == null ? "null" : KeySetName);

                //Second Line: Last Operation Output
                Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.Cyan;
                Console.WriteLine(lastMessage);

                //Get Input
                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine();
                int firstSpace = input.IndexOf(' ');
                string command = String.Empty;
                string[] argument = new string[0];
                if (firstSpace == -1)
                {
                    command = input;
                }
                else
                {
                    command = input.Substring(0, firstSpace);
                    argument = input.Substring(firstSpace + 1).Split(' ');
                }
                command = command.ToLower();

                if(commands.TryGetValue(command, out var dele))
                {
                    try
                    {
                        lastMessage = dele(argument);
                        isError = false;
                    }
                    catch(Exception e)
                    {
                        lastException = e;
                        lastMessage = e.Message;
                        isError = true;
                    }
                }
                else
                {
                    lastMessage = "Invalid Command";
                    isError = true;
                }
            }
        }

        public static Dictionary<char, string> GenerateKey(int keyLength)
        {
            Dictionary<char, string> key = new Dictionary<char, string>();
            int numOfChars = SupportedCharacters.Length;
            for(int i = 0; i < numOfChars; i++)
            {
                string resultCode = "";
                do
                {
                    for (int j = 0; j < keyLength; j++)
                    {
                        resultCode += SupportedCharacters[r.Next(numOfChars)];
                    }
                }while (key.ContainsValue(resultCode));
                key.Add(SupportedCharacters[i], resultCode);
            }
            return key;
        }

        public static void ExportKey(Dictionary<char,string> key, string FilePath)
        {
            ExportKey(key, FilePath, "KeySet #" + r.Next(1, 100));
        }

        public static void ExportKey(Dictionary<char, string> key, string FilePath, string KeyTitle)
        {
            string[] serialized = new string[key.Count + 1];
            serialized[0] = KeyTitle;
            var keyArray = key.ToArray();
            for(int i = 0; i < key.Count; i++)
            {
                serialized[i + 1] = keyArray[i].Key + keyArray[i].Value;
            }
            File.WriteAllLines(FilePath, serialized);
        }

        public static Dictionary<char, string> ImportKey(string FilePath, out string KeyTitle)
        {
            string[] input = File.ReadAllLines(FilePath);
            KeyTitle = input[0];
            Dictionary<char, string> key = new Dictionary<char, string>();
            for(int i = 1; i < input.Length; i++)
            {
                string s = input[i];
                key.Add(s[0], s.Substring(1));
            }
            return key;
        }

        public static bool IsKeyOneToOne(Dictionary<char,string> key)
        {
            var values = key.Values.ToArray();
            for(int i = 0; i < values.Length - 1; i++)
            {
                for(int j = i + 1; j < values.Length; j++)
                {
                    if (values[i] == values[j]) return false;
                }
            }
            return true;
        }
        
        public static string Encode(string s, Dictionary<char, string> key)
        {
            StringBuilder res = new StringBuilder();
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if(key.TryGetValue(c,out string code))
                {
                    res.Append(code);
                }
                else
                {
                    res.Append(c);
                }
            }
            return res.ToString();
        }

        public static string Decode(string s, Dictionary<char, string> key)
        {
            Dictionary<string, char> ReverseKey = new Dictionary<string, char>(key.Count);
            foreach(var pair in key)
            {
                if (!ReverseKey.ContainsKey(pair.Value))
                {
                    ReverseKey.Add(pair.Value, pair.Key);
                }
            }
            return Decode(s, ReverseKey);
        }

        public static string Decode(string s, Dictionary<string, char> reverseKey)
        {
            StringBuilder res = new StringBuilder();
            int j = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(!SupportedCharacters.Contains(s[i]))
                {
                    if(j != i) throw new Exception("Key is invalid (Found invalid character). Decoded: " + res.ToString());
                    res.Append(s[i]);
                    continue;
                }
                string code = s.Substring(j, i - j + 1);
                if(reverseKey.TryGetValue(code, out char original))
                {
                    res.Append(original);
                    j = i + 1;
                }
            }
            if(j < s.Length)
            {
                if (reverseKey.TryGetValue(s.Substring(j), out char original))
                {
                    res.Append(original);
                }
                else
                {
                    throw new Exception("Key is invalid. Decoded: " + res.ToString());
                }
            }
            return res.ToString();
        }

        //Command Functions
        private static string _GetKey(string[] arguments)
        {
            int length = 2;
            if (arguments.Length >= 1)
            {
                length = int.Parse(arguments[0]);
            }
            keySet = GenerateKey(length);
            KeySetName = "KeySet #" + r.Next(1, 100);
            return "Key Generated";
        }

        private static string _SetKeyName(string[] arguments)
        {
            if (keySet == null) throw new Exception("No key is loaded");
            if (arguments == null || arguments.Length == 0) throw new ArgumentException("No argument. Follow the command with a string");
            KeySetName = arguments[0];
            return "KeySetName set to " + arguments[0];
        }

        private static string _Encode (string[] arguments)
        {
            if (keySet == null) throw new Exception("No key is loaded");
            if (arguments == null || arguments.Length == 0) throw new ArgumentException("No argument. Follow the command with the string that needs to be encoded");
            if(arguments.Length > 1 && arguments[0].ToLower() == "path")
            {
                return "Encoded:\n" + Encode(File.ReadAllText(arguments[1]), keySet);
            }
            StringBuilder meshedUpString = new StringBuilder(arguments[0]);
            for(int i = 1; i < arguments.Length; i++)
            {
                meshedUpString.Append(' ');
                meshedUpString.Append(arguments[i]);
            }
            return "Encoded:\n" + Encode(meshedUpString.ToString(), keySet);
        }

        private static string _Decode (string[] arguments)
        {
            if (keySet == null) throw new Exception("No key is loaded");
            if (arguments == null || arguments.Length == 0) throw new ArgumentException("No argument. Follow the command with the string that needs to be decoded");
            if (arguments.Length > 1 && arguments[0].ToLower() == "path")
            {
                return "Decoded:\n" + Decode(File.ReadAllText(arguments[1]), keySet);
            }
            StringBuilder meshedUpString = new StringBuilder(arguments[0]);
            for (int i = 1; i < arguments.Length; i++)
            {
                meshedUpString.Append(' ');
                meshedUpString.Append(arguments[i]);
            }
            return "Decoded:\n" + Decode(meshedUpString.ToString(), keySet);
        }

        private static string _Export (string[] arguments)
        {
            if (keySet == null) throw new Exception("No key is loaded");
            string path;
            if (arguments == null || arguments.Length == 0) path = KeySetName + ".txt";
            else path = arguments[0].Trim();
            ExportKey(keySet, path, KeySetName);
            return $"KeySet {KeySetName} exported to {path}";
        }

        private static string _Import (string[] arguments)
        {
            if (arguments == null || arguments.Length == 0) throw new Exception("No argument.Follow the command with desired file path");
            string path = arguments[0].Trim();
            if (!path.EndsWith(".txt")) path += ".txt";
            keySet = ImportKey(path, out KeySetName);
            return $"KeySet \"{KeySetName}\" imported from {path}";
        }
        
        private static string _ShowError(string[] arguments)
        {
            if(lastException == null)
            {
                return "No Exception has occured";
            }
            return $"{lastException.GetType().Name} has occured: {lastException.Message}\nStackTrace:\n{lastException.StackTrace}";
        }

        private static string _ShowKey(string[] arguments)
        {
            if (keySet == null) throw new Exception("No key to show");
            StringBuilder s = new StringBuilder("KeySet " + KeySetName);
            foreach(var pair in keySet)
            {
                s.Append($"\n{pair.Key} => {pair.Value}");
            }
            return s.ToString();
        }
    }
}

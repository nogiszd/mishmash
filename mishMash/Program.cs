using System;
using System.IO;
using System.Text;

namespace mishMash
{
    class Program
    {
        public static string[] fileExt = new string[] {"exe", "mp3", "wav", "mp4", "avi", "txt", "jpg", "docx", "pptx", "xls", "dll"};
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No arguments given... (type -h for help)");
                Console.ResetColor();
                Environment.Exit(1);
            }

            if (args[0].StartsWith("-"))
            {
                if(args[0] == "-h" || args[0] == "-H")
                {
                    ShowHelp();
                }
                else
                {
                    try
                    {
                        if (args[1] != null)
                        {
                            switch (args[0].ToUpper())
                            {
                                case "-S":
                                    PrepareScramble(args[1], 1);
                                    break;
                                case "-R":
                                    PrepareScramble(args[1], 2);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Did you provide file name?");
                        Console.ResetColor();
                        Environment.Exit(1);
                    }
                }
            }
            else
            {
                PrepareScramble(args[0], 0);
            }

            
        }

        static void ShowHelp()
        {
            Console.WriteLine("mishMash 0.1");
            Console.WriteLine("");
            Console.WriteLine("Usage: mishmash.exe [option] <fileName>");
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("   -s      Keep current file extension.");
            Console.WriteLine("   -r      Randomize file extension.");
        }

        static void PrepareScramble(string file, int flag)
        {
            if (flag == 0)
            {
                if (!File.Exists(file))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File doesn't exist in current directory!");
                    Console.ResetColor();
                    Environment.Exit(1);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING! Scrambled file cannot be unscrambled!");
                Console.WriteLine("");
                Console.ResetColor();
                Console.WriteLine("MishMash 0.1");
                Console.WriteLine($"Input file: {file}");
                Console.WriteLine("Press key to proceed...");
                Console.WriteLine();
                Console.ReadKey();
                Scramble(file, false, false);
            }
            else if (flag == 1)
            {
                if (!File.Exists(file))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File doesn't exist in current directory!");
                    Console.ResetColor();
                    Environment.Exit(1);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING! Scrambled file cannot be unscrambled!");
                Console.WriteLine("");
                Console.ResetColor();
                Console.WriteLine("MishMash 0.1");
                Console.WriteLine($"Input file: {file}");
                Console.WriteLine("Press key to proceed...");
                Console.WriteLine();
                Console.ReadKey();
                Scramble(file, false, true);
            }
            else if (flag == 2)
            {
                if (!File.Exists(file))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File doesn't exist in current directory!");
                    Console.ResetColor();
                    Environment.Exit(1);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING! Scrambled file cannot be unscrambled!");
                Console.WriteLine("");
                Console.ResetColor();
                Console.WriteLine("MishMash 0.1");
                Console.WriteLine($"Input file: {file}");
                Console.WriteLine("Press key to proceed...");
                Console.WriteLine();
                Console.ReadKey();
                Scramble(file, true, false);
            }
        }

        static void Scramble(string file, bool randomExt, bool keepExt)
        {
            byte[] bytes = File.ReadAllBytes(Environment.CurrentDirectory + @"\" + file);
            string buffer = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            Random _random = new Random();

            if(randomExt==true && keepExt == false)
            {
                int rnd = _random.Next(0, fileExt.Length);
                File.WriteAllText($@"{Environment.CurrentDirectory}\{Path.GetFileNameWithoutExtension(Environment.CurrentDirectory + @"\" + file)}.{fileExt[rnd]}", EncodeTo64(StringToBinary(buffer)));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Output file: {Path.GetFileNameWithoutExtension(Environment.CurrentDirectory + @"\" + file)}.{fileExt[rnd]}");
                Console.ResetColor();
            }

            if(randomExt==false && keepExt == true)
            {
                File.WriteAllText($@"{Environment.CurrentDirectory}\{file}", EncodeTo64(StringToBinary(buffer)));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Output file: {file}");
                Console.ResetColor();
            }

            if(randomExt==false && keepExt == false)
            {
                File.WriteAllText($@"{Environment.CurrentDirectory}\{Path.GetFileNameWithoutExtension(Environment.CurrentDirectory + @"\" + file)}.mishmash", EncodeTo64(StringToBinary(buffer)));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Output file: {Path.GetFileNameWithoutExtension(Environment.CurrentDirectory + @"\" + file)}.mishmash");
                Console.ResetColor();
            }
        }
    }
}

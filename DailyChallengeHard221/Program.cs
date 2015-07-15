using System;
using System.Diagnostics;
using System.IO;

namespace DailyChallengeHard221
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            string line, original;
            string[] words;
            using (StreamReader sr = new StreamReader(@"M:\FiftyKLines.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    original = line;
                    line = line.Replace(",", "");
                    line = line.Replace(".", "");
                    words = line.Split(' ');
                    
                    if (!singleLetter(words))
                        continue;

                    if (properEnglish(words))
                        Console.Write(String.Format("{0} ", original));
                }
            }

            stopwatch.Stop();
            Console.WriteLine("\nTime elapsed: {0} milliseconds", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        // Allows only a, i, and o to be by themselves in a sentence
        static string[] nonSingleLetters = new string[23] { "b", "c", "d", "e", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        static public bool singleLetter (string[] line)
        {
            foreach (string word in line)
                foreach (string letter in nonSingleLetters)
                    if (letter.Equals(word))
                        return false;

            return true;
        }

        static char[] vowels = new char[6] { 'a', 'e', 'i', 'o', 'u', 'y' };
        static char[] lastLetters = new char[4] { 'i', 'j', 'u', 'v' };
        static int fourConsinents = 0;
        static bool vowelsPresent = false;
        
        static public bool properEnglish(string[] line)
        {            
            foreach (string word in line)
            {
                vowelsPresent = false;
                fourConsinents = 0;

                char[] characters = word.ToCharArray();

                foreach (char c in characters)
                {
                    if (isConsonant(c))
                        fourConsinents++;
                    else
                    {
                        vowelsPresent = true;
                        fourConsinents = 0;
                    }

                    if (fourConsinents == 4)
                        return false;
                }

                if (!vowelsPresent)
                    return false;

                foreach (char l in lastLetters)
                    if (l.Equals(characters[characters.Length - 1]))
                        return false;
            }

            return true;
        }

        static public bool isConsonant(char c)
        {
            foreach (char v in vowels)
                if (c.Equals(v))
                    return false;

            return true;
        }
    }
}
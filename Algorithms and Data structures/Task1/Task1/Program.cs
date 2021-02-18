using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream input = File.OpenRead("lorem.txt");
            StreamReader reader = new StreamReader(input);
            string Fulltext = reader.ReadToEnd().ToString();
            string[] words = Fulltext.Split(' ');

            Dictionary<string, int> wordCounted = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                escapeSpecialChars(words[i]);
                wordCounted[words[i]] += 1;
            }

            static string escapeSpecialChars(string word)
            {
                string[] specialChars = new string[] { ",","." };

                for (int i = 0; i < word.Length; i++)
                {
                    if (word.IndexOf(specialChars) >  -1)
                    {
                        count += 1;
                    }
                }
                return count;
            }
        }
    }
}

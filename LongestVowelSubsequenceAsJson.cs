using System;
using System.Collections.Generic;
using System.Text.Json;

namespace LongestVowelSubsequence
{
    internal class Program
    {
        private static readonly HashSet<char> Vowels = new() { 'a', 'e', 'i', 'o', 'u' };

        public static string LongestVowelSubsequenceAsJson(List<string> words)
        {
            if (words == null || words.Count == 0)
                return "[]";

            var result = new List<object>();

            foreach (var word in words)
            {
                string longest = "";
                string current = "";

                foreach (char c in word)
                {
                    if (Vowels.Contains(char.ToLower(c)))
                    {
                        current += c;
                        if (current.Length > longest.Length)
                            longest = current;
                    }
                    else
                    {
                        current = "";
                    }
                }

                result.Add(new
                {
                    word,
                    sequence = longest,
                    length = longest.Length
                });
            }

            return JsonSerializer.Serialize(result);
        }

        // Test etmek için Main
        static void Main(string[] args)
        {
            var words = new List<string> { "hello", "beautiful", "sequence", "sky" };
            string jsonResult = LongestVowelSubsequenceAsJson(words);
            Console.WriteLine(jsonResult);
        }
    }
}

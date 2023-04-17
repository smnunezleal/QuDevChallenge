using QuDevChallenge;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var matrix = new List<string> { "chill", "coldr", "windo", "abcdg" };
        var wordstream = new List<string> { "chill", "cold", "wind", "foo", "bar", "baz", "qux", "quux", "quuz", "corge", "cold", "wind" };
        var finder = new WordFinder(matrix);
        var result = finder.Find(wordstream);
        Console.WriteLine("Top 10 words found:");
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }
}

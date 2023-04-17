using System;
using System.Collections.Generic;
using Xunit;


namespace QuDevChallenge
{
    public class WordFinderTests
    {
        [Fact]
        public void TestEmptyMatrix()
        {
            var matrix = new List<string>();
            var wordstream = new List<string> { "chill", "cold", "wind", "foo", "bar", "baz", "qux", "quux", "quuz", "corge" };
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);
            Assert.Empty(result);
        }

        [Fact]
        public void TestEmptyWordstream()
        {
            var matrix = new List<string> { "chill", "cold", "wind", "foo" };
            var wordstream = new List<string>();
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);
            Assert.Empty(result);
        }

        [Fact]
        public void TestMatrixSize1()
        {
            var matrix = new List<string> { "c" };
            var wordstream = new List<string> { "c", "a", "t" };
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);
            Assert.Equal(new List<string> { "c" }, result);
        }

        [Fact]
        public void TestHorizontalWords()
        {
            var matrix = new List<string> { "chill", "coldr", "windo", "abcdg" };
            var wordstream = new List<string> { "chill", "cold", "wind", "foo", "bar", "baz", "qux", "quux", "quuz", "corge", "cold", "wind" };
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);
            var expected = new List<string> { "cold", "wind", "chill" };
            Assert.Equivalent(expected, result, true);
        }

        [Fact]
        public void TestVerticalWords()
        {
            var matrix = new List<string> { "cwbaa", "hclws", "ionid", "llonf", "ldedg" };
            var wordstream = new List<string> { "chill", "cold", "wind", "foo", "bar", "baz", "qux", "quux", "quuz", "corge", "cold", "wind" };
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);
            Assert.Equivalent(new List<string> { "cold", "wind", "chill" }, result);
        }

        [Fact]
        public void TestRepeatedWords()
        {
            var matrix = new List<string> { "chill", "coldr", "windo", "abcdg" };
            var wordstream = new List<string> { "cold", "wind", "chill", "cold", "wind", "chill", "cold", "wind", "chill", "foo", "bar", "baz", "qux", "quux", "quuz", "corge", "cold", "wind", "chill" };
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);
            Assert.Equivalent(new List<string> { "cold", "wind", "chill" }, result);
        }

        [Fact]
        public void TestWordsWithDifferentCases()
        {
            var matrix = new List<string> { "cHiLl", "cOLdR", "WIndO", "AbcDg" };
            var wordstream = new List<string> { "CHILL", "cold", "Wind", "Foo", "bar", "baz", "qux", "quux", "quuz", "corge", "Cold", "wind" };
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);
            Assert.Equivalent(new List<string> { "cold", "Wind", "CHILL" }, result);
        }

    }
}

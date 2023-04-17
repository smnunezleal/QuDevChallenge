using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDevChallenge
{
    public class WordFinder
    {
        private readonly char[,] _matrix;
        private readonly int _size;

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix.Count() > 0)
            {

                _size = matrix.First().Length;
                _matrix = new char[_size, _size];

                int i = 0;
                foreach (string row in matrix)
                {
                    int j = 0;
                    foreach (char c in row)
                    {
                        _matrix[i, j] = c;
                        j++;
                    }
                    i++;
                }
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var wordCounts = new Dictionary<string, int>();
            foreach (string word in wordstream)
            {
                if (wordCounts.ContainsKey(word))
                {
                    continue; // Don't count the same word twice
                }

                // Search for word horizontally
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j <= _size - word.Length; j++)
                    {
                        string candidate = new string(Enumerable.Range(j, word.Length).Select(x => _matrix[i, x]).ToArray());
                        if (candidate.Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            wordCounts[word] = 1;
                            break;
                        }
                    }
                    if (wordCounts.ContainsKey(word))
                    {
                        break;
                    }
                }

                // Search for word vertically
                for (int i = 0; i <= _size - word.Length; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        string candidate = new string(Enumerable.Range(i, word.Length).Select(x => _matrix[x, j]).ToArray());
                        if (candidate.Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            wordCounts[word] = 1;
                            break;
                        }
                    }
                    if (wordCounts.ContainsKey(word))
                    {
                        break;
                    }
                }
            }

            return wordCounts.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(10).Select(x => x.Key);
        }
    }
}




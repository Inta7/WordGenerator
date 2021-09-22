using System.Collections.Generic;

namespace WordGenerator.Core
{
    public class Sorter
    {
        private string _wordForSort;
        public Sorter(string wordForSort)
        {
            _wordForSort = wordForSort;
        }
        
        public IEnumerable<string> Sorting()
        {
            if (_wordForSort != null)
            {
                return AllPermutations(_wordForSort.ToCharArray(), new List<char>());

            }

            return null;

        }

        private static IEnumerable<string> AllPermutations(char[] availableChars, List<char> permute)
        {
            var result = new List<string>();

            if (availableChars.Length == 0)
            {
                result.Add(new string(permute.ToArray()));
                permute.RemoveAt(permute.Count - 1);
                return result;
            }

            for (var index = 0; index < availableChars.Length; index++)
            {
                var letter = availableChars[index];
                permute.Add(letter);
                result.AddRange(AllPermutations(ConstructNew(availableChars, index), permute));

            }
            if (permute.Count > 0)
                permute.RemoveAt(permute.Count - 1);
            return result;
        }

        private static char[] ConstructNew(char[] prev, int fallIndex)
        {
            var array = new char[prev.Length - 1];
            var found = false;
            for (var i = 0; i < prev.Length; i++)
            {
                if (i == fallIndex)
                {
                    found = true;
                    continue;
                }
                array[found ? i - 1 : i] = prev[i];
            }

            return array;
        }
    }
}








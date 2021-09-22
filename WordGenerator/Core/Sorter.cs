using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;

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


//        public string Sorting()
//        {
//            string word = _wordForSort;
//            string a = "null";
//            PrintResult(word);
//            void PrintResult(string word)
//            {
//                byte[] array = Encoding.Default.GetBytes(word.ToCharArray());
//                array = array.OrderBy(x => x).ToArray();
                
//                while (true)
//                {
//                    int i = NarayanaNextPerm(array);
//                    if (i == 0) break;
//                    a =((Encoding.Default.GetString(array)));
//                }
//            }
//            return a;

//            static int NarayanaNextPerm(byte[] a)
//            {
//                int i, k, t;
//                byte tmp;
//                int n = a.Length;
//                for (k = n - 2; (k >= 0) && (a[k] >= a[k + 1]); k--) ;
//                if (k == -1)
//                    return 0;
//                for (t = n - 1; (a[k] >= a[t]) && (t >= k + 1); t--) ;
//                tmp = a[k];
//                a[k] = a[t];
//                a[t] = tmp;
//                for (i = k + 1; i <= (n + k) / 2; i++)
//                {
//                    t = n + k - i;
//                    tmp = a[i];
//                    a[i] = a[t];
//                    a[t] = tmp;
//                }

//                return i;
//            }

           
//        }
        
//    }
//}







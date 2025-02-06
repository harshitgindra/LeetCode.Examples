using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2021.Sept
{
    public class Maximum_Length_of_a_Concatenated_String_with_Unique_Characters
    {
        private int _maxLength;

        public int MaxLength(IList<string> arr)
        {
            _maxLength = 0;
            int i = 0;
            //***
            //*** Remove any entries in arr containing duplicate characters
            //***
            while (i < arr.Count)
            {
                if (_IsUnique(arr[i]))
                {
                    i++;
                }
                else
                {
                    arr.RemoveAt(i);
                }
            }
            //***
            //*** Concatenate the strings and check if the chars are still unique
            //***
            _Helper(arr, "", 0);
            return _maxLength;
        }

        private void _Helper(IList<string> arr, string s, int index)
        {
            if (index <= arr.Count)
            {
                //***
                //*** Running the iteration to concatenate strings and check for unique characters
                //***
                for (int i = index; i < arr.Count; i++)
                {
                    if (_IsUnique(s + arr[i]))
                    {
                        //***
                        //*** Concatenated string is unique, try appending more entries for larger string
                        //***
                        _Helper(arr, s + arr[i], i + 1);
                    }
                }
                //***
                //*** Calculate the size of max length of unique characters in a string s
                //***
                _maxLength = Math.Max(s.Length, _maxLength);
            }
        }

        private bool _IsUnique(string s)
        {
            bool returnValue = true;
            //***
            //*** Order the string in asc order and check for duplicate adjacent characters
            //***
            var arr = s.OrderBy(x => x).ToArray();
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }

        [Test(Description ="https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Maximum Length of a Concatenated String with Unique Characters")]
        [TestCaseSource("Input")]
        public void Test1((int Output, IList<string> Input) item)
        {
            var response = MaxLength(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, IList<string> Input)> Input
        {
            get
            {
                return new List<(int Output, IList<string> Input)>()
                {
                    (6, new List<string>()
                    {
                        "cha",
                        "r",
                        "act",
                        "ers"
                    }),
                    (26, new List<string>()
                    {
                        "abcdefghijklmnopqrstuvwxyz"
                    }),
                };
            }
        }
    }
}
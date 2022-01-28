using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Leetcode.Problems._2022.January
{
    public class WordDictionary
    {
        private CustomTree _root;

        public WordDictionary()
        {
            _root = new CustomTree();
        }

        public void AddWord(string word)
        {
            int i = 0;
            CustomTree temp = _root;
            while (i < word.Length)
            {
                char c = word[i];
                if (!temp.Children.ContainsKey(c))
                {
                    temp.Children.Add(c, new CustomTree());
                }

                //***
                //*** Replacing the parent node
                //***
                temp = temp.Children[c];
                i++;
            }

            temp.IsEnd = true;
        }

        public bool Search(string word)
        {
            int i = 0;
            List<CustomTree> trees = new List<CustomTree>()
            {
                _root
            };
            while (i < word.Length)
            {
                char c = word[i];
                //***
                //*** Temp variable to hold the values of next batch of nodes
                //***
                List<CustomTree> temp = new List<CustomTree>();
                foreach (var item in trees)
                {
                    //***
                    //*** if the char c is available in the children, add it to be processed next
                    //***
                    if (item.Children.ContainsKey(c))
                    {
                        temp.Add(item.Children[c]);
                    }
                    //***
                    //*** Search is a '.', add all children to be searched in next batch
                    //***
                    else if (c == '.')
                    {
                        temp.AddRange(item.Children.Values);
                    }
                }

                //***
                //*** Overwrite the trees variable with the next batch of custom trees
                //***
                trees = temp;
                i++;
            }

            //***
            //*** Return true if there are any trees matching the pattern with IsEnd == true
            //***
            return trees.Any(x => x.IsEnd);
        }

        public class CustomTree
        {
            public IDictionary<char, CustomTree> Children { get; }

            public bool IsEnd { get; set; }

            public CustomTree()
            {
                Children = new Dictionary<char, CustomTree>();
            }
        }
    }

    public class Testing
    {
        [Test(Description = "https://leetcode.com/problems/design-add-and-search-words-data-structure/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Design Add and Search Words Data Structure")]
        public void Test1()
        {
            WordDictionary dict = new WordDictionary();
            dict.AddWord("bad");
            dict.AddWord("dad");
            dict.AddWord("mad");
            dict.AddWord("pad");
            Assert.IsTrue(dict.Search("bad"));
            Assert.IsFalse(dict.Search("sad"));
            Assert.IsTrue(dict.Search(".ad"));
            Assert.IsTrue(dict.Search("b.."));
        }
    }
}
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Easy
{
    class Unique_Email_Addresses
    {
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> result = new HashSet<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                result.Add(Read(emails[i]));
            }
            return result.Count();
        }

        private string Read(string str)
        {
            var arry = str.ToList();
            bool plusSpotted = false;
            int i = 0;
            while (i < str.Length)
            {
                if (arry[i] == '@')
                {
                    break;
                }
                else if (plusSpotted || arry[i] == '.')
                {
                    arry.RemoveAt(i);
                }
                else if (arry[i] == '+')
                {
                    arry.RemoveAt(i);
                    plusSpotted = true;
                }
                else
                {
                    i++;
                }
            }

            return string.Join("", arry);
        }

        [Test(Description = "https://leetcode.com/problems/unique-email-addresses/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Unique Email Addresses")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string[] Input) item)
        {
            var response = NumUniqueEmails(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string[] Input)> Input
        {
            get
            {
                return new List<(int Output, string[] Input)>()
                {
                    (1, new string[]{ "test.email+alex@leetcode.com", "test.email@leetcode.com"}),
                    (2, new string[]{ "test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"}),
                    (2, new string[]{"fg.r.u.uzj+o.pw@kziczvh.com","r.cyo.g+d.h+b.ja@tgsg.z.com","fg.r.u.uzj+o.f.d@kziczvh.com","r.cyo.g+ng.r.iq@tgsg.z.com","fg.r.u.uzj+lp.k@kziczvh.com","r.cyo.g+n.h.e+n.g@tgsg.z.com","fg.r.u.uzj+k+p.j@kziczvh.com","fg.r.u.uzj+w.y+b@kziczvh.com","r.cyo.g+x+d.c+f.t@tgsg.z.com","r.cyo.g+x+t.y.l.i@tgsg.z.com","r.cyo.g+brxxi@tgsg.z.com","r.cyo.g+z+dr.k.u@tgsg.z.com","r.cyo.g+d+l.c.n+g@tgsg.z.com","fg.r.u.uzj+vq.o@kziczvh.com","fg.r.u.uzj+uzq@kziczvh.com","fg.r.u.uzj+mvz@kziczvh.com","fg.r.u.uzj+taj@kziczvh.com","fg.r.u.uzj+fek@kziczvh.com"}),
                };
            }
        }
    }
}

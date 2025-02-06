using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class MyCalendar
    {
        private (int Start, int End)[] _slots;
        private int slotsUsed = 0;

        public MyCalendar()
        {
            _slots = new (int Start, int End)[1000];
        }

        public bool Book(int start, int end)
        {
            for (int i = 0; i < slotsUsed; i++)
            {
                if (end <= _slots[i].Start || start >= _slots[i].End)
                {
                }
                else
                {
                    return false;
                }
            }

            _slots[slotsUsed++] = (start, end);

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/my-calendar-i/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("My Calendar 1")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (int, int) Input) item)
        {
            var response = this.Book(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (int, int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int, int) Input)>()
                {

                    (true, (10,20)),
                    (false, (15,20)),
                    (true, (20,30)),
                };
            }
        }
    }
}

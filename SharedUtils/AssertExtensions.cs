namespace LeetCode.SharedUtils
{
    public static class AssertExtensions
    {
        public static void AreListnodesEqual(ListNode node1, ListNode node2)
        {
            if (_CheckIfListnodesAreEqual(node1, node2))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        private static bool _CheckIfListnodesAreEqual(ListNode node1, ListNode node2)
        {
            bool returnValue = true;

            if (node1 != null && node2 != null)
            {
                if (node1.val == node2.val)
                {
                    returnValue = _CheckIfListnodesAreEqual(node1.next, node2.next);
                }
                else
                {
                    returnValue = false;
                }
            }
            else if (node1 == null && node2 == null)
            {

            }
            else
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}

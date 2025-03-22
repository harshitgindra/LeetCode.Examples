namespace LeetCode.EasyProblems;

public class FruitsIntoBasketsII
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) 
    {
        int n = fruits.Length;
        int rem = 0;

        for (int i = 0; i < n; i++) 
        {
            bool placed = false;
            for (int j = 0; j < n; j++) 
            {
                if (baskets[j] != -1 && fruits[i] <= baskets[j]) 
                {
                    baskets[j] = -1;
                    placed = true;
                    break;
                }
            }

            if (!placed)
                rem++;
        }

        return rem;
    }
    
    [Test(Description = "https://leetcode.com/problems/fruits-into-baskets-ii/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Fruits into Baskets II")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, (int[], int[]) Input) item)
    {
        var response = NumOfUnplacedFruits(item.Input.Item1, item.Input.Item2);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, (int[], int[]) Input)> Input =>
        new List<(int Output, (int[], int[]) Input)>()
        {
            (1, ([4,2,5], [3,5,4])),
        };
}
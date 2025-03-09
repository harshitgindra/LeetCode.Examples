using NUnit.Framework.Legacy;

namespace Medium;

public class RegionsCutBySlashes
{
    public int RegionsBySlashes(string[] grid)
    {
        var lookup = new int[grid.Length * 3][];

        for (int i = 0; i < grid.Length; i++)
        {
            lookup[i * 3] = new int[grid.Length * 3];
            lookup[i * 3 + 1] = new int[grid.Length * 3];
            lookup[i * 3 + 2] = new int[grid.Length * 3];
            for (int j = 0; j < grid.Length; j++)
            {
                char v = grid[i][j];

                if (v == '\\')
                {
                    lookup[i * 3][j * 3] = 1;
                    lookup[i * 3 + 1][j * 3 + 1] = 1;
                    lookup[i * 3 + 2][j * 3 + 2] = 1;
                }
                else if (v == '/')
                {
                    lookup[i * 3][j * 3 + 2] = 1;
                    lookup[i * 3 + 1][j * 3 + 1] = 1;
                    lookup[i * 3 + 2][j * 3] = 1;
                }
            }
        }

        int retValue = 0;
        for (int i = 0; i < lookup.Length; i++)
        {
            for (int j = 0; j < lookup.Length; j++)
            {
                if (lookup[i][j] == 0)
                {
                    retValue++;
                    _Helper(lookup, i, j);
                }
            }
        }

        return retValue;
    }

    private void _Helper(int[][] lookup, int i , int j)
    {
        if (i > -1 && j > -1 && i < lookup.Length && j < lookup.Length && lookup[i][j] == 0)
        {
            lookup[i][j] = 1;
            _Helper(lookup, i+1, j); // right
            _Helper(lookup, i, j+1); // bottom
            _Helper(lookup, i-1, j); // left
            _Helper(lookup, i, j-1); // top
        }
    }
    
    [Test(Description = "https://leetcode.com/problems/regions-cut-by-slashes/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Regions cut by slashes")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, string[] Input) item)
    {
        var response = RegionsBySlashes(item.Input);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(int Output, string[] )> Input
    {
        get
        {
            return new List<(int Output, string[] Input)>()
            {
                (2, new String[] {" /","/ "}),
                (5, new String[] {"/\\","\\/"}),
            };
        }
    }
}
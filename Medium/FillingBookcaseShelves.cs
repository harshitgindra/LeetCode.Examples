namespace Medium;

public class FillingBookcaseShelves
{
    private int[] _dp;
    private int[][] _books;
    private int _shelfWidth;

    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        _shelfWidth = shelfWidth;
        _books = books;
        _dp = new int[books.Length];
        for (int i = 0; i < books.Length; i++)
        {
            _dp[i] = Int32.MaxValue;
        }

        _Helper(0);
        return _dp[0];
    }

    private int _Helper(int i)
    {
        if (i == _books.Length)
        {
            return 0;
        }

        if (_dp[i] != Int32.MaxValue)
        {
            return _dp[i];
        }

        int tmpWidth = _shelfWidth;
        int maxShelfHeight = 0;
        for (int j = i; j < _books.Length; j++)
        {
            var book = _books[j];
            if (tmpWidth < book[0])
            {
                break;
            }

            tmpWidth -= book[0];
            maxShelfHeight = Math.Max(maxShelfHeight, book[1]);
            _dp[i] = Math.Min( _dp[i],_Helper(j + 1) + maxShelfHeight );
        }

        return _dp[i];
    }

    [Test(Description = "https://leetcode.com/problems/filling-bookcase-shelves/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Filling bookcase shelves")]
    [TestCaseSource("Input")]
    public void Test1((int Output, (int[][] books, int shelfWidth) Input) item)
    {
        var response = MinHeightShelves(item.Input.books, item.Input.shelfWidth);
        Assert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(int Output, (int[][] books, int shelfWidth) Input)> Input
    {
        get
        {
            return new List<(int Output, (int[][] books, int shelfWidth) Input)>()
            {
                (6, (new int[][]
                {
                    new int[] { 1, 1 },
                    new int[] { 2, 3 },
                    new int[] { 2, 3 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 2 },
                }, 4)),
                (4, (new int[][]
                {
                    new int[] { 1, 3 },
                    new int[] { 2, 4 },
                    new int[] { 3, 2 },
                }, 6)),
            };
        }
    }
}
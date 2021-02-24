namespace LeetCode.Easy
{
    public class Flood_Fill
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            image = FloodFill(image, sr, sc, image[sr][sc], newColor, image.Length, image[0].Length);
            return image;
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int oldColor, int newColor, int iMax, int jMax)
        {
            if (sr < 0 || sr >= iMax || sc < 0 || sc >= jMax || image[sr][sc] == newColor || image[sr][sc] != oldColor)
            {
                return image;
            }

            image[sr][sc] = newColor;

            image = FloodFill(image, sr + 1, sc, oldColor, newColor, iMax, jMax);
            image = FloodFill(image, sr - 1, sc, oldColor, newColor, iMax, jMax);
            image = FloodFill(image, sr, sc + 1, oldColor, newColor, iMax, jMax);
            image = FloodFill(image, sr, sc - 1, oldColor, newColor, iMax, jMax);

            return image;
        }
    }
}
namespace LeetCode.May
{
    public class CheckIfItIsAStraightLine
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length <= 2)
            {
                return true;
            }

            var firstRec = coordinates[0];
            var secondRec = coordinates[1];

            double slope = Math.Abs((secondRec[1] - firstRec[1]) / (double) (secondRec[0] - firstRec[0]));

            for (int i = 1; i < coordinates.Length - 1; i++)
            {
                var record = coordinates[i];
                var nextRecord = coordinates[i + 1];

                var newSlope = Math.Abs((nextRecord[1] - record[1]) / (double) (nextRecord[0] - record[0]));
                if (slope != newSlope)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
namespace LeetCode.MediumProblems;

public class ConstructQuadTree
{
    public Node Construct(int[][] grid)
    {
        // Start the recursive construction from the entire grid
        return Construct(grid, 0, 0, grid.Length);
    }

    public Node Construct(int[][] grid, int i, int j, int length)
    {
        // Check if the current section has all the same values
        if (IsSame(grid, i, j, length))
        {
            // Create a leaf node with the value of the first cell in this section
            return new Node(grid[i][j] == 1, true);
        }
        else
        {
            // Create a non-leaf node
            Node node = new Node(false, false);

            // Divide the current section into four quadrants and construct nodes for each
            int halfLength = length / 2;
            node.topLeft = Construct(grid, i, j, halfLength);
            node.topRight = Construct(grid, i, j + halfLength, halfLength);
            node.bottomLeft = Construct(grid, i + halfLength, j, halfLength);
            node.bottomRight = Construct(grid, i + halfLength, j + halfLength, halfLength);

            return node;
        }
    }
    private bool IsSame(int[][] grid, int row, int column, int length)
    {
        // Get the value of the first cell to compare against
        int value = grid[row][column];

        // Check every cell in the section
        for (int i = row; i < row + length; i++)
        {
            for (int j = column; j < column + length; j++)
            {
                // If any cell has a different value, return false
                if (grid[i][j] != value)
                {
                    return false;
                }
            }
        }

        // All cells have the same value
        return true;
    }
}

/// <summary>
/// Definition for a Quadtree node.
/// </summary>
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node(bool _val = false, bool _isLeaf = false)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
}
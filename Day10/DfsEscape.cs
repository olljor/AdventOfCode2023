using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10;

/*  Solution "inspired" from GFGs solution 
*   https://www.geeksforgeeks.org/depth-first-traversal-dfs-on-a-2d-array/
*/

internal class DfsEscape
{
    static int ROW = PipeSystem.pipeSystem.Count;
    static int COL = PipeSystem.pipeSystem.First().Count;

    // Initialize direction vectors
    static int[] dRow = { 0, 1, 0, -1 };
    static int[] dCol = { -1, 0, 1, 0 };
    
    internal bool TryToEscape(int row, int col)
    {
        int startRow = row;
        int startCol = col;

        char[,] grid = Day10Main.traversedMap;

        bool[,] vis = new bool[ROW, COL];
        for (int i = 0; i < PipeSystem.pipeSystem.Count; i++)
        {
            for (int j = 0; j < PipeSystem.pipeSystem.First().Count; j++)
            {
                vis[i, j] = false;
            }
        }

        return DFS(startRow, grid, startCol, vis);
    }

    private bool DFS(int row, char[,] grid, int col, bool[,] vis)
    {
        // Initialize a stack of pairs and
        // push the starting cell into it
        Stack st = new Stack();
        st.Push(new Tuple<int, int>(row, col));

        // Iterate until the
        // stack is not empty
        while (st.Count > 0)
        {
            // Pop the top pair
            Tuple<int, int> curr = (Tuple<int, int>)st.Peek();
            st.Pop();

            row = curr.Item1;
            col = curr.Item2;

            // If cell is out of bounds
            if (row < 0 || col < 0 ||
                row >= ROW || col >= COL)
                return false;

            // Checks if its a wall
            if (grid[row, col] != '\0')
                continue;

            // Check if the current popped
            // cell is a valid cell or not
            if (vis[row, col])
                continue;

            // Mark the current
            // cell as visited
            vis[row, col] = true;

            // Push all the adjacent cells
            for (int i = 0; i < 4; i++)
            {
                int adjx = row + dRow[i];
                int adjy = col + dCol[i];
                st.Push(new Tuple<int, int>(adjx, adjy));
            }
        }
        return true;
    }
}

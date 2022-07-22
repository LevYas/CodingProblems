namespace CodingProblems.Graphs;

// 79. Word Search
// Given an m x n grid of characters board and a string word, return true if word exists in the grid.
// The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are
//      horizontally or vertically neighboring. The same letter cell may not be used more than once.
// https://leetcode.com/problems/word-search/

public class WordFinder
{
    public bool Exist(char[][] board, string word)
    {
        bool[][] visited = new bool[board.Length][];

        for (int i = 0; i < visited.Length; i++)
            visited[i] = new bool[board[i].Length];

        // Length is only 15, so recursive DFS would work well
        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                if (check(board, word, visited, r, c, 0))
                    return true;
            }
        }

        return false;
    }

    private bool check(char[][] board, string word, bool[][] visited, int r, int c, int currentLetter)
    {
        if (currentLetter == word.Length - 1 && word[currentLetter] == board[r][c])
            return true;

        if (word[currentLetter] != board[r][c])
            return false;

        visited[r][c] = true;

        foreach ((int nr, int nc) in getNeighborCoord(board, r, c))
        {
            if (visited[nr][nc])
                continue;

            if (check(board, word, visited, nr, nc, currentLetter + 1))
                return true;
        }

        visited[r][c] = false;
        return false;
    }

    private IEnumerable<(int nr, int nc)> getNeighborCoord(char[][] board, int r, int c)
    {
        if (r > 0)
            yield return (r - 1, c);

        if (c > 0)
            yield return (r, c - 1);

        if (r < board.Length - 1)
            yield return (r + 1, c);

        if (c < board[r].Length - 1)
            yield return (r, c + 1);
    }
}

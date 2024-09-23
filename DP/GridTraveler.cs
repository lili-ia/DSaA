// Say that you are a traveller on a 2D grid. You begin in the
// top-left corner and your goal is to travel to the bottom-right 
// corner. You may only move down or right.

// In how many ways can you travel to the goal on a grid with
// dimensions m * n?
public class GridTraveler
{

    public static Dictionary<string, long> memo = new Dictionary<string, long>() { };

    public static long Memoization(int m, int n)
    {
        

        if (m == 1 || n == 1)
            return 1;
        if (m == 0 || n == 0)
            return 0;

        string key = m.ToString() + ' ' + n.ToString();

        if (memo.ContainsKey(key))
            return memo[key];

        memo[key] = Memoization(m - 1, n) + Memoization(m, n - 1);

        return memo[key];
    }
}

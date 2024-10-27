public class Knapsack
{
    public static void Solution(int w, int n, int[] weights, int[] prices)
    {
        int[,] dp = new int[n + 1, w + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= w; j++)
            {
                int newWeight = j - weights[i - 1];
                
                if (weights[i - 1] <= j && newWeight >= 0)
                    dp[i, j] = Math.Max(prices[i - 1] + dp[i - 1, newWeight], dp[i - 1, j]);
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }

        
        
        PrintThings(n, w, dp, weights);
        
    }

    public static void PrintThings(int n, int w, int[,] answers, int[] weights)
    {
        if (answers[n, w] == 0)
            return;

        if (answers[n - 1, w] != answers[n, w])
        {
            
            PrintThings(n - 1, w - weights[n - 1], answers, weights);
            Console.Write($"{n} ");
            
        }
        else
        {
            PrintThings(n - 1, w, answers, weights);
        }
        
    }
    
}

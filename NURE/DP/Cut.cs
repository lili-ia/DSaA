public class Cut
{
    // маємо стрижень довжиною n, таблицю цін для n(i)
    // знайти максимальний прибуток при розрізанні стрижня та продажу сегментів
    private static readonly int[] prices = [1, 5, 8, 9, 10, 17, 17, 20, 24, 30];
    
    public static int Naive(int n )
    {
        if (n == 0)
            return 0;

        int result = 0;

        for (int i = 1; i <= n; i++)
        {
            result = int.Max(result, prices[i - 1] + Naive(n - i));
        }

        return result;
    }

    public static int[] memo;
    
    public static int Memoization(int n )
    {
        memo = new int[n + 1];
        Array.Fill<int>(memo, -1);

        return MemoizationCut(n);
    }

    public static int MemoizationCut(int n)
    {
        if (n == 0)
            return 0;

        if (memo[n] != -1)
            return memo[n];

        int result = 0;
        
        for (int i = 1; i <= n; i++)
        {
            result = int.Max(result, prices[i - 1] + MemoizationCut(n - i));
        }

        memo[n] = result;

        return result;
    }

    public static int Tabulation(int n)
    {
        int[] results = new int[n + 1];

        results[0] = 0;
        
        for (int j = 1; j <= n; j++)
        {
            int result = 0;
            
            for (int i = 1; i <= j && i <= prices.Length; i++)
            {
                result = Math.Max(result, prices[i - 1] + results[j - i]);
            }


            results[j] = result;
        }


        return results[n];
    }
    
}

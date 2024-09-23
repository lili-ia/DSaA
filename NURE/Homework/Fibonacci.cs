public class Fibonacci
{

    // time complexity: O(2^n)
    public static int Naive(int n)
    {
        if (n <= 2)
            return 1;

        return Naive(n - 1) + Naive(n - 2);
    }



    private static Dictionary<long, long> fibVals = new() { { 0, 0 }, { 1, 1 } };
    
    // time complexity: O(n), space: O(n)
    public static long Memoization(long n)
    {
        if (!fibVals.ContainsKey(n))
            fibVals[n] = Memoization(n - 2) + Memoization(n - 1);
        return fibVals[n];
    }

}

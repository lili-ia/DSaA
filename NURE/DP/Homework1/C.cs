class Program
{
    private const int MOD = 1000000007; 
    private static int[,] MatrixMult(int[,] A, int[,] B, int size)
    {
        int[,] res = new int[size,size];
        
        for (int i = 0; i < size; i ++)
        {
            for (int j = 0; j < size; j ++)
            {
                long sum = 0;

                for (int k = 0; k < size; k++)
                {
                    sum += (long)A[i, k] * B[k, j];
                    sum %= MOD;
                }
                
                res[i, j] = (int)sum;
            }
        }
        
        return res;
    }

    private static int[,] MatrixPow(int[,] A, long pow, int size)
    {
        int[,] res = new int[size,size];

        for (int i = 0; i < size; i++)
            res[i, i] = 1;

        int[,] curr = A;

        while (pow > 0)
        {
            if (pow % 2 != 0)
                res = MatrixMult(res, curr, size);

            curr = MatrixMult(curr, curr, size);
            pow /= 2;
        }

        return res;
    }
    
    
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');

        int n = int.Parse(parts[0]);
        int m = int.Parse(parts[1]);
        long k = long.Parse(parts[2]);
        
        int[,] dp = new int[n,n];
        
        for (int i = 0; i < m; i++)
        {
            input = Console.ReadLine();
            parts = input.Split(' ');
            
            int a = int.Parse(parts[0]);
            int b = int.Parse(parts[1]);

            dp[a - 1, b - 1] ++;
        }

        int[,] resMatr = MatrixPow(dp, k, n);

        long result = 0;

        for (int j = 0; j < n; j++)
        {
            result += resMatr[0, j];
            result %= MOD;
        }

        Console.WriteLine(result);

    }
}

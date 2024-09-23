public class CanSum
{

    // function should return a boolean indicating wheteher or not it
    // is possible o generate the targetSum using numbers from the array.

    // you can use an element of the array as meny times as needed


    public static bool Recursive(int targetSum, int[] numbers)
    {
        if (targetSum == 0)
            return true;

        if (targetSum < 0)
            return false;

        foreach (int num in numbers) 
        { 
            int remainder = targetSum - num;
            if (Recursive(remainder, numbers) == true)
                return true;
        }

        return false;
    }

    public static Dictionary<int, bool> memo = new Dictionary<int, bool>() { };

    public static bool Memoization(int targetSum, int[] numbers)
    {
        if (memo.ContainsKey(targetSum))
            return memo[targetSum];

        if (targetSum == 0)
            return true;

        if (targetSum < 0)
            return false;

        foreach (int num in numbers)
        {
            int remainder = targetSum - num;
            if (Memoization(remainder, numbers) == true)
            {
                memo[targetSum] = true;
                return true;

            }
        }

        memo[targetSum] = false;
        return false;
    }
}

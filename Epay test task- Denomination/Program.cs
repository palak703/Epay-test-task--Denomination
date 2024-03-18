namespace Epay_test_task__Denomination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] denominations = { 100, 50, 10 };
            int targetSum = 370;
            int[] targetSumArray = new int[] { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            for (int i = 0; i < targetSumArray.Length; i++)
            {
                List<List<int>> combinations = FindCombinations(denominations, targetSumArray[i]);
                Console.WriteLine("All combinations of denominations to get a sum of " + targetSumArray[i] + ":");
                foreach (List<int> combination in combinations)
                {
                    Console.WriteLine(string.Join(", ", combination));
                }
                Console.WriteLine();
            }
        }

        static List<List<int>> FindCombinations(int[] denominations, int targetSum)
        {
            List<List<int>> combinations = new List<List<int>>();
            FindCombinationsRecursive(denominations, targetSum, new List<int>(), combinations, 0);
            return combinations;
        }

        static void FindCombinationsRecursive(int[] denominations, int remainingSum, List<int> currentCombination, List<List<int>> combinations, int startIndex)
        {
            if (remainingSum == 0)
            {
                combinations.Add(new List<int>(currentCombination));
                return;
            }
            for (int i = startIndex; i < denominations.Length; i++)
            {
                int denomination = denominations[i];
                if (remainingSum >= denomination)
                {
                    currentCombination.Add(denomination);
                    FindCombinationsRecursive(denominations, remainingSum - denomination, currentCombination, combinations, i);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }
    }
}

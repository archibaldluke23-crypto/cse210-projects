using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int[] solution = TwoSum([2,5,5,11], 10);
        int[] TwoSum(int[] nums, int target) 
        {
        
            int x = 1;
            for (int i = 0; i < nums.Length;)
            {
                int firstNum = nums[i];
                int secondNum = nums[x];
                if (firstNum + secondNum == target)
                {
                    int[] solution = [i,x];
                    return solution;
                }
                if (x < nums.Length - 1)
                {
                    x++;
                }
                else
                {
                    i++;
                    x = i + 1;
                }

            }
            return [];
        }
    }
}

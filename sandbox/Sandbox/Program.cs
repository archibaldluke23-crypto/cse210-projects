public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int k = 0;
        int lastNumber = 0;
        int indexAjustment = 0;
        int x = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            x = i - indexAjustment;
            if (x == 0)
            {
                lastNumber = nums[x];
            }
            else if (nums[x] != lastNumber)
            {
                lastNumber = nums[x];
            }
            else if (nums[x] == lastNumber)
            {
                k += 1;
                indexAjustment += 1;
                nums.SetValue(null, x);
                lastNumber = nums[x];
            }
            
        }
        Array.Sort(nums);
        return k;
    }
}
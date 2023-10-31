int[] nums = new int[] { 1, 1, 1, 2, -3 };
int x = 5;
int result = MinOperations(nums, x);
Console.WriteLine(result);

int MinOperations(int[] nums, int x)
{
    int left = 0;
    int right = nums.Length - 1;
    int target = -x;

    for (int i = 0; i < nums.Length; i++)
    {
        target += nums[i];
    }

    if (target == 0)
    {
        return nums.Length;
    }

    int minOperations = int.MaxValue;

    while (left <= right)
    {
        if (target == 0)
        {
            minOperations = Math.Min(minOperations, left + nums.Length - 1 - right);
            target += nums[left];
            left++;
        }
        else if (target > 0)
        {
            if (right < 0)
            {
                break;
            }
            target -= nums[right];
            right--;
        }
        else
        {
            target += nums[left];
            left++;
        }
    }

    return minOperations == int.MaxValue ? -1 : minOperations;
}
using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> result = new List<int>();
                for (int i = 0; i < nums.Length; i++) //whichever numbers are present, those indices are marked negative
                {
                    int index = Math.Abs(nums[i]) - 1;
                    if (index >= 0 && index < nums.Length && nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }
                // whichever indices were not marked are the numbers that are missing. 
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums) {
            try
            {
                int left = 0, right = nums.Length - 1;
                // using 2 pointers, one for odd numbers, one for even.
                while (left < right){
                    if (nums[left] % 2 > nums[right] % 2){
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                        //swapping numbers so that numbers on right are odd and on left are even.
                    }
                    if (nums[left] % 2 == 0) left++;
                    if (nums[right] % 2 == 1) right--;
                }
                return nums; //printing numers wiht even first, then odd.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                //finding the complement of each number by taking the help of hash map.
                for (int i = 0; i < nums.Length; i++){
                    int complement = target - nums[i];
                    if (map.ContainsKey(complement)){
                        return new int[] { map[complement], i }; //returning the indices to the function if complement is found
                    }
                     map[nums[i]] = i; //storing current number as key with index as 'i' as the value in the dictionary.
                }
                return new int[0]; //returning empty when no solution is found
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); //sorting the array nums
                int n = nums.Length; //storing the length of the array in the variable n
                //we calculate max by choosing between, product of 3 largest numbers or product of 2 smallest numbers(possibly negative) and the largest number
                return Math.Max(nums[n-1] * nums[n-2] * nums[n-3], nums[0] * nums[1] * nums[n-1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0";
                string binary = "";
                while (decimalNumber > 0){
                    binary = (decimalNumber % 2) + binary; //converting decimal to binary by getting the remainder from dividing by 2
                    decimalNumber /= 2;
                }
                return binary; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right){ //using binary search to find min in the rotated array
                    int mid = (left + right) / 2;
                    if (nums[mid] > nums[right]){
                        left = mid + 1;
                    }
                    else{
                        right=mid;
                    }
                }
                return nums[left]; //returning the min from rotated sorted array
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false; //negative numbers removed as they are not palindromes
                int original = x;
                int reversed = 0;
                while (x > 0){
                    int digit = x % 10;
                    reversed = reversed * 10 + digit; //reversing number by changing place values
                    x /= 10;
                }
                return original == reversed; //checking if reverse and original are same
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n == 0) return 0;
                if (n == 1) return 1;
                int a=0,b=1; //initializing first 2 numbers of fibbonacci series.
                for (int i = 2; i <= n; i++){
                    int temp = a + b; //calculating next number in the series
                    a=b;
                    b=temp;
                }
                return b; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

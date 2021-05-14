using System;

namespace Bubble_sort_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] intArray = { 1, 5, -1, 4, 0 };

            for (int turn = 0; turn < intArray.Length; turn++) // 배열의 길이까지 0부터 증가
            {
                int fixCount = turn; //몇번째 반복
                int checkLength = intArray.Length - fixCount - 1; //길이체크 = 배열의 길이 - 몇번째 반복 - 1
                checkLength = checkLength - 1; //오늘쪽 왼쪽 한쌍으로 검사. 최대길이 -1까지만

                for (int x = 0; x < checkLength; x++) //몇번째 체크
                {
                    int left = intArray[x];
                    int right = intArray[x + 1];
                    // 왼쪽이 더 크면 Swap
                    if (left > right)
                        Swap(x, intArray);
                }
            }
        }

        private static void Swap(int index, int[] intArray)
        {
            int leftIndex = index;
            int rightIndex = index + 1;

            int temp = intArray[leftIndex];
            intArray[leftIndex] = intArray[rightIndex];
            intArray[rightIndex] = temp;
        }
    }
}
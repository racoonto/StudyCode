using System;
using System.Collections.Generic;

namespace Bubble_sort
{
    internal class Program
    {
        public static int MAX_SIZE = 5;

        public static void Bubble_sort(List<int> list, int size)
        {
            int i, j, temp;

            for (i = size - 1; i > 0; i--)  // 4,3,2,1
            {
                //0 ~ (i-1)까지 반복
                for (j = 0; j < i; j++)
                {
                    //j번째와 j+1번째의 요소가 크기 순이 아니면 교환
                    if (list[j] < list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            int i;
            int size = MAX_SIZE;
            List<int> list = new List<int> { 7, 4, 5, 1, 3 };

            //버블 정렬 수행
            Bubble_sort(list, size);

            for (i = 0; i < size; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
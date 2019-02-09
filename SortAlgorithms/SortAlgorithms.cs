using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsOnSortAlgorithms
{
    class SortAlgorithms
    {

        public static void BubbleSort(int[] arr)
        {


            int temp = 0;

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }

            }
        }


        public static void SelectionSort(int[] ar)
        {
            //int[] ar = { 5, 3, 7, 2 };
            int n = ar.Length;
            for (int x = 0; x < n; x++)
            {
                int min_index = x;
                for (int y = x; y < n; y++)
                {
                    if (ar[min_index] > ar[y])
                    {
                        min_index = y;
                    }
                }
                int temp = ar[x];
                ar[x] = ar[min_index];
                ar[min_index] = temp;
            }

        }

        public static void Main(String[] args)
        {

            int[] arr = { 800, 11, 50, 771, 649, 770, 240, 9 };
            ////BubbleSort(arr);
            //for (int i = 0; i < arr.Length; i++)
            //Console.Write(arr[i] + " ");

            SelectionSort(arr);
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.ReadKey();
        }


    }
}
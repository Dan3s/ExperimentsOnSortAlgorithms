using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsOnSortAlgorithms
{
    public class SortAlgorithms
    {

        public void BubbleSort(int[] arr)
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


        public void SelectionSort(int[] ar)
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
        public int[] CreateVector()
        {
            int[] indexV = { 10, 100, 1000, 10000, 100000 };

            Random rnd = new Random();
            int index = rnd.Next(0, 4);
            int[] vector = new int[indexV[index]];

            Random rnd2 = new Random();
            int value = 0;

            for (int i = 0; i < vector.Length; i++)
            {
                value = rnd2.Next(0, indexV[index]);
                vector[i] = value;
            }

            return vector;


        }

        public bool DescendingOrder(int[] vector)
        {
            bool isOrdered = true;
            int last = vector[0];

            for (int i = 1; i < vector.Length; i++)
            {
                if (vector[i] > last) isOrdered = false;
                last = vector[i];
            }

            return isOrdered;
        }

        public bool AscendingOrder(int[] vector)
        {
            bool isOrdered = true;
            int last = vector[0];

            for (int i = 1; i < vector.Length; i++)
            {
                if (vector[i] < last) isOrdered = false;
                last = vector[i];
            }

            return isOrdered;
        }
		/*public static void Main(String[] args)
		{
			int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			int[] arr2 = { 9, 1, 2, 8, 3, 7, 4, 6, 5, 10 };
			SortAlgorithms sa = new SortAlgorithms();
			sa.BubbleSort(arr2);
			for (int z = 0; z < arr2.Length; z++)
			{
				Console.WriteLine(arr2[z] + " ");
			}
			Console.ReadKey();
		}*/


	}
}
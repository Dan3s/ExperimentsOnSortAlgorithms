using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExperimentsOnSortAlgorithms;


namespace SortAlgorithmsTests
{
	[TestClass]
	public class SortAlgorithmsTests
	{
		[TestMethod]
		public void TestMethodBubbleSort()
		{
			int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		
			int[] arr2 = { 9, 1, 2, 8, 3, 7, 4, 6, 5, 10 };
			SortAlgorithms sa = new SortAlgorithms();
			sa.BubbleSort(arr2);
			for (int z= 0; z<arr2.Length; z++) {
				Assert.AreEqual(arr2[z], arr[z]);
			}

		}

		[TestMethod]
		public void TestMethodSelectionSort()
		{
			int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			int[] arr2 = { 9, 1, 2, 8, 3, 7, 4, 6, 5, 10 };
			SortAlgorithms sa = new SortAlgorithms();
			sa.SelectionSort(arr2);
			for (int z = 0; z < arr2.Length; z++)
			{
				Assert.AreEqual(arr2[z], arr[z]);
			}

		}


	}
}

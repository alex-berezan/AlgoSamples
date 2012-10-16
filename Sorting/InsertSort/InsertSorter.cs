using System;
using System.Collections.Generic;

namespace Sorting.InsertSort
{
	public class InsertSorter
	{
		public int[] Sort(int[] array)
		{
			if (array == null || array.Length == 0)
				return new int[] { };

			int[] result = new int[array.Length];
			array.CopyTo(result, 0);

			SortArray(result);
			return result;
		}

		public void SortArray(int[] array)
		{
			if (array == null || array.Length == 0)
				return;

			for (int currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
			{
				var minValueIndex = GetMinValueIndex(array, startIndex: currentIndex);
				SwapArrayValues(array, currentIndex, minValueIndex);
			}
		}

		private static int GetMinValueIndex(int[] array, int startIndex)
		{
			int minIndex = startIndex;
			for (int right = startIndex; right < array.Length; right++)
			{
				int current = array[right];
				if (current < array[minIndex])
				{
					minIndex = right;
				}
			}
			return minIndex;
		}

		private static void SwapArrayValues(int[] array, int index1, int index2)
		{
			int temp = array[index1];
			array[index1] = array[index2];
			array[index2] = temp;
		}
	}
}
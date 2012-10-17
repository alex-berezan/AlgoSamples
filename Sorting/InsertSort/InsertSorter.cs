using System;
using System.Collections.Generic;
using Sorting.Helpers;

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
				array.SwapValues(currentIndex,minValueIndex);
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
	}
}
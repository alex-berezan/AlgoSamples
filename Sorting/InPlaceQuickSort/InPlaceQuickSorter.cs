using System;
using Sorting.DataTypes;
using Sorting.Helpers;

namespace Sorting.InPlaceQuickSort
{
	public class InPlaceQuickSorter
	{
		public int[] Sort(int[] array)
		{
			if (array == null)
				return new int[] { };

			Sort(new ArrayRef(array, 0, array.Length), new int[array.Length]);
			return array;
		}

		private static void Sort(ArrayRef array, int[] buffer)
		{
			if (array.Length == 0)
				return;

			if (array.Length == 1)
				return;

			if (array.Length == 2)
			{
				if (array[0] > array[1])
				{
					array.SwapValues(0, 1);
				}
				return;
			}

			double pivot;
			bool hasDistincts;
			int leftCount;
			AnalyzeArray(array, out pivot, out leftCount, out hasDistincts);

			if (!hasDistincts)
				return;

			ArrayRef left;
			ArrayRef right;
			ReorganizeArrays(array, buffer, pivot, leftCount, out left, out right);

			Sort(left, buffer);
			Sort(right, buffer);
		}

		private static void ReorganizeArrays(ArrayRef array, int[] buffer, double pivot, int leftCount, out ArrayRef left, out ArrayRef right)
		{
			left = array.SubArray(0, leftCount);
			right = array.SubArray(leftCount, array.Length - leftCount);

			array.FlushTo(buffer);

			int leftIndex = left.Length - 1;
			int rightIndex = right.Length - 1;
			for (int i = array.Length - 1; i >= 0; i--)
			{
				int item = buffer[i];
				if (item <= pivot)
				{
					left[leftIndex--] = item;
				}
				else
				{
					right[rightIndex--] = item;
				}
			}
		}

		private static void AnalyzeArray(ArrayRef array, out double pivot, out int leftCount, out bool hasDistincts)
		{
			int max = int.MinValue;
			int min = int.MaxValue;

			for (int i = array.Length - 1; i >= 0; i--)
			{
				max = Math.Max(max, array[i]);
				min = Math.Min(min, array[i]);
			}

			pivot = 1d * min / 2 + 1d * max / 2;
			hasDistincts = min != max;

			leftCount = 0;
			for (int i = array.Length - 1; i >= 0; i--)
			{
				leftCount += array[i] <= pivot ? 1 : 0;
			}
		}
	}
}
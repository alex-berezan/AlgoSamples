using System;
using System.Collections.Generic;
using System.Linq;
using Sorting.Helpers;

namespace Sorting.MergeSort
{
	public class MergeSorter
	{
		public int[] Sort(int[] array)
		{
			if (array == null || array.Length == 0)
				return new int[] { };

			if (array.Length == 1)
				return new List<int>(array).ToArray();

			if (array.Length == 2)
			{
				return array[1] < array[0]
					? new[] { array[1], array[0] }
					: new[] { array[0], array[1] };
			}

			int half = array.Length / 2;

			int[] left = array.Take(half).ToArray();
			int[] right = array.Skip(half).Take(array.Length - half).ToArray();

			int[] leftSorted = Sort(left);
			int[] rightSorted = Sort(right);

			int[] result = MergeSorted(leftSorted, rightSorted);

			return result;
		}

		private int[] MergeSorted(int[] left, int[] right)
		{
			int[] result = new int[left.Length + right.Length];

			int leftCurrent = 0;
			int rightCurrent = 0;

			for (int i = 0; i < result.Length; i++)
			{
				bool outOfLeft = !(leftCurrent < left.Length);
				bool outOfRight = !(rightCurrent < right.Length);

				if (!outOfLeft && (outOfRight || left[leftCurrent] < right[rightCurrent]))
				{
					result[i] = left[leftCurrent];
					leftCurrent++;
				}
				else
				{
					result[i] = right[rightCurrent];
					rightCurrent++;
				}
			}

			return result;
		}
	}
}
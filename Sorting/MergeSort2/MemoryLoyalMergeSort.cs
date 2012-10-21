using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Sorting.DataTypes;
using Sorting.Helpers;

namespace Sorting.MergeSort2
{
	public class MemoryLoyalMergeSort
	{
		private static readonly TaskFactory _taskFactory = new TaskFactory();

		public int[] Sort(int[] array)
		{
			if (array == null || array.Length == 0)
				return new int[] { };

			Sort(array, new ArrayRef(array, 0, array.Length), new int[array.Length]);
			return array;
		}

		private void Sort(int[] array, ArrayRef arrayRef, int[] buffer)
		{
			if (arrayRef.Length == 1)
				return;

			if (arrayRef.Length == 2)
			{
				if (arrayRef[1] < arrayRef[0])
					array.SwapValues(arrayRef.AbsoluteStartIndex + 0, arrayRef.AbsoluteStartIndex + 1);
				return;
			}

			int half = arrayRef.Length / 2;

			ArrayRef left = new ArrayRef(array, arrayRef.AbsoluteStartIndex, half);
			ArrayRef right = new ArrayRef(array, arrayRef.AbsoluteStartIndex + half, arrayRef.Length - half);

			bool shouldSortInParallel = right.Length > 2048;
			if (shouldSortInParallel)
			{
				Task sortRightTask = _taskFactory.StartNew(() => Sort(array, right, buffer));
				Sort(array, left, buffer);
				Task.WaitAll(sortRightTask);
			}
			else
			{
				Sort(array, right, buffer);
				Sort(array, left, buffer);
			}

			MergeSorted(array, left, right, buffer);
		}

		private void MergeSorted(int[] array, ArrayRef left, ArrayRef right, int[] buffer)
		{
			ArrayRef merged = new ArrayRef(buffer, left.AbsoluteStartIndex, left.Length + right.Length);

			int leftCurrent = 0;
			int rightCurrent = 0;

			for (int i = 0; i < merged.Length; i++)
			{
				bool outOfLeft = !(leftCurrent < left.Length);
				bool outOfRight = !(rightCurrent < right.Length);

				if (!outOfLeft && (outOfRight || left[leftCurrent] < right[rightCurrent]))
				{
					merged[i] = left[leftCurrent];
					leftCurrent++;
				}
				else
				{
					merged[i] = right[rightCurrent];
					rightCurrent++;
				}
			}

			int index = 0;
			for (int i = left.AbsoluteStartIndex; i < right.AbsoluteEndIndex; i++, index++)
			{
				array[i] = merged[index];
			} 
		}
	}
}
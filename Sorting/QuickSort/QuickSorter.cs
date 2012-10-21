using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sorting.Helpers;
using Sorting.InsertSort;

namespace Sorting.QuickSort
{
	public class QuickSorter
	{
		// TODO: write in-place implementation(via ArrayRef)
		public int[] Sort(int[] array)
		{
			if (array == null || array.Length == 0)
				return new int[] { };

			if (array.Length == 1)
				return new int[] { array[0] };

			if (array.Length == 2)
			{
				return array[0] > array[1]
					? new[] { array[1], array[0] }
					: array.ToArray();
			}

			double pivot;
			bool hasDistincts;
			AnalyzeArray(array, out pivot, out hasDistincts);

			if (!hasDistincts)
				return array.ToArray();

			int[] left = array.Where(i => i <= pivot).ToArray();
			int[] right = array.Where(i => 1d * i > pivot).ToArray();

			int[] leftSorted = Sort(left);
			int[] rightSorted = Sort(right);

			return leftSorted.Union(rightSorted).ToArray();
		}

		private void AnalyzeArray(int[] array, out double pivot, out bool hasDistincts)
		{
			int max = int.MinValue;
			int min = int.MaxValue;

			foreach (int a in array)
			{
				max = Math.Max(max, a);
				min = Math.Min(min, a);
			}

			pivot = 1d * min / 2 + 1d * max / 2;
			hasDistincts = min != max;
		}
	}
}
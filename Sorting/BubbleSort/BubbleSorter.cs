using System;
using System.Collections.Generic;
using Sorting.Helpers;

namespace Sorting.BubbleSort
{
	public class BubbleSorter
	{
		public int[] Sort(int[] array)
		{
			if (array == null || array.Length == 0)
				return new int[] { };

			int[] resultArray = new int[array.Length];
			array.CopyTo(resultArray, 0);

			for (int i = 1; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length - 1; j++)
				{
					if (resultArray[i] < resultArray[j])
					{
						resultArray.SwapValues(i, j);
					}
				}
			}

			return resultArray;
		}
	}
}
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sorting.Helpers;

namespace Sorting.MergeSort2
{
	public class MemoryLoyalMergeSort
	{
		private struct ArrayRef
		{
			private readonly int[] _array;
			public int AbsoluteStartIndex { get; private set; }
			public int Length { get; private set; }
			public int AbsoluteEndIndex { get { return AbsoluteStartIndex + Length; } }
			public int this[int index]
			{
				get { return _array[AbsoluteStartIndex + index]; }
			}


			public ArrayRef(int[] array, int startIndex, int length)
				: this()
			{
				_array = array;
				AbsoluteStartIndex = startIndex;
				Length = length;
			}

			public override string ToString()
			{
				return string.Format("Start: {0}, Length: {1} | {2}",
					AbsoluteStartIndex, Length, String.Join(",",
					_array.Skip(AbsoluteStartIndex).Take(Length).Select(_ => _.ToString())));
			}
		}

		public int[] Sort(int[] array)
		{
			if (array == null || array.Length == 0)
				return new int[] { };

			Sort(array, new ArrayRef(array, 0, array.Length));
			return array;
		}

		private void Sort(int[] array, ArrayRef arrayRef)
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

			Sort(array, left);
			Sort(array, right);

			MergeSorted(array, left, right);
		}

		private void MergeSorted(int[] array, ArrayRef left, ArrayRef right)
		{
			int[] merged = new int[left.Length + right.Length];

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
			for (int i = left.AbsoluteStartIndex; i < left.AbsoluteEndIndex; i++, index++)
			{
				array[i] = merged[index];
			}

			for (int i = right.AbsoluteStartIndex; i < right.AbsoluteEndIndex; i++, index++)
			{
				array[i] = merged[index];
			}
		}
	}
}
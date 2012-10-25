using System;
using System.Linq;

namespace Sorting.DataTypes
{
	public struct ArrayRef
	{
		private readonly int[] _array;
		public readonly int AbsoluteStartIndex;
		public readonly int Length;

		public int AbsoluteEndIndex { get { return AbsoluteStartIndex + Length; } }
		public int this[int index]
		{
			get { return _array[AbsoluteStartIndex + index]; }
			set { _array[AbsoluteStartIndex + index] = value; }
		}

		public ArrayRef(int[] array, int startIndex, int length)
			: this()
		{
			_array = array;
			AbsoluteStartIndex = startIndex;
			Length = length;
		}

		public void FlushTo(int[] array)
		{
			for (int i = Length - 1; i >= 0; i--)
			{
				array[i] = this[i];
			}
		}

		public ArrayRef SubArray(int startIndex, int length)
		{
			return new ArrayRef(_array, AbsoluteStartIndex + startIndex, length);
		}

		public override string ToString()
		{
			string content = string.Join(",", _array.Skip(AbsoluteStartIndex).Take(Length).Select(_ => _.ToString()));
			return String.Format("Start: {0}, Length: {1} | {2}", AbsoluteStartIndex, Length, content);
		}
	}
}
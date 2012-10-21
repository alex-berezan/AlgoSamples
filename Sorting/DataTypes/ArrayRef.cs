using System;
using System.Linq;

namespace Sorting.DataTypes
{
	internal struct ArrayRef
	{
		private readonly int[] _array;
		public int AbsoluteStartIndex { get; private set; }
		public int Length { get; private set; }
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

		public override string ToString()
		{
			return String.Format("Start: {0}, Length: {1} | {2}",
			                     AbsoluteStartIndex, Length, String.Join(",",
			                                                             _array.Skip(AbsoluteStartIndex).Take(Length).Select(_ => _.ToString())));
		}
	}
}
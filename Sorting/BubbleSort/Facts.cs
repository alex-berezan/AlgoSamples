﻿using FluentAssertions;
using Xunit;
using Xunit.Extensions;

namespace Sorting.BubbleSort
{
	public class Facts
	{
		[Theory]
		[InlineData(null)]
		[InlineData(new int[] { })]
		public void Returns_Empty_Array_When_Empty_Or_Null_One_Is_Specified(int[] input)
		{
			var sorter = new BubbleSorter();

			int[] actual = sorter.Sort(input);

			actual.Should().BeEquivalentTo(new int[] { });
		}

		[Fact]
		public void Returns_Equivalent_Array_For_Single_Element_Input()
		{
			var sorter = new BubbleSorter();

			int[] actual = sorter.Sort(new int[] { 42 });

			actual.Should().BeEquivalentTo(new int[] { 42 });
		}

		[Fact]
		public void Returns_Array_Sorted_By_Asc()
		{
			var sorter = new BubbleSorter();

			int[] actual = sorter.Sort(new int[] { 1, 5, 3, 8, 2, 11 });

			actual.Should().BeEquivalentTo(new int[] { 1, 2, 3, 5, 8, 11 });
			actual.Should().BeInAscendingOrder();
		}

		[Fact]
		public void Returns_Array_Sorted_By_Asc_For_Input_With_Duplicates()
		{
			var sorter = new BubbleSorter();

			int[] actual = sorter.Sort(new int[] { 11, 1, 5, 3, 8, 2, 11 });

			actual.Should().BeEquivalentTo(new int[] { 1, 2, 3, 5, 8, 11, 11 });
			actual.Should().BeInAscendingOrder();
		}

		[Fact]
		public void Returns_Copy_Of_Input_Array()
		{
			var sorter = new BubbleSorter();

			var input = new int[] { 1, 5 };
			int[] actual = sorter.Sort(input);

			actual.Should().NotBeNull();
			Assert.NotSame(input, actual);
		}
	}
}
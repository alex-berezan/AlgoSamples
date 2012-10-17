using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;

namespace Sorting.MergeSort2
{
	public class Facts
	{
		[Theory]
		[InlineData(null)]
		[InlineData(new int[] { })]
		public void Returns_Empty_Array_When_Empty_Or_Null_One_Is_Specified(int[] input)
		{
			var sorter = new MemoryLoyalMergeSort();

			int[] actual = sorter.Sort(input);

			actual.Should().BeEquivalentTo(new int[] { });
		}

		[Fact]
		public void Returns_Equivalent_Array_For_Single_Element_Input()
		{
			var sorter = new MemoryLoyalMergeSort();

			int[] actual = sorter.Sort(new int[] { 42 });

			actual.Should().BeEquivalentTo(new int[] { 42 });
		}

		[Fact]
		public void Returns_Array_Sorted_By_Asc()
		{
			var sorter = new MemoryLoyalMergeSort();

			int[] actual = sorter.Sort(new int[] { 1, 5, 3, 8, 2, 11 });

			actual.Should().BeEquivalentTo(new int[] { 1, 2, 3, 5, 8, 11 });
			actual.Should().BeInAscendingOrder();
		}

		[Fact]
		public void Returns_Array_Sorted_By_Asc_For_Array_Where_All_Elements_Are_The_Same()
		{
			var sorter = new MemoryLoyalMergeSort();

			int[] actual = sorter.Sort(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });

			actual.Should().BeEquivalentTo(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
			actual.Should().BeInAscendingOrder();
		}

		[Fact]
		public void Returns_Array_Sorted_By_Asc_For_Input_With_Duplicates()
		{
			var sorter = new MemoryLoyalMergeSort();

			int[] actual = sorter.Sort(new int[] { 11, 1, 5, 8, 8, 8, 8, 8, 3, 8, 2, 8, 8, 11, 8, });

			actual.Should().BeEquivalentTo(new int[] { 1, 2, 3, 5, 8, 8, 8, 8, 8, 8, 8, 8, 8, 11, 11 });
			actual.Should().BeInAscendingOrder();
		}
	}
}
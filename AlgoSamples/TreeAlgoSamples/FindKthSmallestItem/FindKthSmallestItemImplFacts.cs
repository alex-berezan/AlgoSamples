using System;
using FluentAssertions;
using TreeAlgoSamples.ResolveParentsDuplicates;
using Trees;
using Xunit;
using Xunit.Extensions;

namespace TreeAlgoSamples.FindKthSmallestItem
{
	public class FindKthSmallestItemImplFacts
	{
		[Theory]
		[InlineData(1, 1, false)]
		[InlineData(2, 3, false)]
		[InlineData(3, 4, false)]
		[InlineData(4, 5, false)]
		[InlineData(5, 10, false)]
		[InlineData(6, 11, false)]
		[InlineData(7, 0, true)]
		public void Finds_Kth_Smallest_Element_For_Simple_Case(int k, int expected, bool exceptionExpected)
		{
			TreeNode<int> root = new TreeNode<int>
			{
				Data = 10,
				Left = new TreeNode<int>
				{
					Data = 5,
					Left = new TreeNode<int>
					{
						Data = 4,
						Left = new TreeNode<int>
						{
							Data = 3,
							Left = new TreeNode<int> { Data = 1, Left = null, Right = null }
						}
					},
					Right = new TreeNode<int> { Data = 6 }
				},
				Right = new TreeNode<int> { Data = 11 }
			};

			FindKthSmallestItemImpl impl = new FindKthSmallestItemImpl();

			if (exceptionExpected)
			{
				Action a = () => impl.Find(root, k);
				a.ShouldThrow<Exception>();
			}
			else
			{
				var actual = impl.Find(root, k);
				actual.Should().Be(expected);
			}
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TreeAlgoSamples.ResolveParentsDuplicates;
using Trees;
using Xunit;

namespace TreeAlgoSamples.ResolveParentsDuplicates
{
	public class TreeNodeDuplicatedParentResolverFacts
	{
		[Fact]
		public void Resolves_Duplicated_Parents()
		{
			TreeNode<string> child1 = new TreeNode<string> { Data = "child1" };
			TreeNode<string> commonChild = new TreeNode<string> { Data = "commonChild" };
			TreeNode<string> child2 = new TreeNode<string> { Data = "child2" };

			TreeNode<string> parent1 = new TreeNode<string> { Data = "parent1", Left = child1, Right = commonChild };
			TreeNode<string> parent2 = new TreeNode<string> { Data = "parent2", Left = commonChild, Right = child2 };

			TreeNode<string> root = new TreeNode<string> { Data = "root", Left = parent1, Right = parent2 };

			TreeNodeDuplicatedParentResolver resolver = new TreeNodeDuplicatedParentResolver();

			// Act
			TreeNode<string> resolvedRoot = resolver.ResolveDuplicateParents(root);

			// Assert
			var childs = new List<TreeNode<string>> { parent1.Left, parent1.Right, parent2.Left, parent2.Right };
			childs.Distinct().Count().Should().Be(4);
			childs.Select(child => child.Data).Distinct().Should().BeEquivalentTo(new[] { "child1", "commonChild", "child2" });
		}
	}
}
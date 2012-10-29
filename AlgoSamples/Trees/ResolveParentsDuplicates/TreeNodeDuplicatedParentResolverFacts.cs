using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Trees.ResolveParentsDuplicates
{
	public class TreeNodeDuplicatedParentResolverFacts
	{
		[Fact]
		public void Resolves_Duplicated_Parents()
		{
			TreeNode child1 = new TreeNode { Data = "child1" };
			TreeNode commonChild = new TreeNode { Data = "commonChild" };
			TreeNode child2 = new TreeNode { Data = "child2" };

			TreeNode parent1 = new TreeNode { Data = "parent1", Left = child1, Right = commonChild };
			TreeNode parent2 = new TreeNode { Data = "parent2", Left = commonChild, Right = child2 };

			TreeNode root = new TreeNode { Data = "root", Left = parent1, Right = parent2 };

			TreeNodeDuplicatedParentResolver resolver = new TreeNodeDuplicatedParentResolver();

			// Act
			TreeNode resolvedRoot = resolver.ResolveDuplicateParents(root);

			// Assert
			var childs = new List<TreeNode> { parent1.Left, parent1.Right, parent2.Left, parent2.Right };
			childs.Distinct().Count().Should().Be(4);
			childs.Select(child => child.Data).Distinct().Should().BeEquivalentTo(new[] { "child1", "commonChild", "child2" });
		}
	}
}
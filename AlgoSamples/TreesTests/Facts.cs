using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Trees;
using Xunit;

namespace TreesTests
{
	public class Facts
	{
		[Fact]
		public void Throws_exception_for_an_empty_string()
		{
			Action a = () => Tree.WithStrings("   	");
			a.ShouldThrow<ArgumentException>();
		}

		[Fact]
		public void Returns_tree_with_one_not_null_childless_node_for_one_element_string()
		{
			var root = Tree.WithStrings("hello");

			// assert
			root.Should().NotBeNull();
			root.Data.Should().Be("hello");
			root.Children.Should().BeEmpty();
		}

		[Fact]
		public void Separates_children_by_tabs_identations()
		{
			string treeString =
@"root
	child1
		subChild
	child2";

			TreeNodeBase<string> root = Tree.WithStrings(treeString);

			// assert
			root.Data.Should().Be("root");
			root.Children.Count.Should().Be(2);
			root.Children[0].Data.Should().Be("child1");
			root.Children[1].Data.Should().Be("child2");
			root.Children[0].Children.Count.Should().Be(1);
			root.Children[0].Children[0].Data.Should().Be("subChild");
		}

		[Fact]
		public void Separates_neighbors_bynew_line_breaks()
		{
			string treeString =
@"root
	child1
	child2";

			TreeNodeBase<string> root = Tree.WithStrings(treeString);

			// assert
			root.Children.Count.Should().Be(2);
			root.Children.Select(node => node.Data).Should().BeEquivalentTo(new[] { "child1", "child2" });
		}

		[Fact]
		public void Throws_exception_for_ambiguous_root()
		{
			string treeString = @"root1
root2";
			Action a = () => Tree.WithStrings(treeString);
			a.ShouldThrow<InvalidOperationException>();
		}
	}
}

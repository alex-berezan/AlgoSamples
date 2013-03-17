using System.Collections.Generic;
using System.Linq;
using Trees;

namespace TreeAlgoSamples.ResolveParentsDuplicates
{
	public class TreeNodeDuplicatedParentResolver
	{
		#region Nested Types

		internal sealed class TreeNodeFamily
		{
			public TreeNode<string> Child;
			public Dictionary<TreeNode<string>, bool> Parents;
		}

		#endregion

		public TreeNode<string> ResolveDuplicateParents(TreeNode<string> root)
		{
			IEnumerable<TreeNodeFamily> treeNodeFamilies = GetMultiParentedNodes(root);
			foreach (TreeNodeFamily treeNodeFamily in treeNodeFamilies)
			{
				foreach (KeyValuePair<TreeNode<string>, bool> parentLink in treeNodeFamily.Parents.Skip(1))
				{
					bool isLeft = parentLink.Value;
					TreeNode<string> parent = parentLink.Key;

					if (isLeft) parent.Left = CloneTree(parent.Left);
					else parent.Right = CloneTree(parent.Left);
				}
			}

			return root;
		}

		private static TreeNode<string> CloneTree(TreeNode<string> root)
		{
			if (root == null)
				return null;
			return new TreeNode<string>
			{
				Data = root.Data,
				Left = CloneTree(root.Left),
				Right = CloneTree(root.Right)
			};
		}

		private static IEnumerable<TreeNodeFamily> GetMultiParentedNodes(TreeNode<string> root)
		{
			var linksDictionary = new Dictionary<TreeNode<string>, TreeNodeFamily>();
			FillLinks(root, linksDictionary);

			return linksDictionary.Values
				.Where(link => link.Parents.Count() > 1)
				.ToList();
		}

		private static void FillLinks(TreeNode<string> root, Dictionary<TreeNode<string>, TreeNodeFamily> linksDictionary)
		{
			if (root.Left != null)
			{
				if (!linksDictionary.ContainsKey(root.Left))
				{
					linksDictionary.Add(root.Left, new TreeNodeFamily { Child = root.Left, Parents = new Dictionary<TreeNode<string>, bool>() });
				}
				linksDictionary[root.Left].Parents.Add(root, true);
				FillLinks(root.Left, linksDictionary);
			}

			if (root.Right != null)
			{
				if (!linksDictionary.ContainsKey(root.Right))
				{
					linksDictionary.Add(root.Right, new TreeNodeFamily { Child = root.Right, Parents = new Dictionary<TreeNode<string>, bool>() });
				}
				linksDictionary[root.Right].Parents.Add(root, false);
				FillLinks(root.Right, linksDictionary);
			}
		}
	}
}
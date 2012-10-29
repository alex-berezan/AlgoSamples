using System.Collections.Generic;
using System.Linq;

namespace Trees.ResolveParentsDuplicates
{
	public class TreeNodeDuplicatedParentResolver
	{
		#region Nested Types

		internal sealed class TreeNodeFamily
		{
			public TreeNode Child;
			public Dictionary<TreeNode, bool> Parents;
		}

		#endregion

		public TreeNode ResolveDuplicateParents(TreeNode root)
		{
			IEnumerable<TreeNodeFamily> treeNodeFamilies = GetMultiParentedNodes(root);
			foreach (TreeNodeFamily treeNodeFamily in treeNodeFamilies)
			{
				foreach (KeyValuePair<TreeNode, bool> parentLink in treeNodeFamily.Parents.Skip(1))
				{
					bool isLeft = parentLink.Value;
					TreeNode parent = parentLink.Key;

					if (isLeft) parent.Left = CloneTree(parent.Left);
					else parent.Right = CloneTree(parent.Left);
				}
			}

			return root;
		}

		private static TreeNode CloneTree(TreeNode root)
		{
			if (root == null)
				return null;
			return new TreeNode
			{
				Data = root.Data,
				Left = CloneTree(root.Left),
				Right = CloneTree(root.Right)
			};
		}

		private static IEnumerable<TreeNodeFamily> GetMultiParentedNodes(TreeNode root)
		{
			var linksDictionary = new Dictionary<TreeNode, TreeNodeFamily>();
			FillLinks(root, linksDictionary);

			return linksDictionary.Values
				.Where(link => link.Parents.Count() > 1)
				.ToList();
		}

		private static void FillLinks(TreeNode root, Dictionary<TreeNode, TreeNodeFamily> linksDictionary)
		{
			if (root.Left != null)
			{
				if (!linksDictionary.ContainsKey(root.Left))
				{
					linksDictionary.Add(root.Left, new TreeNodeFamily { Child = root.Left, Parents = new Dictionary<TreeNode, bool>() });
				}
				linksDictionary[root.Left].Parents.Add(root, true);
				FillLinks(root.Left, linksDictionary);
			}

			if (root.Right != null)
			{
				if (!linksDictionary.ContainsKey(root.Right))
				{
					linksDictionary.Add(root.Right, new TreeNodeFamily { Child = root.Right, Parents = new Dictionary<TreeNode, bool>() });
				}
				linksDictionary[root.Right].Parents.Add(root, false);
				FillLinks(root.Right, linksDictionary);
			}
		}
	}
}
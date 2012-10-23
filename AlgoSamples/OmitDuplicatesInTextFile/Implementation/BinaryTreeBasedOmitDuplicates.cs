using System;
using System.Collections.Generic;

namespace OmitDuplicatesInTextFile.Implementation
{
	internal class BinaryTreeBasedOmitDuplicates : IOmitDuplicates
	{
		#region Nested Types

		private sealed class TreeNode
		{
			public string data;
			public TreeNode left;
			public TreeNode right;
		}

		#endregion

		public string[] Omit(string[] lines)
		{
			if (lines.Length == 0)
			{
				return new string[] { };
			}

			List<string> filteredLines = new List<string>(lines.Length) { lines[0] };

			TreeNode root = new TreeNode { data = lines[0] };
			for (int i = lines.Length - 1; i >= 1; i--)
			{
				string line = lines[i];
				if (AddDataTo(root, line))
				{
					filteredLines.Add(line);
				}
			}

			return filteredLines.ToArray();
		}

		private static bool AddDataTo(TreeNode root, string data)
		{
			int dif = Compare(root.data, data);
			if (dif == 0)
			{
				return false;
			}

			if (dif < 0)
			{
				if (root.left == null)
				{
					root.left = new TreeNode { data = data };
					return true;
				}
				return AddDataTo(root.left, data);
			}

			if (root.right == null)
			{
				root.right = new TreeNode { data = data };
				return true;
			}
			return AddDataTo(root.right, data);
		}

		private static int Compare(string a, string b)
		{
			if (a.Equals(b))
				return 0;

			int minLen = Math.Min(a.Length, b.Length);
			for (int i = minLen - 1; i >= 0; i--)
			{
				if (a[i] != b[i])
				{
					return a[i] - b[i];
				}
			}

			return a.Length - b.Length;
		}
	}
}

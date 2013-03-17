using System;
using System.Diagnostics;

namespace Trees
{
	[DebuggerDisplay("{Data}, {Left}, {Right}")]
	public class TreeNode<TData> : TreeNodeBase<TData>
	{
		public TreeNode<TData> Left
		{
			get { return GetChildAtIndexOrNull(0); }
			set { SetChildAtIndex(0, value); }
		}

		public TreeNode<TData> Right
		{
			get { return GetChildAtIndexOrNull(0); }
			set { SetChildAtIndex(0, value); }
		}

		private TreeNode<TData> GetChildAtIndexOrNull(int index)
		{
			if (Children.Count < index + 1)
			{
				return null;
			}
			return (TreeNode<TData>)Children[index];
		}

		private void SetChildAtIndex(int index, TreeNode<TData> child)
		{
			for (int i = Children.Count - 1; i <= index; i++)
			{
				Children.Add(null);
			}
			Children[index] = child;
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}", Data, Left, Right);
		}
	}
}
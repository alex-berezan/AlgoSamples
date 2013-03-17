using System.Diagnostics;

namespace Trees
{
	[DebuggerDisplay("{Data}, {Left}, {Right}")]
	public class TreeNode<TData>
	{
		public TData Data { get; set; }
		public TreeNode<TData> Left { get; set; }
		public TreeNode<TData> Right { get; set; }

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}", Data, Left, Right);
		}
	}
}
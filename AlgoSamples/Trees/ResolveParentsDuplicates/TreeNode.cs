namespace Trees.ResolveParentsDuplicates
{
	public class TreeNode<TData>
	{
		public TData Data { get; set; }
		public TreeNode<TData> Left { get; set; }
		public TreeNode<TData> Right { get; set; }
	}
}
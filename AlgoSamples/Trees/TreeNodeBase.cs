using System.Collections.Generic;

namespace Trees
{
	public class TreeNodeBase<TData>
	{
		public TData Data { get; set; }
		public IList<TreeNodeBase<TData>> Children { get; private set; }

		public TreeNodeBase()
		{
			Children = new List<TreeNodeBase<TData>>();
		}
	}
}
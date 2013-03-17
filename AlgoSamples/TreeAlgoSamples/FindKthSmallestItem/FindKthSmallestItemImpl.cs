using System;
using System.Diagnostics;
using TreeAlgoSamples.ResolveParentsDuplicates;
using Trees;

namespace TreeAlgoSamples.FindKthSmallestItem
{
	public class FindKthSmallestItemImpl
	{
		[DebuggerDisplay("{Result}, {Max}, {Count}")]
		private struct SearchResult
		{
			public readonly int? Result;
			public readonly int? Max;
			public readonly int Count;

			[DebuggerStepThrough]
			public SearchResult(int? result, int? max, int count)
				: this()
			{
				Result = result;
				Max = max;
				Count = count;
			}
			public SearchResult Union(SearchResult other)
			{
				return new SearchResult(null, GetMax(Max, other.Max), Count + other.Count);
			}

			private static int? GetMax(int? a, int? b)
			{
				if (!a.HasValue && !b.HasValue)
					return null;
				if (a.HasValue && b.HasValue)
					return Math.Max(a.Value, b.Value);
				return a.HasValue ? a.Value : b.Value;
			}
		}
		public int Find(TreeNode<int> root, int k)
		{
			SearchResult searchResult = Search(root, new SearchResult(null, null, 0), k);
			if (searchResult.Result.HasValue)
				return searchResult.Result.Value;

			throw new Exception(string.Format("{0}-th smallest item was not found", k));
		}

		private SearchResult Search(TreeNode<int> root, SearchResult acc, int k)
		{
			if (root == null)
			{
				return new SearchResult(null, 0, 0);
			}
			SearchResult fromLeft = Search(root.Left, new SearchResult(null, null, 0), k);
			if (fromLeft.Result.HasValue)
				return fromLeft;
			if (fromLeft.Count == k - 1)
				return new SearchResult(root.Data, 0, 0);

			var rootNodeSearchResult = new SearchResult(null, root.Data, 1);
			return Search(root.Right, acc.Union(fromLeft).Union(rootNodeSearchResult), k);
		}
	}
}
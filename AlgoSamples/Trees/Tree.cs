using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees
{
	public static class Tree
	{
		public static TreeNodeBase<string> WithStrings(string treeString)
		{
			return ParseFromString(treeString, token => token);
		}

		public static TreeNodeBase<int> WithIntegers(string treeString)
		{
			return ParseFromString(treeString, Int32.Parse);
		}

		private static TreeNodeBase<TData> ParseFromString<TData>(string treeString, Func<string, TData> convertValue)
		{
			if (string.IsNullOrWhiteSpace(treeString))
			{
				throw new ArgumentException("treeString can not be null or empty", "treeString");
			}

			List<string> lines = treeString.Split(Environment.NewLine.ToCharArray()
								, StringSplitOptions.RemoveEmptyEntries).ToList();

			var root = new TreeNodeBase<TData> { Data = convertValue(lines.Take(1).First()) };
			var roots = new Dictionary<int, TreeNodeBase<TData>>(lines.Count) { { 0, root } };
			foreach (string line in lines.Skip(1))
			{
				int identation = GetIdentation(line);
				if (identation == 0)
				{
					throw new InvalidOperationException("Ambigous root was detected");
				}
				var currentRoot = roots[identation - 1];

				var node = new TreeNodeBase<TData> { Data = convertValue(line.Trim()) };
				currentRoot.Children.Add(node);
				roots[identation] = node;
			}

			return root;
		}

		private static int GetIdentation(string line)
		{
			int i = 0;
			while (line[i] == '\t') i++;
			return i;
		}
	}
}
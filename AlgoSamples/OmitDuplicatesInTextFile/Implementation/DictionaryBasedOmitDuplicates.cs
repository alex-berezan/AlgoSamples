using System.Collections.Generic;
using System.Linq;

namespace OmitDuplicatesInTextFile.Implementation
{
	internal class DictionaryBasedOmitDuplicates : IOmitDuplicates
	{
		public string[] Omit(string[] lines)
		{
			Dictionary<string, int> d = new Dictionary<string, int>();

			foreach (string line in lines)
			{
				if (!d.ContainsKey(line))
				{
					d.Add(line, 0);
				}
			}

			return d.Keys.ToArray();

		}
	}
}

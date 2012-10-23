using System;
using System.Diagnostics;
using System.IO;
using OmitDuplicatesInTextFile.Implementation;

namespace OmitDuplicatesInTextFile
{
	public static class Program
	{
		private static readonly string FILE_NAME = "Contains_Duplicates.txt";
		private static readonly int ITERATIONS = 50000;

		public static void Main(string[] args)
		{
			DoBench(new DictionaryBasedOmitDuplicates());
			DoBench(new BinaryTreeBasedOmitDuplicates());

			Console.WriteLine("Done. Hit any key ...");
			Console.ReadKey(true);
		}

		private static void DoBench(IOmitDuplicates impl)
		{
			Stopwatch sw = new Stopwatch();

			string[] lines = File.ReadAllLines(FILE_NAME);

			sw.Start();
			for (int i = 0; i < ITERATIONS; i++)
			{
				impl.Omit(lines);
			}
			sw.Stop();
			Console.WriteLine("Elapsed time for {0}: {1}", impl.GetType().Name, sw.Elapsed);
		}
	}
}

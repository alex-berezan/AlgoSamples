using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sorting.MergeSort;

namespace Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchPerformance();
			// BenchCorrectness();

			Console.WriteLine("Hit any key");
			Console.ReadKey(intercept: true);
		}

		private static void BenchCorrectness()
		{
			int iterationsCount = 20;
			int arraySize = 20000;

			var mergeSorter = new MergeSorter();
			var elapsed1 = DoTest(iterationsCount, () =>
			{
				var array = GenerateTestArray(arraySize);
				array = mergeSorter.Sort(array);
				array.Should().BeInAscendingOrder();

			});
			Console.WriteLine("Elapsed1: {0}", elapsed1);

			var mergeSorter2 = new Sorting.MergeSort2.MemoryLoyalMergeSort();
			var elapsed2 = DoTest(iterationsCount, () =>
			{
				var array = GenerateTestArray(arraySize);
				mergeSorter2.Sort(array);
				array.Should().BeInAscendingOrder();
			});
			Console.WriteLine("Elapsed2: {0}", elapsed2);
		}

		private static void BenchPerformance()
		{
			// last result: 00m 38s for 40000 itearations with 25000 array
			// for approach with paralleling sorting for arrays longer than 2048
			int iterationsCount = 40000;
			int arraySize = 25000;

			var array = GenerateTestArray(arraySize);

			//var mergeSorter = new MergeSorter();
			//var elapsed1 = DoTest(iterationsCount, () => mergeSorter.Sort(array));
			//Console.WriteLine("Elapsed1: {0}", elapsed1);

			var mergeSorter2 = new Sorting.MergeSort2.MemoryLoyalMergeSort();
			var elapsed2 = DoTest(iterationsCount, () => mergeSorter2.Sort(array));
			Console.WriteLine("Elapsed2: {0}", elapsed2);
		}

		private static int[] GenerateTestArray(int arraySize)
		{
			Random r = new Random(42);
			List<int> input = new List<int>();
			for (int i = 0; i < arraySize; i++)
			{
				input.Add(i * r.Next(0, 42));
			}

			int[] array = input.ToArray();
			return array;
		}

		private static TimeSpan DoTest(int iterationsCount, Action iteration)
		{
			var sw = new Stopwatch();
			sw.Start();
			for (int i = 0; i < iterationsCount; i++)
			{
				iteration();
			}
			sw.Stop();
			return sw.Elapsed;
		}
	}
}

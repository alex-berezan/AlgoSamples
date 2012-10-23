using OmitDuplicatesInTextFile.Implementation;
using Xunit;

namespace OmitDuplicatesInTextFile.Facts
{ 	 
	public class BinaryTreeBasedOmitDuplicatesFacts
	{
		[Fact]
		public void Omits_Duplicates()
		{
			BinaryTreeBasedOmitDuplicates d = new BinaryTreeBasedOmitDuplicates();

			string[] lines = new[] { "a", "b", "c", "a", "a", "b", };

			string[] actual = d.Omit(lines);

			string[] expected = new[] { "a", "b", "c" };

			Assert.Equal(expected.Length, actual.Length);
			for (int i = 0; i < actual.Length; i++)
				Assert.Equal(expected[i], actual[i]);

		}

		[Fact]
		public void Return_No_Items_When_No_Items_Are_Given_As_Input()
		{
			BinaryTreeBasedOmitDuplicates d = new BinaryTreeBasedOmitDuplicates();

			string[] lines = new string[] { };

			string[] actual = d.Omit(lines);

			string[] expected = new string[] { };

			Assert.Equal(expected.Length, actual.Length);
			for (int i = 0; i < actual.Length; i++)
				Assert.Equal(expected[i], actual[i]);

		}

		[Fact]
		public void Return_Single_Item_When_Duplicating_Single_Item_Is_Given_As_Input()
		{
			BinaryTreeBasedOmitDuplicates d = new BinaryTreeBasedOmitDuplicates();

			string[] lines = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", };

			string[] actual = d.Omit(lines);

			string[] expected = new string[] { "a", };

			Assert.Equal(expected.Length, actual.Length);
			for (int i = 0; i < actual.Length; i++)
				Assert.Equal(expected[i], actual[i]);

		}
	}
}

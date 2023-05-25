namespace FluentComparer.Tests
{
	using Xunit;

	public class FluentComparer_DeepComparing
	{
		[Fact]
		public void FluentComparer_Comparing_ResultGreaterThanZero()
		{
			var firstComparer = FluentComparer<TestClass>
				.For(tc => tc.First)
				.For(tc => tc.Second);

			var test1 = new TestClass(2, 3);
			var test2 = new TestClass(2, 2);

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result > 0);
		}

		[Fact]
		public void FluentComparer_Comparing_ResultEqualsZero()
		{
			var firstComparer = FluentComparer<TestClass>
				.For(tc => tc.First)
				.For(tc => tc.Second);

			var test1 = new TestClass(2, 3);
			var test2 = new TestClass(2, 3);

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result == 0);
		}

		[Fact]
		public void FluentComparer_Comparing_ResultSmallerThanZero()
		{
			var firstComparer = FluentComparer<TestClass>
				.For(tc => tc.First)
				.For(tc => tc.Second);

			var test1 = new TestClass(2, 3);
			var test2 = new TestClass(2, 4);

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result < 0);
		}

		[Fact]
		public void FluentComparer_Comparing_ResultSmallerThanZeroOnFirstLevel()
		{
			var firstComparer = FluentComparer<TestClass>
				.For(tc => tc.First)
				.For(tc => tc.Second);

			var test1 = new TestClass(2, 3);
			var test2 = new TestClass(3, 4);

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result < 0);
		}
	}
}

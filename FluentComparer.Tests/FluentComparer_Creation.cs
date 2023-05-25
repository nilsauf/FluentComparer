namespace FluentComparer.Tests
{
	using System;
	using Xunit;

	public class FluentComparer_Creation
	{
		[Fact]
		public void FluentComparer_Creation_OK()
		{
			var firstComparer = FluentComparer<TestClass>.For(tc => tc.First);

			Assert.NotNull(firstComparer);
		}

		[Fact]
		public void FluentComparer_Creation_Null()
		{
			Func<TestClass, ComparableClass> getProperty = null;
			Assert.Throws<ArgumentNullException>(() => FluentComparer<TestClass>.For(getProperty));
		}

		[Fact]
		public void FluentComparer_Creation_NullOnDeeperLevel()
		{
			Func<TestClass, ComparableClass> getProperty = null;
			Assert.Throws<ArgumentNullException>(
				() => FluentComparer<TestClass>
					.For(tc => tc.First)
					.For(getProperty));

			Assert.Throws<ArgumentNullException>(
				() => FluentComparer<TestClass>
					.For(tc => tc.First)
					.For(tc => tc.Second)
					.For(getProperty));
		}
	}
}
namespace FluentComparer.Tests
{
	using Xunit;

	public class FluentComparer_ComparingToNull
	{
		[Fact]
		public void FluentComparer_ComparingToNull_FirstTestClassNull()
		{
			var firstComparer = FluentComparer<TestClass>.For(tc => tc.First);

			TestClass test1 = null;
			var test2 = new TestClass(1, 2);

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result < 0);
		}

		[Fact]
		public void FluentComparer_ComparingToNull_SecondTestClassNull()
		{
			var firstComparer = FluentComparer<TestClass>.For(tc => tc.First);

			var test1 = new TestClass(1, 2);
			TestClass test2 = null;

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result > 0);
		}

		[Fact]
		public void FluentComparer_ComparingToNull_BothTestClassesNull()
		{
			var firstComparer = FluentComparer<TestClass>.For(tc => tc.First);

			TestClass test1 = null;
			TestClass test2 = null;

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result == 0);
		}

		[Fact]
		public void FluentComparer_ComparingToNull_FirstPropertyNull()
		{
			var firstComparer = FluentComparer<TestClass>.For(tc => tc.First);

			var test1 = new TestClass(propToCompare2: 2)
			{
				First = null
			};
			var test2 = new TestClass(1, 2);

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result < 0);
		}

		[Fact]
		public void FluentComparer_ComparingToNull_SecondPropertyNull()
		{
			var firstComparer = FluentComparer<TestClass>.For(tc => tc.First);

			var test1 = new TestClass(1, 2);
			var test2 = new TestClass(propToCompare2: 2)
			{
				First = null
			};

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result > 0);
		}

		[Fact]
		public void FluentComparer_ComparingToNull_BothPropertiesNull()
		{
			var firstComparer = FluentComparer<TestClass>.For(tc => tc.First);

			var test1 = new TestClass(propToCompare2: 2)
			{
				First = null
			};
			var test2 = new TestClass(propToCompare2: 3)
			{
				First = null
			};

			var result = firstComparer.Compare(test1, test2);

			Assert.True(result == 0);
		}
	}
}

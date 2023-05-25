namespace FluentComparer.Tests
{
	using System;

	internal class TestClass
	{
		public ComparableClass First { get; set; }
		public ComparableClass Second { get; set; }

		public TestClass(int propToCompare1 = 0, int propToCompare2 = 0)
		{
			this.First = new ComparableClass(propToCompare1);
			this.Second = new ComparableClass(propToCompare2);
		}
	}

	internal class ComparableClass : IComparable<ComparableClass>
	{
		public int PropToCompare { get; set; }

		public ComparableClass(int propToCompare = 0)
		{
			this.PropToCompare = propToCompare;
		}

		public int CompareTo(ComparableClass other)
			=> this.PropToCompare.CompareTo(other.PropToCompare);
	}
}

namespace FluentComparer.Tests;

using System;

internal class TestClass(int propToCompare1 = 0, int propToCompare2 = 0)
{
    public ComparableClass First { get; set; } = new(propToCompare1);
    public ComparableClass Second { get; set; } = new(propToCompare2);
}

internal class ComparableClass(int propToCompare = 0) : IComparable<ComparableClass>
{
    public int PropToCompare { get; set; } = propToCompare;

    public int CompareTo(ComparableClass other)
        => this.PropToCompare.CompareTo(other.PropToCompare);
}

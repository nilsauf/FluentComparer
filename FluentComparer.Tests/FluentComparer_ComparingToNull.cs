namespace FluentComparer.Tests;

using System.Collections.Generic;
using Xunit;

public class FluentComparer_ComparingToNull()
{
    [Fact]
    public void FluentComparer_ComparingToNull_WhenFirstObjectIsNull_ReturnsNegativeOne()
    {
        var comparer = CreateComparer();
        TestClass left = null;
        var right = new TestClass(1, 2);

        var result = comparer.Compare(left, right);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void FluentComparer_ComparingToNull_WhenSecondObjectIsNull_ReturnsOne()
    {
        var comparer = CreateComparer();
        var left = new TestClass(1, 2);
        TestClass right = null;

        var result = comparer.Compare(left, right);

        Assert.Equal(1, result);
    }

    [Fact]
    public void FluentComparer_ComparingToNull_WhenBothObjectsAreNull_ReturnsZero()
    {
        var comparer = CreateComparer();
        TestClass left = null;
        TestClass right = null;

        var result = comparer.Compare(left, right);

        Assert.Equal(0, result);
    }

    [Fact]
    public void FluentComparer_ComparingToNull_WhenFirstPropertyIsNull_ReturnsNegativeOne()
    {
        var comparer = CreateComparer();
        var left = CreateTestClassWithNullFirst(propToCompare2: 2);
        var right = new TestClass(1, 2);

        var result = comparer.Compare(left, right);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void FluentComparer_ComparingToNull_WhenSecondPropertyIsNull_ReturnsOne()
    {
        var comparer = CreateComparer();
        var left = new TestClass(1, 2);
        var right = CreateTestClassWithNullFirst(propToCompare2: 2);

        var result = comparer.Compare(left, right);

        Assert.Equal(1, result);
    }

    [Fact]
    public void FluentComparer_ComparingToNull_WhenBothPropertiesAreNull_ReturnsZero()
    {
        var comparer = CreateComparer();
        var left = CreateTestClassWithNullFirst(propToCompare2: 2);
        var right = CreateTestClassWithNullFirst(propToCompare2: 3);

        var result = comparer.Compare(left, right);

        Assert.Equal(0, result);
    }

    private static IComparer<TestClass> CreateComparer()
        => FluentComparer<TestClass>.For(testClass => testClass.First);

    private static TestClass CreateTestClassWithNullFirst(int propToCompare2)
        => new(propToCompare2: propToCompare2)
        {
            First = null
        };
}

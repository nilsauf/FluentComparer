namespace FluentComparer.Tests;

using System;
using Xunit;

public class FluentComparerTests
{
    [Fact]
    public void For_WithValidPropertySelector_ReturnsComparer()
    {
        var comparer = FluentComparer<TestObject>.For(testObject => testObject.IntProperty);

        Assert.NotNull(comparer);
    }

    [Fact]
    public void For_WithNullPropertySelector_ThrowsArgumentNullException()
    {
        Func<TestObject, int> getProperty = null;

        Assert.Throws<ArgumentNullException>(() => FluentComparer<TestObject>.For(getProperty));
    }

    [Fact]
    public void For_WithValidPropertySelector_ReturnsWorkingComparer()
    {
        var left = new TestObject { IntProperty = 1 };
        var right = new TestObject { IntProperty = 2 };
        var comparer = FluentComparer<TestObject>.For(testObject => testObject.IntProperty);

        var result = comparer.Compare(left, right);

        Assert.True(result < 0);
    }

    [Fact]
    public void For_WithStringProperty_ReturnsComparer()
    {
        var comparer = FluentComparer<TestObject>.For(testObject => testObject.StringProperty);

        Assert.NotNull(comparer);
    }

    [Fact]
    public void For_WithDoubleProperty_ReturnsComparer()
    {
        var comparer = FluentComparer<TestObject>.For(testObject => testObject.DoubleProperty);

        Assert.NotNull(comparer);
    }

    private sealed class TestObject
    {
        public int IntProperty { get; set; }

        public string StringProperty { get; set; } = string.Empty;

        public double DoubleProperty { get; set; }
    }
}

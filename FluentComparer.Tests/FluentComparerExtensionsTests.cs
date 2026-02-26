namespace FluentComparer.Tests;

using System;
using System.Collections.Generic;
using Xunit;

public class FluentComparerExtensionsTests
{
    [Fact]
    public void For_WithNullGetProperty_ThrowsArgumentNullException()
    {
        var comparer = Comparer<int>.Default;
        Func<int, int> getProperty = null;

        Assert.Throws<ArgumentNullException>(() => comparer.For(getProperty));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(-100)]
    [InlineData(100)]
    public void For_WhenPreviousComparerReturnsNonZero_UsesPreviousResult(int previousResult)
    {
        var left = new TestObject { Value = 5 };
        var right = new TestObject { Value = 10 };
        var previousComparer = CreateComparerReturning(previousResult);

        var resultComparer = previousComparer.For(testObject => testObject.Value);
        var comparisonResult = resultComparer.Compare(left, right);

        Assert.Equal(previousResult, comparisonResult);
    }

    [Theory]
    [InlineData(5, 10, -1)]
    [InlineData(10, 5, 1)]
    [InlineData(7, 7, 0)]
    public void For_WhenPreviousComparerReturnsZero_UsesNewPropertyComparison(int value1, int value2, int expectedResult)
    {
        var left = new TestObject { Value = value1 };
        var right = new TestObject { Value = value2 };
        var previousComparer = CreateComparerReturning(0);

        var resultComparer = previousComparer.For(testObject => testObject.Value);
        var comparisonResult = resultComparer.Compare(left, right);

        Assert.Equal(expectedResult, comparisonResult);
    }

    [Theory]
    [InlineData(5, 10, -1)]
    [InlineData(10, 5, 1)]
    [InlineData(7, 7, 0)]
    public void For_WithNullPreviousComparer_UsesNewPropertyComparison(int value1, int value2, int expectedResult)
    {
        var left = new TestObject { Value = value1 };
        var right = new TestObject { Value = value2 };
        IComparer<TestObject> previousComparer = null;

        var resultComparer = previousComparer.For(testObject => testObject.Value);
        var comparisonResult = resultComparer.Compare(left, right);

        Assert.Equal(expectedResult, comparisonResult);
    }

    [Theory]
    [InlineData(int.MinValue, int.MaxValue, -1)]
    [InlineData(int.MaxValue, int.MinValue, 1)]
    [InlineData(int.MinValue, int.MinValue, 0)]
    [InlineData(int.MaxValue, int.MaxValue, 0)]
    [InlineData(0, int.MaxValue, -1)]
    [InlineData(int.MinValue, 0, -1)]
    public void For_WithExtremeIntegerValues_ReturnsCorrectComparison(int value1, int value2, int expectedResult)
    {
        var left = new TestObject { Value = value1 };
        var right = new TestObject { Value = value2 };
        IComparer<TestObject> previousComparer = null;

        var resultComparer = previousComparer.For(testObject => testObject.Value);
        var comparisonResult = resultComparer.Compare(left, right);

        Assert.Equal(expectedResult, comparisonResult);
    }

    [Theory]
    [InlineData("apple", "banana", -1)]
    [InlineData("banana", "apple", 1)]
    [InlineData("test", "test", 0)]
    [InlineData("", "non-empty", -1)]
    [InlineData("non-empty", "", 1)]
    public void For_WithStringProperty_ReturnsCorrectComparison(string value1, string value2, int expectedResult)
    {
        var left = new TestObjectWithString { Name = value1 };
        var right = new TestObjectWithString { Name = value2 };
        IComparer<TestObjectWithString> previousComparer = null;

        var resultComparer = previousComparer.For(testObject => testObject.Name);
        var comparisonResult = resultComparer.Compare(left, right);

        Assert.Equal(expectedResult, comparisonResult);
    }

    private static IComparer<TestObject> CreateComparerReturning(int result)
        => Comparer<TestObject>.Create((_, _) => result);

    public sealed class TestObject
    {
        public int Value { get; set; }
    }

    public sealed class TestObjectWithString
    {
        public string Name { get; set; } = string.Empty;
    }
}
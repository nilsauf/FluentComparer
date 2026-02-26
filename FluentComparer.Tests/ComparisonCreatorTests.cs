namespace FluentComparer.Tests;

using System;
using Xunit;

public class ComparisonCreatorTests
{
    [Fact]
    public void GetComparison_WhenBothPropertiesAreNull_ReturnsZero()
    {
        var comparison = CreateStringPropertyComparison();

        var result = comparison(CreateTestObject(null), CreateTestObject(null));

        Assert.Equal(0, result);
    }

    [Fact]
    public void GetComparison_WhenFirstPropertyIsNull_ReturnsNegativeOne()
    {
        var comparison = CreateStringPropertyComparison();

        var result = comparison(CreateTestObject(null), CreateTestObject("value"));

        Assert.Equal(-1, result);
    }

    [Fact]
    public void GetComparison_WhenSecondPropertyIsNull_ReturnsOne()
    {
        var comparison = CreateStringPropertyComparison();

        var result = comparison(CreateTestObject("value"), CreateTestObject(null));

        Assert.Equal(1, result);
    }

    [Theory]
    [InlineData("a", "b", -1)]
    [InlineData("b", "a", 1)]
    [InlineData("test", "test", 0)]
    [InlineData("", "a", -1)]
    [InlineData("z", "", 1)]
    public void GetComparison_WithStringProperties_ReturnsCorrectSign(string firstValue, string secondValue, int expectedSign)
    {
        var comparison = CreateStringPropertyComparison();

        var result = comparison(CreateTestObject(firstValue), CreateTestObject(secondValue));

        Assert.Equal(expectedSign, Math.Sign(result));
    }

    [Theory]
    [InlineData(null, null, true, 0)]
    [InlineData(null, "test", true, -1)]
    [InlineData("test", null, true, 1)]
    [InlineData("first", "second", false, 0)]
    [InlineData("same", "same", false, 0)]
    [InlineData("", "", false, 0)]
    public void CompareForNull_WithReferenceTypes_ReturnsExpectedOutcome(
        string first,
        string second,
        bool expectedHandled,
        int expectedComparisonResult)
    {
        var handled = ComparisonCreator.CompareForNull(first, second, out var comparisonResult);

        Assert.Equal((expectedHandled, expectedComparisonResult), (handled, comparisonResult));
    }

    [Fact]
    public void CompareForNull_WithValueTypes_ReturnsUnhandledWithZeroComparison()
    {
        var handled = ComparisonCreator.CompareForNull(10, 20, out var comparisonResult);

        Assert.Equal((false, 0), (handled, comparisonResult));
    }

    private static Comparison<TestObject> CreateStringPropertyComparison()
        => ComparisonCreator.GetComparison<TestObject, string>(testObject => testObject.NullableProperty);

    private static TestObject CreateTestObject(string nullableProperty)
        => new() { NullableProperty = nullableProperty };

    private sealed class TestObject
    {
        public string NullableProperty { get; set; }
    }
}

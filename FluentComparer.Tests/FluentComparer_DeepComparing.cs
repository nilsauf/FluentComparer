namespace FluentComparer.Tests;

using System.Collections.Generic;
using Xunit;

public class FluentComparer_DeepComparing()
{
    [Theory]
    [InlineData(2, 3, 2, 2, 1)]
    [InlineData(2, 3, 2, 3, 0)]
    [InlineData(2, 3, 2, 4, -1)]
    [InlineData(2, 3, 3, 4, -1)]
    public void FluentComparer_DeepComparing_ReturnsExpectedComparison(
        int firstLeft,
        int secondLeft,
        int firstRight,
        int secondRight,
        int expectedResult)
    {
        var comparer = CreateComparer();
        var left = new TestClass(firstLeft, secondLeft);
        var right = new TestClass(firstRight, secondRight);

        var result = comparer.Compare(left, right);

        Assert.Equal(expectedResult, result);
    }

    private static IComparer<TestClass> CreateComparer()
        => FluentComparer<TestClass>
            .For(testClass => testClass.First)
            .For(testClass => testClass.Second);
}

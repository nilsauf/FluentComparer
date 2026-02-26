namespace FluentComparer.Tests;

using System.Collections.Generic;
using Xunit;

public class FluentComparer_Comparing()
{
    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(2, 2, 0)]
    [InlineData(2, 3, -1)]
    public void FluentComparer_Comparing_WithFirstProperty_ReturnsExpectedComparison(int firstLeft, int firstRight, int expectedResult)
    {
        var comparer = CreateComparer();
        var left = new TestClass(firstLeft, 3);
        var right = new TestClass(firstRight, 2);

        var result = comparer.Compare(left, right);

        Assert.Equal(expectedResult, result);
    }

    private static IComparer<TestClass> CreateComparer()
        => FluentComparer<TestClass>.For(testClass => testClass.First);
}

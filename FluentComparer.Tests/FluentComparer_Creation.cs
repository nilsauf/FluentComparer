namespace FluentComparer.Tests;

using System;
using System.Collections.Generic;
using Xunit;

public class FluentComparer_Creation()
{
    [Fact]
    public void FluentComparer_Creation_WithValidProperty_ReturnsComparer()
    {
        var comparer = FluentComparer<TestClass>.For(testClass => testClass.First);

        Assert.NotNull(comparer);
    }

    [Fact]
    public void FluentComparer_Creation_WithNullProperty_ThrowsArgumentNullException()
    {
        Func<TestClass, ComparableClass> getProperty = null;

        Assert.Throws<ArgumentNullException>(() => FluentComparer<TestClass>.For(getProperty));
    }

    [Fact]
    public void FluentComparer_Creation_WithNullPropertyOnSecondLevel_ThrowsArgumentNullException()
    {
        Func<TestClass, ComparableClass> getProperty = null;

        Assert.Throws<ArgumentNullException>(
            () => CreateFirstLevelComparer().For(getProperty));
    }

    [Fact]
    public void FluentComparer_Creation_WithNullPropertyOnThirdLevel_ThrowsArgumentNullException()
    {
        Func<TestClass, ComparableClass> getProperty = null;

        Assert.Throws<ArgumentNullException>(
            () => CreateSecondLevelComparer().For(getProperty));
    }

    private static IComparer<TestClass> CreateFirstLevelComparer()
        => FluentComparer<TestClass>.For(testClass => testClass.First);

    private static IComparer<TestClass> CreateSecondLevelComparer()
        => CreateFirstLevelComparer().For(testClass => testClass.Second);
}
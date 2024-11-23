﻿using System;
using FluentAssertions;
using Xunit;

namespace XUnit2.Specs;

public class FrameworkSpecs
{
    [Fact]
    public void When_xunit2_is_used_it_should_throw_xunit_exceptions_for_assertion_failures()
    {
        // Act
        Action act = () => 0.Should().Be(1);

        // Assert
        Exception exception = act.Should().Throw<Exception>().Which;

        // Don't reference the exception type explicitly like this: act.Should().Throw<XunitException>()
        // It could cause this specs project to load the assembly containing the exception (this actually happens for xUnit)
        exception.GetType().FullName.Should().Be("Xunit.Sdk.XunitException");
    }
}

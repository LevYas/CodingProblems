using CodingProblems.MathProblems;
using FluentAssertions;
using System;
using System.Numerics;
using Xunit;

namespace CodingProblemsTests.MathProblems;

public class RandomPointInCircleGenerator_RandPoint
{
    [Theory]
    [InlineData(1, 0, 0)]
    [InlineData(10, 100, 200)]
    public void IsInCircle(double radius, double centerX, double centerY)
    {
        RandomPointInCircleGenerator generator = new(radius, centerX, centerY);
        Vector2 center = new((float)centerX, (float)centerY);

        for (int i = 0; i < 100; i++)
        {
            double[] result = generator.RandPoint();

            Vector2 resPoint = new((float)result[0], (float)result[1]);
            (resPoint - center).Length().Should().BeLessOrEqualTo((float)radius);
        }
    }
}

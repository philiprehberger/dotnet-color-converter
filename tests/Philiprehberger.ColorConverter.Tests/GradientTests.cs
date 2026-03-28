using Xunit;
using Philiprehberger.ColorConverter;

namespace Philiprehberger.ColorConverter.Tests;

public class GradientTests
{
    [Fact]
    public void Generate_ReturnsCorrectNumberOfSteps()
    {
        var start = Color.FromRgb(255, 0, 0);
        var end = Color.FromRgb(0, 0, 255);
        var gradient = Gradient.Generate(start, end, 5);
        Assert.Equal(5, gradient.Length);
    }

    [Fact]
    public void Generate_FirstAndLastMatchStartAndEnd()
    {
        var start = Color.FromRgb(255, 0, 0);
        var end = Color.FromRgb(0, 0, 255);
        var gradient = Gradient.Generate(start, end, 5);
        Assert.Equal(start, gradient[0]);
        Assert.Equal(end, gradient[^1]);
    }

    [Fact]
    public void Generate_TwoSteps_ReturnsStartAndEnd()
    {
        var start = Color.FromRgb(255, 0, 0);
        var end = Color.FromRgb(0, 0, 255);
        var gradient = Gradient.Generate(start, end, 2);
        Assert.Equal(2, gradient.Length);
        Assert.Equal(start, gradient[0]);
        Assert.Equal(end, gradient[1]);
    }

    [Fact]
    public void Generate_ThrowsWhenStepsLessThanTwo()
    {
        var start = Color.FromRgb(255, 0, 0);
        var end = Color.FromRgb(0, 0, 255);
        Assert.Throws<ArgumentOutOfRangeException>(() => Gradient.Generate(start, end, 1));
    }

    [Fact]
    public void Generate_MidpointIsInterpolated()
    {
        var start = Color.FromRgb(0, 0, 0);
        var end = Color.FromRgb(255, 255, 255);
        var gradient = Gradient.Generate(start, end, 3);

        // Midpoint should be approximately gray
        var mid = gradient[1];
        Assert.InRange(mid.R, 120, 140);
        Assert.InRange(mid.G, 120, 140);
        Assert.InRange(mid.B, 120, 140);
    }

    [Fact]
    public void Generate_SameStartAndEnd_ReturnsUniformColors()
    {
        var color = Color.FromRgb(100, 150, 200);
        var gradient = Gradient.Generate(color, color, 4);
        foreach (var c in gradient)
        {
            Assert.Equal(color, c);
        }
    }
}

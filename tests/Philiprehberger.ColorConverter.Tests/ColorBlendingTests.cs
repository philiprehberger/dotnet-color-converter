using Xunit;
using Philiprehberger.ColorConverter;

namespace Philiprehberger.ColorConverter.Tests;

public class ColorBlendingTests
{
    [Fact]
    public void Multiply_BlackWithAny_ReturnsBlack()
    {
        var black = Color.FromRgb(0, 0, 0);
        var red = Color.FromRgb(255, 0, 0);
        var result = ColorBlending.Multiply(black, red);
        Assert.Equal(black, result);
    }

    [Fact]
    public void Multiply_WhiteWithColor_ReturnsColor()
    {
        var white = Color.FromRgb(255, 255, 255);
        var color = Color.FromRgb(128, 64, 32);
        var result = ColorBlending.Multiply(white, color);
        Assert.Equal(color.R, result.R);
        Assert.Equal(color.G, result.G);
        Assert.Equal(color.B, result.B);
    }

    [Fact]
    public void Multiply_TwoColors_ProducesDarkerResult()
    {
        var a = Color.FromRgb(200, 100, 50);
        var b = Color.FromRgb(100, 200, 150);
        var result = ColorBlending.Multiply(a, b);
        Assert.True(result.R <= Math.Min(a.R, b.R));
        Assert.True(result.G <= Math.Min(a.G, b.G));
    }

    [Fact]
    public void Screen_BlackWithColor_ReturnsColor()
    {
        var black = Color.FromRgb(0, 0, 0);
        var color = Color.FromRgb(128, 64, 32);
        var result = ColorBlending.Screen(black, color);
        Assert.Equal(color.R, result.R);
        Assert.Equal(color.G, result.G);
        Assert.Equal(color.B, result.B);
    }

    [Fact]
    public void Screen_WhiteWithAny_ReturnsWhite()
    {
        var white = Color.FromRgb(255, 255, 255);
        var color = Color.FromRgb(128, 64, 32);
        var result = ColorBlending.Screen(white, color);
        Assert.Equal(255, result.R);
        Assert.Equal(255, result.G);
        Assert.Equal(255, result.B);
    }

    [Fact]
    public void Screen_TwoColors_ProducesLighterResult()
    {
        var a = Color.FromRgb(100, 50, 25);
        var b = Color.FromRgb(50, 100, 75);
        var result = ColorBlending.Screen(a, b);
        Assert.True(result.R >= Math.Max(a.R, b.R));
        Assert.True(result.G >= Math.Max(a.G, b.G));
    }

    [Fact]
    public void Overlay_MidGray_ProducesExpectedResult()
    {
        var a = Color.FromRgb(128, 128, 128);
        var b = Color.FromRgb(200, 100, 50);
        var result = ColorBlending.Overlay(a, b);
        // Overlay should return a valid color
        Assert.InRange(result.R, 0, 255);
        Assert.InRange(result.G, 0, 255);
        Assert.InRange(result.B, 0, 255);
    }

    [Fact]
    public void Overlay_BlackWithColor_ReturnsBlack()
    {
        var black = Color.FromRgb(0, 0, 0);
        var color = Color.FromRgb(200, 100, 50);
        var result = ColorBlending.Overlay(black, color);
        Assert.Equal(0, result.R);
        Assert.Equal(0, result.G);
        Assert.Equal(0, result.B);
    }
}

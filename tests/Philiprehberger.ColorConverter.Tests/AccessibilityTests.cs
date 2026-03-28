using Xunit;
using Philiprehberger.ColorConverter;

namespace Philiprehberger.ColorConverter.Tests;

public class AccessibilityTests
{
    [Fact]
    public void ContrastRatio_BlackOnWhite_Returns21()
    {
        var black = Color.FromRgb(0, 0, 0);
        var white = Color.FromRgb(255, 255, 255);
        var ratio = Accessibility.ContrastRatio(black, white);
        Assert.Equal(21.0, ratio, 1);
    }

    [Fact]
    public void ContrastRatio_SameColor_Returns1()
    {
        var red = Color.FromRgb(255, 0, 0);
        var ratio = Accessibility.ContrastRatio(red, red);
        Assert.Equal(1.0, ratio, 1);
    }

    [Fact]
    public void ContrastRatio_IsSymmetric()
    {
        var a = Color.FromRgb(100, 50, 200);
        var b = Color.FromRgb(200, 220, 30);
        var ratio1 = Accessibility.ContrastRatio(a, b);
        var ratio2 = Accessibility.ContrastRatio(b, a);
        Assert.Equal(ratio1, ratio2, 10);
    }

    [Fact]
    public void MeetsWcagAA_BlackOnWhite_ReturnsTrue()
    {
        var black = Color.FromRgb(0, 0, 0);
        var white = Color.FromRgb(255, 255, 255);
        Assert.True(Accessibility.MeetsWcagAA(black, white));
    }

    [Fact]
    public void MeetsWcagAA_LightGrayOnWhite_ReturnsFalse()
    {
        var lightGray = Color.FromRgb(200, 200, 200);
        var white = Color.FromRgb(255, 255, 255);
        Assert.False(Accessibility.MeetsWcagAA(lightGray, white));
    }

    [Fact]
    public void MeetsWcagAAA_BlackOnWhite_ReturnsTrue()
    {
        var black = Color.FromRgb(0, 0, 0);
        var white = Color.FromRgb(255, 255, 255);
        Assert.True(Accessibility.MeetsWcagAAA(black, white));
    }

    [Fact]
    public void MeetsWcagAAA_DarkGrayOnWhite_ReturnsFalse()
    {
        var darkGray = Color.FromRgb(100, 100, 100);
        var white = Color.FromRgb(255, 255, 255);
        // Contrast ratio ~3.9:1 -- passes AA large text but not AAA
        Assert.False(Accessibility.MeetsWcagAAA(darkGray, white));
    }

    [Fact]
    public void RelativeLuminance_White_Returns1()
    {
        var white = Color.FromRgb(255, 255, 255);
        Assert.Equal(1.0, Accessibility.RelativeLuminance(white), 2);
    }

    [Fact]
    public void RelativeLuminance_Black_Returns0()
    {
        var black = Color.FromRgb(0, 0, 0);
        Assert.Equal(0.0, Accessibility.RelativeLuminance(black), 2);
    }
}

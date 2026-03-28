using Xunit;
using Philiprehberger.ColorConverter;

namespace Philiprehberger.ColorConverter.Tests;

public class ColorHarmoniesTests
{
    [Fact]
    public void Complementary_RotatesHueBy180Degrees()
    {
        var red = Color.FromRgb(255, 0, 0);
        var complement = ColorHarmonies.Complementary(red);
        var hsl = complement.ToHsl();
        Assert.InRange(hsl.H, 179, 181);
    }

    [Fact]
    public void Triadic_ReturnsTwoColorsAt120DegreeIntervals()
    {
        var red = Color.FromRgb(255, 0, 0);
        var triadic = ColorHarmonies.Triadic(red);
        Assert.Equal(2, triadic.Length);

        var hsl1 = triadic[0].ToHsl();
        var hsl2 = triadic[1].ToHsl();
        Assert.InRange(hsl1.H, 119, 121);
        Assert.InRange(hsl2.H, 239, 241);
    }

    [Fact]
    public void Tetradic_ReturnsThreeColorsAt90DegreeIntervals()
    {
        var red = Color.FromRgb(255, 0, 0);
        var tetradic = ColorHarmonies.Tetradic(red);
        Assert.Equal(3, tetradic.Length);

        var hsl1 = tetradic[0].ToHsl();
        var hsl2 = tetradic[1].ToHsl();
        var hsl3 = tetradic[2].ToHsl();
        Assert.InRange(hsl1.H, 89, 91);
        Assert.InRange(hsl2.H, 179, 181);
        Assert.InRange(hsl3.H, 269, 271);
    }

    [Fact]
    public void Analogous_ReturnsTwoColorsAt30DegreeOffsets()
    {
        var red = Color.FromRgb(255, 0, 0);
        var analogous = ColorHarmonies.Analogous(red);
        Assert.Equal(2, analogous.Length);

        var hsl1 = analogous[0].ToHsl();
        var hsl2 = analogous[1].ToHsl();
        Assert.InRange(hsl1.H, 29, 31);
        Assert.InRange(hsl2.H, 329, 331);
    }

    [Fact]
    public void SplitComplementary_ReturnsTwoColorsAt150And210Degrees()
    {
        var red = Color.FromRgb(255, 0, 0);
        var split = ColorHarmonies.SplitComplementary(red);
        Assert.Equal(2, split.Length);

        var hsl1 = split[0].ToHsl();
        var hsl2 = split[1].ToHsl();
        Assert.InRange(hsl1.H, 149, 151);
        Assert.InRange(hsl2.H, 209, 211);
    }

    [Fact]
    public void Complementary_PreservesSaturationAndLightness()
    {
        var color = Color.FromHsl(60, 0.8, 0.5);
        var complement = ColorHarmonies.Complementary(color);
        var hsl = complement.ToHsl();
        Assert.InRange(hsl.S, 0.78, 0.82);
        Assert.InRange(hsl.L, 0.48, 0.52);
    }
}

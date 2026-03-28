namespace Philiprehberger.ColorConverter;

/// <summary>
/// Provides color harmony functions that generate aesthetically pleasing color combinations
/// by rotating hue in HSL color space.
/// </summary>
public static class ColorHarmonies
{
    /// <summary>
    /// Returns the complementary color (hue rotated by 180 degrees).
    /// </summary>
    /// <param name="color">The base color.</param>
    /// <returns>The complementary color.</returns>
    public static Color Complementary(Color color)
    {
        var hsl = color.ToHsl();
        var newH = (hsl.H + 180) % 360;
        return Color.FromHsl(newH, hsl.S, hsl.L);
    }

    /// <summary>
    /// Returns two triadic colors (hue rotated by 120 and 240 degrees).
    /// </summary>
    /// <param name="color">The base color.</param>
    /// <returns>An array of two colors at 120-degree intervals from the base.</returns>
    public static Color[] Triadic(Color color)
    {
        var hsl = color.ToHsl();
        return
        [
            Color.FromHsl((hsl.H + 120) % 360, hsl.S, hsl.L),
            Color.FromHsl((hsl.H + 240) % 360, hsl.S, hsl.L),
        ];
    }

    /// <summary>
    /// Returns three tetradic colors (hue rotated by 90, 180, and 270 degrees).
    /// </summary>
    /// <param name="color">The base color.</param>
    /// <returns>An array of three colors at 90-degree intervals from the base.</returns>
    public static Color[] Tetradic(Color color)
    {
        var hsl = color.ToHsl();
        return
        [
            Color.FromHsl((hsl.H + 90) % 360, hsl.S, hsl.L),
            Color.FromHsl((hsl.H + 180) % 360, hsl.S, hsl.L),
            Color.FromHsl((hsl.H + 270) % 360, hsl.S, hsl.L),
        ];
    }

    /// <summary>
    /// Returns two analogous colors (hue rotated by +30 and -30 degrees).
    /// </summary>
    /// <param name="color">The base color.</param>
    /// <returns>An array of two colors at +/-30 degrees from the base hue.</returns>
    public static Color[] Analogous(Color color)
    {
        var hsl = color.ToHsl();
        return
        [
            Color.FromHsl(((hsl.H + 30) % 360 + 360) % 360, hsl.S, hsl.L),
            Color.FromHsl(((hsl.H - 30) % 360 + 360) % 360, hsl.S, hsl.L),
        ];
    }

    /// <summary>
    /// Returns two split-complementary colors (hue rotated by 150 and 210 degrees).
    /// </summary>
    /// <param name="color">The base color.</param>
    /// <returns>An array of two colors at 150 and 210 degrees from the base hue.</returns>
    public static Color[] SplitComplementary(Color color)
    {
        var hsl = color.ToHsl();
        return
        [
            Color.FromHsl((hsl.H + 150) % 360, hsl.S, hsl.L),
            Color.FromHsl((hsl.H + 210) % 360, hsl.S, hsl.L),
        ];
    }
}

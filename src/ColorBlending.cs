namespace Philiprehberger.ColorConverter;

/// <summary>
/// Provides color blending operations that combine two colors using standard blend modes.
/// </summary>
public static class ColorBlending
{
    /// <summary>
    /// Blends two colors using the Multiply blend mode (a * b for each channel).
    /// Produces a darker result.
    /// </summary>
    /// <param name="a">The first color.</param>
    /// <param name="b">The second color.</param>
    /// <returns>The blended color.</returns>
    public static Color Multiply(Color a, Color b)
    {
        return BlendChannels(a, b, (ca, cb) => ca * cb);
    }

    /// <summary>
    /// Blends two colors using the Screen blend mode (1 - (1-a)*(1-b) for each channel).
    /// Produces a lighter result.
    /// </summary>
    /// <param name="a">The first color.</param>
    /// <param name="b">The second color.</param>
    /// <returns>The blended color.</returns>
    public static Color Screen(Color a, Color b)
    {
        return BlendChannels(a, b, (ca, cb) => 1.0 - (1.0 - ca) * (1.0 - cb));
    }

    /// <summary>
    /// Blends two colors using the Overlay blend mode.
    /// Combines Multiply and Screen: if base &lt; 0.5 then 2*a*b, else 1 - 2*(1-a)*(1-b).
    /// </summary>
    /// <param name="a">The base color.</param>
    /// <param name="b">The blend color.</param>
    /// <returns>The blended color.</returns>
    public static Color Overlay(Color a, Color b)
    {
        return BlendChannels(a, b, (ca, cb) =>
            ca < 0.5
                ? 2.0 * ca * cb
                : 1.0 - 2.0 * (1.0 - ca) * (1.0 - cb));
    }

    private static Color BlendChannels(Color a, Color b, Func<double, double, double> blend)
    {
        var r = (byte)Math.Clamp(Math.Round(blend(a.R / 255.0, b.R / 255.0) * 255), 0, 255);
        var g = (byte)Math.Clamp(Math.Round(blend(a.G / 255.0, b.G / 255.0) * 255), 0, 255);
        var bl = (byte)Math.Clamp(Math.Round(blend(a.B / 255.0, b.B / 255.0) * 255), 0, 255);

        return Color.FromRgb(r, g, bl);
    }
}

namespace Philiprehberger.ColorConverter;

/// <summary>
/// Provides WCAG 2.1 contrast ratio calculations for evaluating color accessibility.
/// </summary>
public static class Accessibility
{
    /// <summary>
    /// Calculates the WCAG 2.1 contrast ratio between two colors.
    /// The result ranges from 1:1 (identical) to 21:1 (black on white).
    /// </summary>
    /// <param name="a">The first color.</param>
    /// <param name="b">The second color.</param>
    /// <returns>The contrast ratio as a double (e.g. 4.5 means 4.5:1).</returns>
    public static double ContrastRatio(Color a, Color b)
    {
        var l1 = RelativeLuminance(a);
        var l2 = RelativeLuminance(b);

        var lighter = Math.Max(l1, l2);
        var darker = Math.Min(l1, l2);

        return (lighter + 0.05) / (darker + 0.05);
    }

    /// <summary>
    /// Determines whether two colors meet WCAG AA contrast requirements (ratio >= 4.5:1).
    /// </summary>
    /// <param name="a">The first color.</param>
    /// <param name="b">The second color.</param>
    /// <returns><c>true</c> if the contrast ratio is at least 4.5:1; otherwise <c>false</c>.</returns>
    public static bool MeetsWcagAA(Color a, Color b)
    {
        return ContrastRatio(a, b) >= 4.5;
    }

    /// <summary>
    /// Determines whether two colors meet WCAG AAA contrast requirements (ratio >= 7:1).
    /// </summary>
    /// <param name="a">The first color.</param>
    /// <param name="b">The second color.</param>
    /// <returns><c>true</c> if the contrast ratio is at least 7:1; otherwise <c>false</c>.</returns>
    public static bool MeetsWcagAAA(Color a, Color b)
    {
        return ContrastRatio(a, b) >= 7.0;
    }

    /// <summary>
    /// Calculates the relative luminance of a color per WCAG 2.1 specification.
    /// </summary>
    /// <param name="color">The color to calculate luminance for.</param>
    /// <returns>The relative luminance value between 0.0 and 1.0.</returns>
    public static double RelativeLuminance(Color color)
    {
        var r = Linearize(color.R / 255.0);
        var g = Linearize(color.G / 255.0);
        var b = Linearize(color.B / 255.0);

        return 0.2126 * r + 0.7152 * g + 0.0722 * b;
    }

    private static double Linearize(double channel)
    {
        return channel <= 0.04045
            ? channel / 12.92
            : Math.Pow((channel + 0.055) / 1.055, 2.4);
    }
}

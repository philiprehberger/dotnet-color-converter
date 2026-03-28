namespace Philiprehberger.ColorConverter;

/// <summary>
/// Generates color gradients by interpolating between colors in HSL space.
/// </summary>
public static class Gradient
{
    /// <summary>
    /// Generates an array of evenly-spaced colors interpolated in HSL space between
    /// <paramref name="start"/> and <paramref name="end"/> (inclusive).
    /// </summary>
    /// <param name="start">The starting color.</param>
    /// <param name="end">The ending color.</param>
    /// <param name="steps">The number of colors to generate (must be at least 2).</param>
    /// <returns>An array of <paramref name="steps"/> colors from start to end.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="steps"/> is less than 2.</exception>
    public static Color[] Generate(Color start, Color end, int steps)
    {
        if (steps < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(steps), "Steps must be at least 2.");
        }

        var startHsl = start.ToHsl();
        var endHsl = end.ToHsl();

        var colors = new Color[steps];

        for (var i = 0; i < steps; i++)
        {
            var t = (double)i / (steps - 1);

            var h = InterpolateHue(startHsl.H, endHsl.H, t);
            var s = startHsl.S + (endHsl.S - startHsl.S) * t;
            var l = startHsl.L + (endHsl.L - startHsl.L) * t;

            colors[i] = Color.FromHsl(h, s, l);
        }

        return colors;
    }

    private static double InterpolateHue(double startH, double endH, double t)
    {
        var diff = endH - startH;

        if (diff > 180)
        {
            diff -= 360;
        }
        else if (diff < -180)
        {
            diff += 360;
        }

        var h = startH + diff * t;
        return ((h % 360) + 360) % 360;
    }
}

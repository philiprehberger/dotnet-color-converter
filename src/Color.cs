namespace Philiprehberger.ColorConverter;

/// <summary>
/// Represents an immutable RGBA color with conversions between RGB, HSL, HSV, Hex, and CMYK
/// color models, plus manipulation operations.
/// </summary>
public readonly struct Color : IEquatable<Color>
{
    /// <summary>
    /// Gets the red component (0–255).
    /// </summary>
    public byte R { get; }

    /// <summary>
    /// Gets the green component (0–255).
    /// </summary>
    public byte G { get; }

    /// <summary>
    /// Gets the blue component (0–255).
    /// </summary>
    public byte B { get; }

    /// <summary>
    /// Gets the alpha component (0–255).
    /// </summary>
    public byte A { get; }

    private Color(byte r, byte g, byte b, byte a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    // ── Static Factories ──────────────────────────────────────────────

    /// <summary>
    /// Creates a <see cref="Color"/> from RGB byte values.
    /// </summary>
    /// <param name="r">Red component (0–255).</param>
    /// <param name="g">Green component (0–255).</param>
    /// <param name="b">Blue component (0–255).</param>
    /// <param name="a">Alpha component (0–255). Defaults to 255 (fully opaque).</param>
    /// <returns>A new <see cref="Color"/> instance.</returns>
    public static Color FromRgb(byte r, byte g, byte b, byte a = 255)
    {
        return new Color(r, g, b, a);
    }

    /// <summary>
    /// Creates a <see cref="Color"/> from a hexadecimal string (e.g. "#FF0000", "FF0000", "#F00").
    /// </summary>
    /// <param name="hex">A 3, 4, 6, or 8 character hex string, with or without a leading '#'.</param>
    /// <returns>A new <see cref="Color"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when the hex string format is invalid.</exception>
    public static Color FromHex(string hex)
    {
        ArgumentNullException.ThrowIfNull(hex);

        var h = hex.TrimStart('#');

        byte r, g, b, a = 255;

        switch (h.Length)
        {
            case 3:
                r = Convert.ToByte(new string(h[0], 2), 16);
                g = Convert.ToByte(new string(h[1], 2), 16);
                b = Convert.ToByte(new string(h[2], 2), 16);
                break;
            case 4:
                r = Convert.ToByte(new string(h[0], 2), 16);
                g = Convert.ToByte(new string(h[1], 2), 16);
                b = Convert.ToByte(new string(h[2], 2), 16);
                a = Convert.ToByte(new string(h[3], 2), 16);
                break;
            case 6:
                r = Convert.ToByte(h[..2], 16);
                g = Convert.ToByte(h[2..4], 16);
                b = Convert.ToByte(h[4..6], 16);
                break;
            case 8:
                r = Convert.ToByte(h[..2], 16);
                g = Convert.ToByte(h[2..4], 16);
                b = Convert.ToByte(h[4..6], 16);
                a = Convert.ToByte(h[6..8], 16);
                break;
            default:
                throw new ArgumentException($"Invalid hex color format: '{hex}'.", nameof(hex));
        }

        return new Color(r, g, b, a);
    }

    /// <summary>
    /// Creates a <see cref="Color"/> from HSL values.
    /// </summary>
    /// <param name="h">Hue in degrees (0–360).</param>
    /// <param name="s">Saturation (0.0–1.0).</param>
    /// <param name="l">Lightness (0.0–1.0).</param>
    /// <returns>A new <see cref="Color"/> instance.</returns>
    public static Color FromHsl(double h, double s, double l)
    {
        h = ((h % 360) + 360) % 360;
        s = Math.Clamp(s, 0.0, 1.0);
        l = Math.Clamp(l, 0.0, 1.0);

        var c = (1.0 - Math.Abs(2.0 * l - 1.0)) * s;
        var x = c * (1.0 - Math.Abs((h / 60.0) % 2.0 - 1.0));
        var m = l - c / 2.0;

        var (r1, g1, b1) = h switch
        {
            < 60 => (c, x, 0.0),
            < 120 => (x, c, 0.0),
            < 180 => (0.0, c, x),
            < 240 => (0.0, x, c),
            < 300 => (x, 0.0, c),
            _ => (c, 0.0, x),
        };

        var r = (byte)Math.Round((r1 + m) * 255);
        var g = (byte)Math.Round((g1 + m) * 255);
        var b = (byte)Math.Round((b1 + m) * 255);

        return new Color(r, g, b, 255);
    }

    /// <summary>
    /// Creates a <see cref="Color"/> from HSV values.
    /// </summary>
    /// <param name="h">Hue in degrees (0–360).</param>
    /// <param name="s">Saturation (0.0–1.0).</param>
    /// <param name="v">Value/brightness (0.0–1.0).</param>
    /// <returns>A new <see cref="Color"/> instance.</returns>
    public static Color FromHsv(double h, double s, double v)
    {
        h = ((h % 360) + 360) % 360;
        s = Math.Clamp(s, 0.0, 1.0);
        v = Math.Clamp(v, 0.0, 1.0);

        var c = v * s;
        var x = c * (1.0 - Math.Abs((h / 60.0) % 2.0 - 1.0));
        var m = v - c;

        var (r1, g1, b1) = h switch
        {
            < 60 => (c, x, 0.0),
            < 120 => (x, c, 0.0),
            < 180 => (0.0, c, x),
            < 240 => (0.0, x, c),
            < 300 => (x, 0.0, c),
            _ => (c, 0.0, x),
        };

        var r = (byte)Math.Round((r1 + m) * 255);
        var g = (byte)Math.Round((g1 + m) * 255);
        var b = (byte)Math.Round((b1 + m) * 255);

        return new Color(r, g, b, 255);
    }

    /// <summary>
    /// Parses a CSS named color (e.g. "red", "coral", "teal").
    /// </summary>
    /// <param name="name">The CSS color name.</param>
    /// <returns>A new <see cref="Color"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when the color name is not recognized.</exception>
    public static Color Parse(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        if (CssColors.Map.TryGetValue(name.Trim(), out var color))
        {
            return color;
        }

        throw new ArgumentException($"Unknown CSS color name: '{name}'.", nameof(name));
    }

    // ── Conversion Methods ────────────────────────────────────────────

    /// <summary>
    /// Converts this color to a hexadecimal string (e.g. "#FF0000" or "#FF000080" if alpha &lt; 255).
    /// </summary>
    /// <returns>A hex string representation of the color.</returns>
    public string ToHex()
    {
        return A < 255
            ? $"#{R:X2}{G:X2}{B:X2}{A:X2}"
            : $"#{R:X2}{G:X2}{B:X2}";
    }

    /// <summary>
    /// Returns the RGBA components as a tuple.
    /// </summary>
    /// <returns>A tuple of (R, G, B, A) byte values.</returns>
    public (byte R, byte G, byte B, byte A) ToRgb()
    {
        return (R, G, B, A);
    }

    /// <summary>
    /// Converts this color to the HSL color model.
    /// </summary>
    /// <returns>An <see cref="HslColor"/> representing this color.</returns>
    public HslColor ToHsl()
    {
        var r = R / 255.0;
        var g = G / 255.0;
        var b = B / 255.0;

        var max = Math.Max(r, Math.Max(g, b));
        var min = Math.Min(r, Math.Min(g, b));
        var delta = max - min;

        var l = (max + min) / 2.0;

        if (delta == 0)
        {
            return new HslColor(0, 0, l);
        }

        var s = l > 0.5
            ? delta / (2.0 - max - min)
            : delta / (max + min);

        double h;
        if (max == r)
        {
            h = ((g - b) / delta + (g < b ? 6 : 0)) * 60;
        }
        else if (max == g)
        {
            h = ((b - r) / delta + 2) * 60;
        }
        else
        {
            h = ((r - g) / delta + 4) * 60;
        }

        return new HslColor(Math.Round(h, 2), Math.Round(s, 4), Math.Round(l, 4));
    }

    /// <summary>
    /// Converts this color to the HSV color model.
    /// </summary>
    /// <returns>An <see cref="HsvColor"/> representing this color.</returns>
    public HsvColor ToHsv()
    {
        var r = R / 255.0;
        var g = G / 255.0;
        var b = B / 255.0;

        var max = Math.Max(r, Math.Max(g, b));
        var min = Math.Min(r, Math.Min(g, b));
        var delta = max - min;

        var v = max;

        if (delta == 0)
        {
            return new HsvColor(0, 0, Math.Round(v, 4));
        }

        var s = max == 0 ? 0 : delta / max;

        double h;
        if (max == r)
        {
            h = ((g - b) / delta + (g < b ? 6 : 0)) * 60;
        }
        else if (max == g)
        {
            h = ((b - r) / delta + 2) * 60;
        }
        else
        {
            h = ((r - g) / delta + 4) * 60;
        }

        return new HsvColor(Math.Round(h, 2), Math.Round(s, 4), Math.Round(v, 4));
    }

    /// <summary>
    /// Converts this color to the CMYK color model.
    /// </summary>
    /// <returns>A <see cref="CmykColor"/> representing this color.</returns>
    public CmykColor ToCmyk()
    {
        var r = R / 255.0;
        var g = G / 255.0;
        var b = B / 255.0;

        var k = 1.0 - Math.Max(r, Math.Max(g, b));

        if (k >= 1.0)
        {
            return new CmykColor(0, 0, 0, 1);
        }

        var c = (1.0 - r - k) / (1.0 - k);
        var m = (1.0 - g - k) / (1.0 - k);
        var y = (1.0 - b - k) / (1.0 - k);

        return new CmykColor(Math.Round(c, 4), Math.Round(m, 4), Math.Round(y, 4), Math.Round(k, 4));
    }

    // ── Manipulation Methods ──────────────────────────────────────────

    /// <summary>
    /// Returns a new color that is lighter by the specified amount.
    /// </summary>
    /// <param name="amount">The amount to lighten (0.0–1.0).</param>
    /// <returns>A new lightened <see cref="Color"/>.</returns>
    public Color Lighten(double amount)
    {
        var hsl = ToHsl();
        var newL = Math.Clamp(hsl.L + amount, 0.0, 1.0);
        var result = FromHsl(hsl.H, hsl.S, newL);
        return new Color(result.R, result.G, result.B, A);
    }

    /// <summary>
    /// Returns a new color that is darker by the specified amount.
    /// </summary>
    /// <param name="amount">The amount to darken (0.0–1.0).</param>
    /// <returns>A new darkened <see cref="Color"/>.</returns>
    public Color Darken(double amount)
    {
        var hsl = ToHsl();
        var newL = Math.Clamp(hsl.L - amount, 0.0, 1.0);
        var result = FromHsl(hsl.H, hsl.S, newL);
        return new Color(result.R, result.G, result.B, A);
    }

    /// <summary>
    /// Returns a new color with increased saturation.
    /// </summary>
    /// <param name="amount">The amount to increase saturation (0.0–1.0).</param>
    /// <returns>A new saturated <see cref="Color"/>.</returns>
    public Color Saturate(double amount)
    {
        var hsl = ToHsl();
        var newS = Math.Clamp(hsl.S + amount, 0.0, 1.0);
        var result = FromHsl(hsl.H, newS, hsl.L);
        return new Color(result.R, result.G, result.B, A);
    }

    /// <summary>
    /// Returns a new color with decreased saturation.
    /// </summary>
    /// <param name="amount">The amount to decrease saturation (0.0–1.0).</param>
    /// <returns>A new desaturated <see cref="Color"/>.</returns>
    public Color Desaturate(double amount)
    {
        var hsl = ToHsl();
        var newS = Math.Clamp(hsl.S - amount, 0.0, 1.0);
        var result = FromHsl(hsl.H, newS, hsl.L);
        return new Color(result.R, result.G, result.B, A);
    }

    /// <summary>
    /// Returns the complementary color (hue rotated by 180 degrees).
    /// </summary>
    /// <returns>A new <see cref="Color"/> that is the complement of this color.</returns>
    public Color Complement()
    {
        var hsl = ToHsl();
        var newH = (hsl.H + 180) % 360;
        var result = FromHsl(newH, hsl.S, hsl.L);
        return new Color(result.R, result.G, result.B, A);
    }

    /// <summary>
    /// Returns a new color with the specified alpha value.
    /// </summary>
    /// <param name="a">The new alpha component (0–255).</param>
    /// <returns>A new <see cref="Color"/> with the updated alpha.</returns>
    public Color WithAlpha(byte a)
    {
        return new Color(R, G, B, a);
    }

    // ── Overrides & Equality ──────────────────────────────────────────

    /// <summary>
    /// Returns the hex string representation of this color.
    /// </summary>
    /// <returns>A hex string (e.g. "#FF0000").</returns>
    public override string ToString() => ToHex();

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is Color other && Equals(other);

    /// <inheritdoc />
    public bool Equals(Color other) => R == other.R && G == other.G && B == other.B && A == other.A;

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(R, G, B, A);

    /// <summary>
    /// Determines whether two <see cref="Color"/> instances are equal.
    /// </summary>
    public static bool operator ==(Color left, Color right) => left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="Color"/> instances are not equal.
    /// </summary>
    public static bool operator !=(Color left, Color right) => !left.Equals(right);
}

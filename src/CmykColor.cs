namespace Philiprehberger.ColorConverter;

/// <summary>
/// Represents a color in the CMYK (Cyan, Magenta, Yellow, Key/Black) color model.
/// </summary>
/// <param name="C">The cyan component (0.0–1.0).</param>
/// <param name="M">The magenta component (0.0–1.0).</param>
/// <param name="Y">The yellow component (0.0–1.0).</param>
/// <param name="K">The key (black) component (0.0–1.0).</param>
public readonly record struct CmykColor(double C, double M, double Y, double K);

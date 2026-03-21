namespace Philiprehberger.ColorConverter;

/// <summary>
/// Represents a color in the HSV (Hue, Saturation, Value) color model.
/// </summary>
/// <param name="H">The hue component, in degrees (0–360).</param>
/// <param name="S">The saturation component (0.0–1.0).</param>
/// <param name="V">The value (brightness) component (0.0–1.0).</param>
public readonly record struct HsvColor(double H, double S, double V);

namespace Philiprehberger.ColorConverter;

/// <summary>
/// Provides a lookup of standard CSS named colors.
/// </summary>
internal static class CssColors
{
    /// <summary>
    /// A dictionary mapping lowercase CSS color names to their <see cref="Color"/> values.
    /// </summary>
    internal static readonly Dictionary<string, Color> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["black"] = Color.FromRgb(0, 0, 0),
        ["white"] = Color.FromRgb(255, 255, 255),
        ["red"] = Color.FromRgb(255, 0, 0),
        ["green"] = Color.FromRgb(0, 128, 0),
        ["blue"] = Color.FromRgb(0, 0, 255),
        ["yellow"] = Color.FromRgb(255, 255, 0),
        ["cyan"] = Color.FromRgb(0, 255, 255),
        ["magenta"] = Color.FromRgb(255, 0, 255),
        ["orange"] = Color.FromRgb(255, 165, 0),
        ["purple"] = Color.FromRgb(128, 0, 128),
        ["pink"] = Color.FromRgb(255, 192, 203),
        ["coral"] = Color.FromRgb(255, 127, 80),
        ["teal"] = Color.FromRgb(0, 128, 128),
        ["navy"] = Color.FromRgb(0, 0, 128),
        ["maroon"] = Color.FromRgb(128, 0, 0),
        ["olive"] = Color.FromRgb(128, 128, 0),
        ["aqua"] = Color.FromRgb(0, 255, 255),
        ["lime"] = Color.FromRgb(0, 255, 0),
        ["silver"] = Color.FromRgb(192, 192, 192),
        ["gray"] = Color.FromRgb(128, 128, 128),
        ["grey"] = Color.FromRgb(128, 128, 128),
        ["gold"] = Color.FromRgb(255, 215, 0),
        ["indigo"] = Color.FromRgb(75, 0, 130),
        ["violet"] = Color.FromRgb(238, 130, 238),
        ["salmon"] = Color.FromRgb(250, 128, 114),
        ["tomato"] = Color.FromRgb(255, 99, 71),
        ["turquoise"] = Color.FromRgb(64, 224, 208),
        ["skyblue"] = Color.FromRgb(135, 206, 235),
        ["chocolate"] = Color.FromRgb(210, 105, 30),
        ["crimson"] = Color.FromRgb(220, 20, 60),
        ["plum"] = Color.FromRgb(221, 160, 221),
    };
}

# Philiprehberger.ColorConverter

[![CI](https://github.com/philiprehberger/dotnet-color-converter/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-color-converter/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.ColorConverter.svg)](https://www.nuget.org/packages/Philiprehberger.ColorConverter)
[![GitHub release](https://img.shields.io/github/v/release/philiprehberger/dotnet-color-converter)](https://github.com/philiprehberger/dotnet-color-converter/releases)
[![Last updated](https://img.shields.io/github/last-commit/philiprehberger/dotnet-color-converter)](https://github.com/philiprehberger/dotnet-color-converter/commits/main)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-color-converter)](LICENSE)
[![Bug Reports](https://img.shields.io/github/issues/philiprehberger/dotnet-color-converter/bug)](https://github.com/philiprehberger/dotnet-color-converter/issues?q=is%3Aissue+is%3Aopen+label%3Abug)
[![Feature Requests](https://img.shields.io/github/issues/philiprehberger/dotnet-color-converter/enhancement)](https://github.com/philiprehberger/dotnet-color-converter/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement)
[![Sponsor](https://img.shields.io/badge/sponsor-GitHub%20Sponsors-ec6cb9)](https://github.com/sponsors/philiprehberger)

Convert between RGB, HSL, HSV, Hex, and CMYK color models with harmonies, contrast ratio, blending, and gradient generation.

## Installation

```bash
dotnet add package Philiprehberger.ColorConverter
```

## Usage

```csharp
using Philiprehberger.ColorConverter;

var color = Color.FromHex("#FF6347");

HslColor hsl = color.ToHsl();
HsvColor hsv = color.ToHsv();
CmykColor cmyk = color.ToCmyk();
string hex = color.ToHex();           // "#FF6347"
var (r, g, b, a) = color.ToRgb();    // (255, 99, 71, 255)
```

### Manipulate Colors

```csharp
var coral = Color.FromHex("#FF7F50");

Color lighter    = coral.Lighten(0.1);
Color darker     = coral.Darken(0.1);
Color vivid      = coral.Saturate(0.2);
Color muted      = coral.Desaturate(0.2);
Color opposite   = coral.Complement();
Color transparent = coral.WithAlpha(128);
```

### CSS Named Colors

```csharp
var teal = Color.Parse("teal");
var coral = Color.Parse("coral");
var gold = Color.Parse("gold");
```

### Color Harmonies

```csharp
var red = Color.FromRgb(255, 0, 0);

Color complement = ColorHarmonies.Complementary(red);
Color[] triadic = ColorHarmonies.Triadic(red);           // 2 colors at 120° intervals
Color[] tetradic = ColorHarmonies.Tetradic(red);         // 3 colors at 90° intervals
Color[] analogous = ColorHarmonies.Analogous(red);       // 2 colors at ±30°
Color[] split = ColorHarmonies.SplitComplementary(red);  // 2 colors at 150° and 210°
```

### WCAG Contrast Ratio

```csharp
var black = Color.FromRgb(0, 0, 0);
var white = Color.FromRgb(255, 255, 255);

double ratio = Accessibility.ContrastRatio(black, white);  // 21.0
bool aa = Accessibility.MeetsWcagAA(black, white);         // true
bool aaa = Accessibility.MeetsWcagAAA(black, white);       // true
```

### Color Blending

```csharp
var a = Color.FromRgb(200, 100, 50);
var b = Color.FromRgb(100, 200, 150);

Color multiplied = ColorBlending.Multiply(a, b);
Color screened = ColorBlending.Screen(a, b);
Color overlaid = ColorBlending.Overlay(a, b);
```

### Gradient Generation

```csharp
var start = Color.FromRgb(255, 0, 0);
var end = Color.FromRgb(0, 0, 255);

Color[] gradient = Gradient.Generate(start, end, 5);  // 5 evenly-spaced colors in HSL space
```

## API

| Method | Description |
|--------|-------------|
| `Color.FromRgb(r, g, b, a)` | Create from RGBA byte values |
| `Color.FromHex(hex)` | Create from hex string (`#RGB`, `#RRGGBB`, `#RRGGBBAA`) |
| `Color.FromHsl(h, s, l)` | Create from HSL values |
| `Color.FromHsv(h, s, v)` | Create from HSV values |
| `Color.Parse(name)` | Create from CSS named color |
| `.ToHex()` | Convert to hex string |
| `.ToRgb()` | Convert to (R, G, B, A) tuple |
| `.ToHsl()` | Convert to `HslColor` |
| `.ToHsv()` | Convert to `HsvColor` |
| `.ToCmyk()` | Convert to `CmykColor` |
| `.Lighten(amount)` | Increase lightness |
| `.Darken(amount)` | Decrease lightness |
| `.Saturate(amount)` | Increase saturation |
| `.Desaturate(amount)` | Decrease saturation |
| `.Complement()` | Get complementary color (hue + 180) |
| `.WithAlpha(a)` | Set alpha channel |
| `ColorHarmonies.Complementary(color)` | Complementary color (180° rotation) |
| `ColorHarmonies.Triadic(color)` | Two colors at 120° intervals |
| `ColorHarmonies.Tetradic(color)` | Three colors at 90° intervals |
| `ColorHarmonies.Analogous(color)` | Two colors at ±30° |
| `ColorHarmonies.SplitComplementary(color)` | Two colors at 150° and 210° |
| `Accessibility.ContrastRatio(a, b)` | WCAG 2.1 contrast ratio |
| `Accessibility.MeetsWcagAA(a, b)` | Check WCAG AA compliance (>= 4.5:1) |
| `Accessibility.MeetsWcagAAA(a, b)` | Check WCAG AAA compliance (>= 7:1) |
| `ColorBlending.Multiply(a, b)` | Multiply blend mode |
| `ColorBlending.Screen(a, b)` | Screen blend mode |
| `ColorBlending.Overlay(a, b)` | Overlay blend mode |
| `Gradient.Generate(start, end, steps)` | Generate HSL-interpolated gradient |

## Development

```bash
dotnet build src/Philiprehberger.ColorConverter.csproj --configuration Release
```

## Support

If you find this package useful, consider giving it a star on GitHub — it helps motivate continued maintenance and development.

[![LinkedIn](https://img.shields.io/badge/Philip%20Rehberger-LinkedIn-0A66C2?logo=linkedin)](https://www.linkedin.com/in/philiprehberger)
[![More packages](https://img.shields.io/badge/more-open%20source%20packages-blue)](https://philiprehberger.com/open-source-packages)

## License

[MIT](LICENSE)

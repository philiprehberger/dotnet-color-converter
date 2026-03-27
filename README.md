# Philiprehberger.ColorConverter

[![CI](https://github.com/philiprehberger/dotnet-color-converter/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-color-converter/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.ColorConverter.svg)](https://www.nuget.org/packages/Philiprehberger.ColorConverter)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-color-converter)](LICENSE)
[![Sponsor](https://img.shields.io/badge/sponsor-GitHub%20Sponsors-ec6cb9)](https://github.com/sponsors/philiprehberger)

Convert between RGB, HSL, HSV, Hex, and CMYK color models with lighten, darken, saturate, and complement operations.

## Installation

```bash
dotnet add package Philiprehberger.ColorConverter
```

## Usage

### Parse and Convert

```csharp
using Philiprehberger.ColorConverter;

var color = Color.FromHex("#FF6347");

// Convert to different models
HslColor hsl = color.ToHsl();
HsvColor hsv = color.ToHsv();
CmykColor cmyk = color.ToCmyk();
string hex = color.ToHex();           // "#FF6347"
var (r, g, b, a) = color.ToRgb();    // (255, 99, 71, 255)

// Create from other models
var fromHsl = Color.FromHsl(9.0, 1.0, 0.6392);
var fromHsv = Color.FromHsv(9.0, 0.7216, 1.0);
var fromRgb = Color.FromRgb(255, 99, 71);
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

Console.WriteLine(teal.ToHex());  // "#008080"
```

## API

| Method | Description |
|---|---|
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

## Development

```bash
dotnet build src/Philiprehberger.ColorConverter.csproj --configuration Release
```

## License

[MIT](LICENSE)

# Changelog

All notable changes to this project will be documented in this file.

## 0.1.2 (2026-03-22)

- Fix README badge order to CI, NuGet, License
- Add build-on-push CI job

## 0.1.1 (2026-03-22)

- Improve README compliance: remove Requirements section, simplify Development section, fix License format
- Add dates to changelog entries

## 0.1.0 (2026-03-21)

### Added

- `Color` readonly struct with internal RGBA storage
- Static factories: `FromRgb`, `FromHex`, `FromHsl`, `FromHsv`, `Parse`
- Conversion methods: `ToHex`, `ToRgb`, `ToHsl`, `ToHsv`, `ToCmyk`
- Manipulation methods: `Lighten`, `Darken`, `Saturate`, `Desaturate`, `Complement`, `WithAlpha`
- `HslColor`, `HsvColor`, and `CmykColor` readonly record structs
- CSS named color parsing (~30 colors)

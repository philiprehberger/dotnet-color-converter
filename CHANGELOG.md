# Changelog

All notable changes to this project will be documented in this file.

## [0.1.0] - 2026-03-21

### Added

- `Color` readonly struct with internal RGBA storage
- Static factories: `FromRgb`, `FromHex`, `FromHsl`, `FromHsv`, `Parse`
- Conversion methods: `ToHex`, `ToRgb`, `ToHsl`, `ToHsv`, `ToCmyk`
- Manipulation methods: `Lighten`, `Darken`, `Saturate`, `Desaturate`, `Complement`, `WithAlpha`
- `HslColor`, `HsvColor`, and `CmykColor` readonly record structs
- CSS named color parsing (~30 colors)

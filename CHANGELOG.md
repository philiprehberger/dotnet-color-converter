# Changelog

## 0.2.0 (2026-03-27)

- Add color harmony functions (complementary, triadic, tetradic, analogous, split-complementary)
- Add WCAG contrast ratio calculation with AA/AAA compliance checks
- Add color blending modes (multiply, screen, overlay)
- Add gradient generation with HSL interpolation

## 0.1.3 (2026-03-26)

- Add Sponsor badge and fix License link format in README

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

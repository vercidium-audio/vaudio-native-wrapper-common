# Vercidium Audio native wrapper — common

Dimension-agnostic C# source shared between
[vaudio-native-wrapper-3d](https://github.com/vercidium-audio/vaudio-native-wrapper-3d) and
[vaudio-native-wrapper-2d](https://github.com/vercidium-audio/vaudio-native-wrapper-2d).

This repo has no `.csproj` of its own — it is consumed as a git submodule and its `.cs` files
are compiled directly into each dimension's project as linked source
(`<Compile Include="..\common\**\*.cs" LinkBase="common" />`). This lets a dimension-shaped
type like `Vector` resolve to whichever `Vector` is visible in the consuming project (2-float
in `vaudio-native-wrapper-2d`, 3-float in `vaudio-native-wrapper-3d`) without generics or
duplicated source.

## Licencing

The Vercidium Audio SDK is free for non-commercial products only. To purchase a licence for
commercial use, head over to the [Vercidium Audio website](https://vercidium.com).

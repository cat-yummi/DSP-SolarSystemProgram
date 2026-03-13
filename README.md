# 太阳系计划 Solar System Program
强制单星系模式，恒星命名为 "Solar System"。
Locks the game to a single solar system named "Solar System".

### SubMission
- 一个简单的MOD示范
- A simple mod for beginner to study.

### Incompatible

- **GalacticScale**
- **UniverseGenTweaks**
- Any MOD modifies galaxies

## Harmony patch
- `UIGalaxySelect._OnOpen` - 隐藏 UI
- `UIGalaxySelect.OnStarCountSliderValueChange` - 阻止修改
- `GameDesc.SetForNewGame` - 设置默认值为 1
- `UniverseGen.CreateGalaxy` - 重命名恒星

## GitHub
- https://github.com/cat-yummi/DSP-SolarSystemProgram

## License
WTFPL - Do What The Fuck You Want To Public License

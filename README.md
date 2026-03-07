# 太阳系计划 Solar System Program

强制单星系模式，恒星命名为 "Solar System"。

Locks the game to a single solar system named "Solar System".

## 功能 Features

- 单星系限定 (starCount = 1)
- 恒星命名为 "Solar System"
- 隐藏星系数量滑块
- 无需配置

## 安装 Installation

**使用 r2modman (推荐):**
1. 搜索 "Solar System Program"
2. 点击安装

**手动安装:**
1. 安装 [BepInEx 5.4.17+](https://github.com/BepInEx/BepInEx/releases)
2. 将 `SolarSystemProgram.dll` 放入 `BepInEx/plugins/` 文件夹
3. 启动游戏

## 兼容性 Compatibility

### ❌ 不兼容 Incompatible

- **GalacticScale** - 星系生成冲突
- **UniverseGenTweaks** - 星系生成冲突
- 任何修改星系数量/生成的 MOD

### ✅ 兼容 Compatible

- 内容 MOD（物品、配方、建筑）
- UI 美化 MOD
- 性能优化 MOD

## 技术细节 Technical Details

使用 Harmony 补丁修改游戏行为：

- `UIGalaxySelect._OnOpen` - 隐藏 UI
- `UIGalaxySelect.OnStarCountSliderValueChange` - 阻止修改
- `GameDesc.SetForNewGame` - 设置默认值为 1
- `UniverseGen.CreateGalaxy` - 重命名恒星

## 链接 Links

- GitHub: https://github.com/cat-yummmi/SolarSystemProgram
- Issues: https://github.com/cat-yummmi/SolarSystemProgram/issues

## 许可证 License

WTFPL - Do What The Fuck You Want To Public License

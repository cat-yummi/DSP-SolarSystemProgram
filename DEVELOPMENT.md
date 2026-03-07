# 太阳系计划 - 开发指南

## 编译项目

### 前置要求

- .NET SDK 或 Visual Studio 2019+
- .NET Framework 4.7.2

### 编译步骤

**方法1：使用命令行**

```powershell
# 进入项目目录
cd E:\developing\dspmod\SolarSystemProgram

# 还原 NuGet 包（首次编译或依赖更新后）
dotnet restore

# 编译 Release 版本
dotnet build -c Release

# 编译 Debug 版本
dotnet build -c Debug
```

**方法2：使用 Visual Studio**

1. 双击打开 `SolarSystemProgram.sln`
2. 选择 Release 配置
3. 右键项目 → 生成

**输出位置：**
```
bin/Release/net472/SolarSystemProgram.dll  (Release)
bin/Debug/net472/SolarSystemProgram.dll    (Debug)
```

---

## 打包 Thunderstore 包

### 方法1：自动打包（推荐）

运行打包脚本：

```powershell
# 进入项目目录
cd E:\developing\dspmod\SolarSystemProgram

# 执行打包脚本
.\build_thunderstore.ps1
```

或者在 PowerShell 中：

```powershell
powershell -ExecutionPolicy Bypass -File build_thunderstore.ps1
```

**输出：** `SolarSystemProgram_v1.0.0.zip`

### 方法2：手动打包

**打包脚本：**

运行打包脚本：
```powershell
.\build_thunderstore.ps1
```

会自动创建包含以下文件的 zip：
- manifest.json
- README.md
- icon.png
- SolarSystemProgram.dll

---

## 快速测试 MOD

### 复制到游戏目录

```powershell
# 复制 DLL 到游戏插件目录
Copy-Item "bin\Release\net472\SolarSystemProgram.dll" -Destination "E:\games\steamapps\steamapps\common\Dyson Sphere Program\BepInEx\plugins\SolarSystemProgram.dll"
```

### 测试清单

1. 启动游戏，查看 BepInEx 控制台
2. 应该看到：`太阳系计划 (Solar System Program) v1.0.0 已加载`
3. 进入"新游戏"界面
4. 检查：星系数量滑块应该被隐藏
5. 创建游戏，恒星名字应该是 "Solar System"

---

## 版本更新流程

### 1. 修改版本号

**manifest.json:**
```json
{
  "version_number": "1.1.0"  // 修改这里
}
```

**SolarSystemProgram.csproj:**
```xml
<Version>1.1.0</Version>  <!-- 修改这里 -->
```

**SolarSystemProgram.cs:**
```csharp
public const string PLUGIN_VERSION = "1.1.0";  // 修改这里
```

### 2. 重新编译

```powershell
dotnet build -c Release
```

### 3. 重新打包

```powershell
.\build_thunderstore.ps1
```

### 4. 提交 Git

```powershell
git add -A
git commit -m "chore: bump version to 1.1.0"
git tag v1.1.0
git push
git push --tags
```

---

## 文件说明

| 文件 | 用途 |
|------|------|
| `SolarSystemProgram.cs` | 主插件类 |
| `SingleStarPatch.cs` | Harmony 补丁 |
| `SolarSystemProgram.csproj` | 项目配置 |
| `manifest.json` | Thunderstore 元数据 |
| `README_Package.md` | 打包用简化 README |
| `build_thunderstore.ps1` | 自动打包脚本 |
| `icon.svg` | 图标源文件 |
| `icon.png` | 256x256 图标（需要手动生成）|

---

## 常见问题

### Q: 编译失败，提示找不到 BepInEx

**A:** 运行 `dotnet restore` 还原 NuGet 包。

### Q: 如何生成 icon.png？

**A:** 方法1：用浏览器打开 `icon.svg`，截图保存为 256x256 PNG
方法2：使用在线工具 https://svgtopng.com/

### Q: 打包后的 ZIP 在哪里？

**A:** 项目根目录下的 `SolarSystemProgram_v1.0.0.zip`

### Q: 如何测试 MOD？

**A:** 复制 `bin/Release/net472/SolarSystemProgram.dll` 到游戏的 `BepInEx/plugins/` 目录

---

## 开发工具推荐

- **IDE**: Visual Studio 2022 / Rider
- **调试**: dnSpy (反编译调试游戏代码)
- **性能分析**: BepInEx 的 `--doorstop-enable` 参数

---

## 相关链接

- BepInEx: https://github.com/BepInEx/BepInEx
- Harmony: https://harmony.pardeike.net/
- Thunderstore: https://dsp.thunderstore.io/

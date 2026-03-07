using HarmonyLib;
using UnityEngine;

namespace SolarSystemProgram
{
    /// <summary>
    /// 单星系限制补丁 - 强制游戏只使用1个星系
    /// </summary>
    [HarmonyPatch]
    public class SingleStarPatch
    {
        /// <summary>
        /// 在 UIGalaxySelect._OnOpen 后执行，隐藏星系数量滑块
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIGalaxySelect), nameof(UIGalaxySelect._OnOpen))]
        public static void UIGalaxySelect_OnOpen_Postfix(UIGalaxySelect __instance)
        {
            if (__instance.starCountSlider != null)
            {
                var sliderGo = __instance.starCountSlider.gameObject;
                
                if (sliderGo.transform.parent != null)
                {
                    sliderGo.transform.parent.gameObject.SetActive(false);
                }
                else
                {
                    sliderGo.SetActive(false);
                }
                
                SolarSystemProgram.Log.LogDebug("已隐藏星系数量滑块");
            }
            
            if (__instance.starCountText != null)
            {
                __instance.starCountText.gameObject.SetActive(false);
                SolarSystemProgram.Log.LogDebug("已隐藏星系数量文本");
            }
        }

        /// <summary>
        /// 拦截星系数量滑块变化事件，强制保持为1
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(UIGalaxySelect), nameof(UIGalaxySelect.OnStarCountSliderValueChange))]
        public static bool UIGalaxySelect_OnStarCountSliderValueChange_Prefix(UIGalaxySelect __instance)
        {
            if (__instance.gameDesc != null)
            {
                __instance.gameDesc.starCount = 1;
            }
            return false;
        }

        /// <summary>
        /// 在创建新游戏时，强制星系数量为1
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(GameDesc), nameof(GameDesc.SetForNewGame))]
        public static void GameDesc_SetForNewGame_Postfix(GameDesc __instance)
        {
            __instance.starCount = 1;
            SolarSystemProgram.Log.LogInfo($"新游戏星系数量已设置为: {__instance.starCount}");
        }

        /// <summary>
        /// 在生成星系后，将唯一的恒星命名为 "Solar System"
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UniverseGen), nameof(UniverseGen.CreateGalaxy))]
        public static void UniverseGen_CreateGalaxy_Postfix(GalaxyData __result)
        {
            if (__result != null && __result.stars != null && __result.stars.Length > 0)
            {
                __result.stars[0].name = "Solar System";
                __result.stars[0].overrideName = "Solar System";
                SolarSystemProgram.Log.LogInfo("已将恒星命名为: Solar System");
            }
        }
    }
}

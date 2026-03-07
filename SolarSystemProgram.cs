using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace SolarSystemProgram
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class SolarSystemProgram : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "com.yummi.dsp.solarsystemprogram";
        public const string PLUGIN_NAME = "太阳系计划 (Solar System Program)";
        public const string PLUGIN_VERSION = "1.0.0";

        private static readonly Harmony harmony = new Harmony(PLUGIN_GUID);
        internal static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;
            
            harmony.PatchAll(typeof(SingleStarPatch));
            
            Log.LogInfo($"{PLUGIN_NAME} v{PLUGIN_VERSION} 已加载");
            Log.LogInfo("游戏已限制为单星系模式");
        }

        private void OnDestroy()
        {
            harmony.UnpatchSelf();
        }
    }
}

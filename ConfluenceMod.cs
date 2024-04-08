using HarmonyLib;
using Verse;

namespace confluence_ui_mod {
    public class ConfluenceMod : Mod
    {
		public static Harmony Harmony;
        public ConfluenceMod(ModContentPack content) : base(content)
        {
			Harmony = new Harmony("mistahoward.confluence");
			Harmony.DEBUG = true;
			Harmony.PatchAll();
			Log.Message("Confluence UI Mod Loaded");
        }
    }
}

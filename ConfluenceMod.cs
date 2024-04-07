using HarmonyLib;
using RimWorld;
using Verse;

namespace confluence_ui_mod {
    public class ConfluenceMod : Mod
    {
		public static Harmony Harmony;
        public ConfluenceMod(ModContentPack content) : base(content)
        {
			Harmony = new Harmony("mistahoward.confluence");
        }
    }
}

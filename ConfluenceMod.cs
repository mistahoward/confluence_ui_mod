using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace confluence_ui_mod {
    public class ConfluenceMod : Mod
    {
		public static ConfluenceMod Instance;
		public static Harmony Harmony;
		public List<string> JoysticksOnLoad = new List<string>();
        public ConfluenceMod(ModContentPack content) : base(content)
        {
			Instance = this;
			Harmony = new Harmony("mistahoward.confluence");
			// Harmony.DEBUG = true;
			Log.Message("Confluence UI Mod Loaded");
			var listOfInputs = Input.GetJoystickNames();
			JoysticksOnLoad = new List<string>(listOfInputs);
			Log.Message($"Found {listOfInputs.Length} joysticks");
			Log.Message("Start Joysticks List");
			foreach (var input in listOfInputs)
			{
				Log.Message(input);
			}
			Log.Message("End Joysticks");
			Harmony.Patch(AccessTools.Method(typeof(GameComponent), "GameComponentTick"), null, new HarmonyMethod(typeof(ConfluenceMod), "JoystickListener"));
        }
		[HarmonyPatch(typeof(GameComponent), "GameComponentUpdate")]
		public static void JoystickListener() {
			var currentJoysticks = new List<string>(Input.GetJoystickNames());
			// check if joystick was removed or added
			IEnumerable<string> newJoysticks = currentJoysticks.Except(Instance.JoysticksOnLoad);
			IEnumerable<string> removedJoysticks = Instance.JoysticksOnLoad.Except(currentJoysticks);
			if (newJoysticks.Count() > 0)
			{
				Log.Message("Joystick Added");
				foreach (var joystick in newJoysticks)
				{
					Log.Message(joystick);
				}
			}
			if (removedJoysticks.Count() > 0)
			{
				Log.Message("Joystick Removed");
				foreach (var joystick in removedJoysticks)
				{
					Log.Message(joystick);
				}
			}
			Instance.JoysticksOnLoad = currentJoysticks;
			if (Input.inputString != "")
			{
				Log.Message(Input.inputString);
			}
			// check if any controller buttons are pressed
			foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
			{
				if (Input.GetKey(vKey))
				{
					Log.Message(vKey.ToString());
				}
			}
		}
    }
}

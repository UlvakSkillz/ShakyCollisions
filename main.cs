using MelonLoader;
using Il2CppRUMBLE.MoveSystem;
using RumbleModUI;
using System.Collections.Generic;

namespace ShakyCollisions
{
    public class main : MelonMod
    {
        public static class BuildInfo
        {
            public const string ModName = "Shaky Collisions";
            public const string ModVersion = "2.1.0";
            public const string Author = "UlvakSkillz";
        }

        private Mod ShakyCollisions = new Mod();
        List<ModSetting> settings = new List<ModSetting>();

        public override void OnLateInitializeMelon()
        {
            UI.instance.UI_Initialized += UIInit;
        }

        private void UIInit()
        {
            ShakyCollisions.ModName = BuildInfo.ModName;
            ShakyCollisions.ModVersion = BuildInfo.ModVersion;
            ShakyCollisions.SetFolder(BuildInfo.ModName);
            settings.Add(ShakyCollisions.AddToList("Enabled", false, 0, "Toggles Mod On/Off", new Tags { }));
            settings.Add(ShakyCollisions.AddToList("Shake Strength", 1.875f, "Controls how Shaky the Structures are. 0.375 is the Game's Default.", new Tags { }));
            ShakyCollisions.GetFromFile();
            Save();
            ShakyCollisions.ModSaved += Save;
            UI.instance.AddMod(ShakyCollisions);
        }

        private void Save()
        {
            if ((bool)settings[0].SavedValue) { CombatManager.instance.structureImpactShakeStrength = (float)settings[1].SavedValue; } //turn on
            else { CombatManager.instance.structureImpactShakeStrength = 0.375f; } //turn off
        }
    }
}

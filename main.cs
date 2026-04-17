using Il2CppRUMBLE.MoveSystem;
using MelonLoader;
using UIFramework;

namespace ShakyCollisions
{
    public class main : MelonMod
    {
        public static class BuildInfo
        {
            public const string ModName = "Shaky Collisions";
            public const string ModVersion = "2.2.2";
            public const string Author = "UlvakSkillz";
        }

        public override void OnInitializeMelon()
        {
            Preferences.InitPrefs();
            UI.Register((MelonBase)this, Preferences.ShakyCollisionsCategory).OnModSaved += Save;
        }

        private void Save()
        {
            if (Preferences.AnyPrefsChanged())
            {
                if (Preferences.PrefEnabled.Value) { CombatManager.instance.structureImpactShakeStrength = Preferences.PrefShakeStrength.Value; } //turn on Strength
                else { CombatManager.instance.structureImpactShakeStrength = 0.375f; } //turn off Strength
                if (Preferences.PrefEnabled.Value) { CombatManager.instance.structureImpactShakeFrequency = Preferences.PrefShakeFrequency.Value; } //turn on Frequency
                else { CombatManager.instance.structureImpactShakeFrequency = 75f; } //turn off Frequency
            }
        }
    }
}

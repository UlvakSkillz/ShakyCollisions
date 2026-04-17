using MelonLoader;
using MelonLoader.Preferences;
using System.Collections.Generic;
using System.IO;

namespace ShakyCollisions
{
	public class Preferences
	{
		private const string CONFIG_FILE = "config.cfg";
		private const string USER_DATA = "UserData/ShakyCollisions/";
        internal static Dictionary<MelonPreferences_Entry, object> LastSavedValues = new Dictionary<MelonPreferences_Entry, object>();

        internal static MelonPreferences_Category ShakyCollisionsCategory;
		internal static MelonPreferences_Entry<bool> PrefEnabled;
		internal static MelonPreferences_Entry<float> PrefShakeStrength;
		internal static MelonPreferences_Entry<float> PrefShakeFrequency;

		internal static void InitPrefs()
		{
			if (!Directory.Exists(USER_DATA)) { Directory.CreateDirectory(USER_DATA); }

			ShakyCollisionsCategory = MelonPreferences.CreateCategory("ShakyCollisions", "Settings");
			ShakyCollisionsCategory.SetFilePath(Path.Combine(USER_DATA, CONFIG_FILE));

            PrefEnabled = ShakyCollisionsCategory.CreateEntry("Enabled", true, "Enabled", "Toggles the Mod On/Off");
            PrefShakeStrength = ShakyCollisionsCategory.CreateEntry("ShakeStrength", 1.875f, "Shake Strength", "Controls how Shaky the Structures are. 0.375 is the Game's Default", validator: new ValueRange<float>(0, float.MaxValue));
            PrefShakeFrequency = ShakyCollisionsCategory.CreateEntry("ShakeFrequency", 150f, "Shake Frequency", "Controls how often it Shakes the Structures. 75 is the Game's Default", validator: new ValueRange<float>(0, float.MaxValue));
            StoreLastSavedPrefs();
		}

		internal static void StoreLastSavedPrefs()
		{
			List<MelonPreferences_Entry> prefs = new List<MelonPreferences_Entry>();
			prefs.AddRange(ShakyCollisionsCategory.Entries);
			foreach (MelonPreferences_Entry entry in  prefs) { LastSavedValues[entry] = entry.BoxedValue; }
		}

		public static bool AnyPrefsChanged()
		{
			foreach (KeyValuePair<MelonPreferences_Entry, object> pair in LastSavedValues)
			{
				if (!pair.Key.BoxedValue.Equals(pair.Value)) { return true; }
			}
			return false;
		}

        /*public static bool IsPrefChanged(MelonPreferences_Entry entry)
		{
			if (LastSavedValues.TryGetValue(entry, out object? lastValue)) { return !entry.BoxedValue.Equals(lastValue); }
			return false;
		}*/
    }
}
using System.Linq;
using System.Collections;
using MelonLoader;
using UIExpansionKit.API;

namespace PleaseReColorMyMenu
{
    public static class ClientPreferences
    {
        public static readonly string entryRed = "red";
        public static readonly string entryGreen = "green";
        public static readonly string entryBlue = "blue";
        public static readonly string entryRemoveMenuBackground = "removeBackground";

        public static float red
        {
            get { return MelonPreferences.GetEntryValue<float>(SettingsCategory, entryRed); }
            set { MelonPreferences.SetEntryValue<float>(SettingsCategory, entryRed, value); }
        }
        public static float green
        {
            get { return MelonPreferences.GetEntryValue<float>(SettingsCategory, entryGreen); }
            set { MelonPreferences.SetEntryValue<float>(SettingsCategory, entryGreen, value); }
        }
        public static float blue
        {
            get { return MelonPreferences.GetEntryValue<float>(SettingsCategory, entryBlue); }
            set { MelonPreferences.SetEntryValue<float>(SettingsCategory, entryBlue, value); }
        }
        public static bool removeMenuBackground
        {
            get { return MelonPreferences.GetEntryValue<bool>(SettingsCategory, entryRemoveMenuBackground); }
            set { MelonPreferences.SetEntryValue<bool>(SettingsCategory, entryRemoveMenuBackground, value); }
        }

        private static readonly string SettingsCategory = "PleaseReColorMyMenu";
        public static void InitPreferences()
        {
            MelonPreferences.CreateCategory(SettingsCategory, "PleaseReColorMyMenu Settings");

            var Red = MelonPreferences.CreateEntry<float>(SettingsCategory, entryRed, 0f, "Red");
            var Green = MelonPreferences.CreateEntry<float>(SettingsCategory, entryGreen, 170f, "Green");
            var Blue = MelonPreferences.CreateEntry<float>(SettingsCategory, entryBlue, 255f, "Blue");
            var RemoveMenuBackground = MelonPreferences.CreateEntry<bool>(SettingsCategory, entryRemoveMenuBackground, true, "Remove Menu Background");

            Red.OnValueChanged += (old_value, new_value) => MenuTweaks.RecolorMenu();
            Green.OnValueChanged += (old_value, new_value) => MenuTweaks.RecolorMenu();
            Blue.OnValueChanged += (old_value, new_value) => MenuTweaks.RecolorMenu();
            RemoveMenuBackground.OnValueChanged += (old_value, new_value) => MenuTweaks.RemoveBackground();
        }
    }
}

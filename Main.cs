using System.Collections;
using MelonLoader;
using System;

namespace PleaseReColorMyMenu
{

    public static class ModInfo
    {
        public const string Name = "PleaseReColorMyMenu";
        public const string Author = "Gamersven";
        public const string Version = "0.1.0";
    }
    internal class PleaseReColorMyMenu : MelonMod
    {
        public override void OnApplicationStart()
        {
            ClientPreferences.InitPreferences();

            MelonCoroutines.Start(StartUiManagerInitIEnumerator());
        }
        private IEnumerator StartUiManagerInitIEnumerator()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
                yield return null;

            MelonCoroutines.Start(VRChat_OnUiManagerInit());
        }

        public IEnumerator VRChat_OnUiManagerInit()
        {
            while (Wrappers.GetWorldInstance() == null || Wrappers.GetWorld() == null)
                yield return null;
            MenuTweaks.RecolorMenu();
            MenuTweaks.RemoveBackground();
        }
        public override void OnPreferencesSaved() // Called when a mod calls MelonLoader.MelonPreferences.Save(), or when the application quits.
        {

        }

    }
}


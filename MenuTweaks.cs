using UnityEngine;
using System.Linq;
using System.Reflection;
using MelonLoader;
using UnityEngine.Rendering.PostProcessing;
using HarmonyLib;
using VRC;
using System.Collections;
using UnityEngine.UI;

namespace PleaseReColorMyMenu
{
    class MenuTweaks
    {
        public static void RemoveBackground()
        {
            try
            {
                bool active = !ClientPreferences.removeMenuBackground;
                GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_Background").SetActive(active);
                GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_Background/Panel").SetActive(active);
                GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_CONTEXT/QM_Context_User_Hover/Panel").SetActive(active);
                GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_CONTEXT/QM_Context_ToolTip/Panel").SetActive(active);
                GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_CONTEXT/QM_Context_Invite/Panel").SetActive(active);
                GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/Panel").SetActive(active);
                GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/Panel").SetActive(active);
            }
            catch { }
        }

        public static void RecolorMenu()
        {
            float red = ClientPreferences.red / 255;
            float green = ClientPreferences.green / 255;
            float blue = ClientPreferences.blue / 255;
            GameObject quickMenu = GameObject.Find("/UserInterface/QuickMenu");
            GameObject bigMenu = GameObject.Find("/UserInterface/MenuContent");

            for (int i = 0; i < quickMenu.transform.childCount; i++)
            {
                Transform menu = quickMenu.transform.GetChild(i);

                if (menu.name.Contains("ExpandoRoot")) //UIX
                {
                    //MelonLogger.Msg("Ignoring: " + menu.name);
                    foreach (Image Image in menu.gameObject.GetComponentsInChildren<Image>(true))
                    {
                        Image.color = ImageColor(red, green, blue, 1f, 0.25f);
                    }
                }
                else if (menu.name.Contains("ScreenshotManagerUI(Clone)")) { }
                else
                {
                    //MelonLogger.Msg("Coloring: " + menu.name);
                    try
                    {
                        //var x = menu.gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true);//.TryCast<Component[]>();
                        foreach (Image Image in menu.gameObject.GetComponentsInChildren<Image>(true))
                        {
                            if (Wrappers.GetFullName(Image.transform.gameObject).Contains("ViewPort")) { } //Invites
                            else if (Image.transform.gameObject.name.Contains("Panel") && Image.transform.parent.gameObject.name.Contains("Avatar")) //QuickMenu User Display
                            {
                                //MelonLogger.Msg("NOT Coloring: " + Wrappers.UnityExtensions.GetFullName(Image.transform.gameObject));
                            }
                            else if (Image.transform.gameObject.name.Contains("PlayerListMod(Clone)")) //PlayerListMod
                            {
                                //MelonLogger.Msg("NOT Coloring: " + Wrappers.UnityExtensions.GetFullName(Image.transform.gameObject));
                            }
                            else if (Image.transform.gameObject.name == "ON" || Image.transform.gameObject.name == "OFF")
                            {
                                Image.color = ImageColor(red, green, blue, 1f, 0.25f);
                            }
                            else if (Wrappers.GetFullName(Image.transform.gameObject).Contains("StreamerModeEnabled"))
                            {
                                //MelonLogger.Msg("Coloring: " + Wrappers.UnityExtensions.GetFullName(Image.transform.gameObject));
                                Image.color = ImageColor(red, green, blue, 1f, 0.25f);
                            }
                            else
                            {
                                Image.color = ImageColor(red, green, blue);
                            }

                        }

                        foreach (Button Button in menu.gameObject.GetComponentsInChildren<Button>(true))
                        {
                            if (!(Button.colors.normalColor == new Color(1, 1, 1, 1)))
                            {
                                Button.colors = ButtonColor(red, green, blue);
                            }
                            else
                            {
                                Button.gameObject.GetComponentInChildren<Image>(true).color = new Color(1, 1, 1, 1);
                            }
                        }
                    }
                    catch { }
                }
            }
            for (int i = 0; i < bigMenu.transform.childCount; i++)
            {
                Transform menu = bigMenu.transform.GetChild(i);
                if (menu.name.Contains("Expando")) //UIX
                {
                    foreach (Button Button in menu.gameObject.GetComponentsInChildren<Button>(true))
                    {
                        Button.colors = ButtonColor(red, green, blue);
                        //MelonLogger.Msg("Ignoring: " + menu.name);
                    }
                    foreach (Image Image in menu.gameObject.GetComponentsInChildren<Image>(true))
                    {
                        if (Image.transform.name.Contains("Checkmark"))
                        {
                        }
                        else
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 2.2f);
                        }
                    }
                }
                else
                {
                    foreach (Button Button in menu.gameObject.GetComponentsInChildren<Button>(true))
                    {
                        Button.colors = ButtonColor(red, green, blue);
                        //MelonLogger.Msg("Ignoring: " + menu.name);
                    }
                    foreach (Image Image in menu.gameObject.GetComponentsInChildren<Image>(true))
                    {
                        if (Image.transform.name.Contains("Background")) // General Background
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 2.2f);
                        }
                        else if (Image.transform.name.Contains("Panel_Header")) // Settings Groups
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 1.5f);
                        }
                        else if (Image.transform.name.Contains("Volume")) // Settings Volume Slider Background
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 3f, 0.5f);
                        }
                        else if (Image.transform.name == "Panel" && !Image.transform.gameObject.GetFullName().Contains("RoomImage")) // PopUp Header without World Icon Panel Recolor
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 2f);
                        }
                        else if (Image.transform.name.Contains("Rectangle")) // PopUp Background
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 3f);
                        }
                        else if (Image.transform.name.Contains("InputField")) // Seach Inpot Field
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 1.5f);
                        }
                        else if (Image.transform.name.Contains("Fill")) // Slider
                        {
                            Image.color = ImageColor(red, green, blue);
                        }
                        else if (Image.transform.name.Contains("SafetyLevel")) // Safety Title
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 1.5f);
                        }
                        else if (Image.transform.name == "ON" && Image.transform.gameObject.GetFullName().Contains("SafetyLevel")) // Safety Button Active
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 2.5f);
                        }
                        else if (Image.transform.name.Contains("BorderImage")) // Performace Settings
                        {
                            Image.color = ImageColor(red, green, blue, 1f / 3f);
                        }
                    }
                }
            }

            foreach (PedalGraphic pedalGraphic in Resources.FindObjectsOfTypeAll<PedalGraphic>())
            {
                if (pedalGraphic.transform.name == "Center")
                    pedalGraphic.transform.gameObject.SetActive(false);
                else if (pedalGraphic.transform.gameObject.GetFullName().Contains("OneHandMoveMenu"))
                    pedalGraphic.color = ImageColor(red, green, blue, 1f / 3f);
                else
                    pedalGraphic.color = ImageColor(red, green, blue);
            }
        }

        public static Color ImageColor(float red, float green, float blue, float brightnessmod = 1f, float alpha = 1f)
        {
            Color color = new Color(red, green, blue);
            if (brightnessmod != 1f)
            {
                Color.RGBToHSV(color, out var H, out var S, out var V);
                V *= brightnessmod;
                color = Color.HSVToRGB(H, S, V);
            }
            color.a = alpha;
            //MelonLogger.Msg(color.ToString());
            return color;
        }

        public static ColorBlock ButtonColor(float red, float green, float blue, float brightnessmod = 1f, float alpha = 1f)
        {
            Color color = ImageColor(red, green, blue, alpha, brightnessmod);
            ColorBlock colorBlock = new ColorBlock()
            {
                colorMultiplier = 1f,
                disabledColor = Color.grey,
                highlightedColor = color,
                normalColor = color / 1.2f,
                pressedColor = Color.grey * 1.5f,
                selectedColor = color * 1.2f
            };
            return colorBlock;
        }
    }
}
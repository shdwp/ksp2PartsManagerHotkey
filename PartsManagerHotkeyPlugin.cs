using BepInEx;
using HarmonyLib;
using KSP.Game;
using UnityEngine;

namespace PartsManagerHotkey;

[BepInPlugin("PartsManagerHotkeyPlugin", "Parts Manager Hotkey", "1.0")]
public class PartsManagerHotkeyPlugin : BaseUnityPlugin
{
    public static PartsManagerHotkeyPlugin Instance;

    private Settings _settings;

    private void Awake()
    {
        Instance = this;

        _settings = Settings.Load();
        var harmony = new Harmony("partsmanagerhotkeypatches");
        harmony.PatchAll();
    }

    private void Update()
    {
        if (_settings.KeyCodeToggle != default && Input.GetKeyDown(_settings.KeyCodeToggle))
        {
            GameManager.Instance.Game.PartsManager.IsVisible = !GameManager.Instance.Game.PartsManager.IsVisible;
        }
    }

    public bool IsMouseHotkeyDown()
    {
        return _settings.KeyCodeToggle == default || Input.GetKey(_settings.KeyCodeMouse);
    }
}
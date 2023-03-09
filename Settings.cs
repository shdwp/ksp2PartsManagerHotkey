using System.Reflection;
using UnityEngine;

namespace PartsManagerHotkey
{
    public class Settings
    {
        public string MouseClickHotkey;
        public string ToggleHotkey;

        public KeyCode KeyCodeMouse;
        public KeyCode KeyCodeToggle;

        public static Settings Load()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Settings.json");
            var contents = File.ReadAllText(path);
            var settings = JsonUtility.FromJson<Settings>(contents);

            if (settings.MouseClickHotkey != null)
            {
                Enum.TryParse<KeyCode>(settings.MouseClickHotkey, out settings.KeyCodeMouse);
            }
            
            if (settings.ToggleHotkey != null)
            {
                Enum.TryParse<KeyCode>(settings.ToggleHotkey, out settings.KeyCodeToggle);
            }

            return settings;
        }
    }
}
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;

public class Settings
{
    public uint clipboardTimeSeconds { get; set; }
    public uint inactivityTimeSeconds { get; set; }
    public string masterKey { get; set; }

    public Settings() { }

    public Settings(uint clipboardTimeSeconds, uint inactivityTimeSeconds, string masterKey)
    {
        if (masterKey.Length != 8)
            throw new ArgumentException("Invalid master key length");
        if (clipboardTimeSeconds < 0)
            throw new ArgumentException("Clipboard Time can't be negative");
        if (inactivityTimeSeconds < 10)
            throw new ArgumentException("Inactivity Time should be greater than 10");

        this.clipboardTimeSeconds = clipboardTimeSeconds;
        this.inactivityTimeSeconds = inactivityTimeSeconds;
        this.masterKey = masterKey;

        string json = this.ToString();
        File.WriteAllText("settings.json", json);
    }

    public void ReadSettings()
    {
        try
        {
            // Reads file and assigns the settings to this
            using (StreamReader r = new StreamReader("settings.json"))
            {
                string json = r.ReadToEnd();
                var settings = JsonSerializer.Deserialize<Settings>(json);

                if (settings.masterKey.Length != 8)
                    throw new ArgumentException("Invalid master key length");
                if (settings.clipboardTimeSeconds < 0)
                    throw new ArgumentException("Clipboard Time can't be negative");
                if (settings.inactivityTimeSeconds < 10)
                    throw new ArgumentException("Inactivity Time should be greater than 10");

                this.clipboardTimeSeconds = settings.clipboardTimeSeconds;
                this.inactivityTimeSeconds = settings.inactivityTimeSeconds;
                this.masterKey = settings.masterKey;
            }
        }
        catch
        {
            // Create a file with the default values
            clipboardTimeSeconds = 30;
            inactivityTimeSeconds = 60;
            masterKey = "B4d5Eñf0";

            string json = this.ToString();
            File.WriteAllText("settings.json", json);
        }
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
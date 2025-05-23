﻿using BepInEx.Configuration;
using DiFFoZTweaks.Patcher.Configuration.Configs;

namespace DiFFoZTweaks.Patcher.Configuration;
public partial class ConfigManager
{
    private readonly ConfigFile m_ConfigFile;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public ConfigManager(ConfigFile configFile)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        m_ConfigFile = configFile;

        Initialize();
    }

    public ConfigEntry<bool> FlashTaskbar { get; private set; }

    public MoreCompanyConfig MoreCompany { get; private set; }

    public BepInExConfig BepInExConfig { get; private set; }

    private void Initialize()
    {
        FlashTaskbar = m_ConfigFile.Bind("Utilities", "Flash taskbar after load", true,
            "Flash taskbar app when game loaded and waiting user input");

        MoreCompany = new(m_ConfigFile);
        BepInExConfig = new(m_ConfigFile);
    }
}

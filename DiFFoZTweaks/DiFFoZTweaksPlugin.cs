﻿using BepInEx;
using BepInEx.Logging;
using DiFFoZTweaks.Patcher;
using DiFFoZTweaks.Patcher.Configuration;
using HarmonyLib;

namespace DiFFoZTweaks;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(Dependencies.MoreCompany, BepInDependency.DependencyFlags.SoftDependency)]
public class DiFFoZTweaksPlugin : BaseUnityPlugin
{
    public static DiFFoZTweaksPlugin Instance { get; private set; } = null!;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private DiFFoZTweaksPlugin() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public new ConfigManager Config { get; private set; }
    public new ManualLogSource Logger { get; private set; }

    private Harmony m_Harmony;

    internal void Awake()
    {
        Instance = this;
        Config = DiFFoZTweaksPatcher.Instance.Config;
        Logger = base.Logger;

        m_Harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        m_Harmony.PatchAll(typeof(DiFFoZTweaksPlugin).Assembly);
    }
}

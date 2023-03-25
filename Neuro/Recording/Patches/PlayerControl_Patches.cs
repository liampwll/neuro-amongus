﻿using HarmonyLib;

namespace Neuro.Recording.Patches;

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CmdCheckMurder))]
public static class PlayerControl_CmdCheckMurder_Patch
{
    [HarmonyPostfix]
    public static void Postfix()
    {
        // Info("CmdCheckMurder");
        NeuroPlugin.Instance.RecordingHandler.DidKill = true;
    }
}

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CmdReportDeadBody))]
public static class PlayerControl_CmdReportDeadBody_Patch
{
    [HarmonyPostfix]
    public static void Postfix()
    {
        // Info("CmdReportDeadBody");
        NeuroPlugin.Instance.RecordingHandler.DidReport = true;
    }
}

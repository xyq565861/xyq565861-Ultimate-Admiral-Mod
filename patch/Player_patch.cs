using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ultimateModify
{
    [HarmonyPatch(typeof(Player), "IsHullObsolete")]
    public class Player_IsHullObsolete_patch
    {
        public static bool Prefix(ref bool __result,Player __instance)
        {
            if (modifyPlugin.playerHullObsolete.Value && __instance.isMain)
            {
                __result = false;
                return false;
            }

            return true;
        }
    }
    [HarmonyPatch(typeof(Player), "IsPartUnlocked")]
    public class Player_IsPartUnlocked_patch
    {
        public static bool Prefix(ref bool __result, Player __instance)
        {
            if (modifyPlugin.playerPartUnkocked.Value && __instance.isMain)
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
    [HarmonyPatch(typeof(Player), "IsHullUnlocked")]
    public class Player_IsHullUnlocked_patch
    {
        public static bool Prefix(ref bool __result, Player __instance)
        {
            if (modifyPlugin.playerHullUnkocked.Value&& __instance.isMain)
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
    [HarmonyPatch(typeof(Player), "GetShipBuildRatio")]
    public class Player_GetShipBuildRatio_patch
    {
        public static void Postfix(ref float __result, Player __instance)
        {
            if (__instance.isMain)
            {
                __result = __result * modifyPlugin.playerShipBuildRatio.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Player), "Income")]
    public class Player_Income_patch
    {
        public static void Postfix(ref float __result, Player __instance)
        {
            if (__instance.isMain)
            {
                __result = __result * modifyPlugin.playerIncome.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Player), "CrewPoolIncome")]
    public class Player_CrewPoolIncome_patch
    {
        public static void Postfix(ref int __result, Player __instance)
        {
            if (__instance.isMain)
            {
                __result =(int)( __result *modifyPlugin.playerCrewPoolIncome.Value);

            }

        }
    }
    
}

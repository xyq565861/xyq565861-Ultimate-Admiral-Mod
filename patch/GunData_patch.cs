using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
namespace ultimateModify
{
    [HarmonyPatch(typeof(GunData), "HitChanceMult")]
    public class GunData_HitChanceMult_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                __result = __result * modifyPlugin.playerGunHitChance.Value;

            }
        }
    }
    [HarmonyPatch(typeof(GunData), "Range")]
    public class GunData_Range_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                __result = __result * modifyPlugin.playerGunRange.Value;

            }




        }
    }
    [HarmonyPatch(typeof(GunData), "DamageMod")]
    public class GunData_DamageMod_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                __result = __result * modifyPlugin.playerDamageMod.Value;

            }




        }
    }
    [HarmonyPatch(typeof(GunData), "Penetration")]
    public class GunData_Penetration_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                __result = __result * modifyPlugin.playerPenetration.Value;

            }




        }
    }
    [HarmonyPatch(typeof(GunData), "ShellSize")]
    public class GunData_ShellSize_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                __result = __result * modifyPlugin.playerShellSize.Value;

            }




        }
    }
    [HarmonyPatch(typeof(GunData), "ShellVelocity")]
    public class GunData_ShellVelocity_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                __result = __result * modifyPlugin.playerShellVelocity.Value;

            }




        }
    }
    [HarmonyPatch(typeof(GunData), "ShellWeight")]
    public class GunData_ShellWeight_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                __result = __result * modifyPlugin.playerShellWeight.Value;

            }




        }
    }
    [HarmonyPatch(typeof(GunData), "Firerate")]
    public class GunData_Firerate_patch
    {
        public static void Postfix(ref float __result, Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                // modifyPlugin.log.LogMessage("FIRE RATE:" + __result);
                __result = __result * modifyPlugin.playerGunFireRate.Value;

            }



        }

    }
}

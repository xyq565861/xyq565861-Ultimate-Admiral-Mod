using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
namespace ultimateModify
{
    [HarmonyPatch(typeof(Ship), "Cost")]
    public class Ship_Cost_patch
    {
        public static void  Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result*modifyPlugin.playerShipCost.Value;
              
            }

        }
    }
    [HarmonyPatch(typeof(Ship), "IsPartAvailable", new Type[] { typeof(PartData), typeof(Player), typeof(ShipType), typeof(Ship) })]
    public class Ship_IsPartAvailable_patch
    {


        public static void Postfix(ref bool __result, Ship __instance, PartData part, Player player, ShipType shipType, Ship ship)
        {


            if (modifyPlugin.playerShipPartAvailable.Value && player != null && player.isMain&& !__result&&!part.name.Contains("gun_18_x1"))
            {
               // modifyPlugin.log.LogMessage(string.Format("result{0}part{1}", __result, part.name));
                __result = true;
            }

        }
    }
    [HarmonyPatch(typeof(Ship), "IsPartAvailableBasic")]
    public class Ship_IsPartAvailableBasic_patch
    {

        public static void Postfix(ref bool __result, Ship __instance, PartData part, Player player, [System.Runtime.InteropServices.Optional] Ship shipHint)
        {


            if (modifyPlugin.playerShipPartBaseAvailable.Value && player != null && player.isMain && !__result && !part.name.Contains("gun_18_x1"))
            {
                //modifyPlugin.log.LogMessage(string.Format("result:{0} part:{1}", __result, part.name));
                __result = true;
            }

        }
    }
    [HarmonyPatch(typeof(Ship), "IsComponentAvailable", new Type[] { typeof(ComponentData) })]
    public class Ship_IsComponentAvailable_patch
    {
        public static bool Prefix(ref bool __result, Ship __instance)
        {

            if (modifyPlugin.playerShipComponentAvailable.Value&&__instance.player != null && __instance.player.isMain)
            {
                __result = true;
                return false;
            }


            return true;
        }

    }
    [HarmonyPatch(typeof(Ship), "IsComponentTypeAvailable")]
    public class Ship_IsComponentTypeAvailable_patch
    {
        public static bool Prefix(ref bool __result, Ship __instance)
        {

            if (modifyPlugin.playerShipComponentTypeAvailable.Value&&__instance.player != null && __instance.player.isMain)
            {
                __result = true;
                return false;
            }


            return true;
        }
    }
    [HarmonyPatch(typeof(Ship), "ShipHaveSmoke")]
    public class Ship_ShipHaveSmoke_patch
    {
        public static bool Prefix(ref bool __result, Ship __instance)
        {

            if (modifyPlugin.playerShipHasSmoke.Value&&__instance.player != null && __instance.player.isMain)
            {
                __result = true;
                return false;
            }


            return true;
        }
    }
    [HarmonyPatch(typeof(Ship), "CanLaunchSmokeScreen")]
    public class Ship_CanLaunchSmokeScreen_patch
    {
        public static bool Prefix(ref bool __result, Ship __instance)
        {

            if (modifyPlugin.playerShipHasSmoke.Value && __instance.player != null && __instance.player.isMain)
            {
                __result = true;
                return false;
            }


            return true;
        }
    }
    [HarmonyPatch(typeof(Ship), "IsVisibleFor", new Type[] { typeof(Ship) })]
    public class Ship_IsVisibleFor_patchA
    {
        public static bool Prefix(ref bool __result, Ship __instance, Ship ship)
        {

            if (modifyPlugin.playerShipAlwaysVisible.Value && ship.player != null && ship.player.isMain)
            {
                __result = true;
                return false;
            }


            return true;
        }
    }
    [HarmonyPatch(typeof(Ship), "IsVisibleFor", new Type[] { typeof(Player) })]
    public class Ship_IsVisibleFor_patchB
    {
        public static bool Prefix(ref bool __result, Ship __instance, Player forPlayer)
        {

            if (modifyPlugin.playerShipAlwaysVisible.Value && forPlayer != null && forPlayer.isMain)
            {
                __result = true;
                return false;
            }


            return true;
        }
    }
    [HarmonyPatch(typeof(Ship), "GetEffectiveArmor")]
    public class Ship_GetEffectiveArmor_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            modifyPlugin.log.LogMessage(modifyPlugin.playerShipNeverPenetrated.Value);
            modifyPlugin.log.LogMessage(__instance.name);
            if (modifyPlugin.playerShipNeverPenetrated.Value && __instance.player != null && __instance.player.isMain)
            {
                __result =9999f;
            }
            modifyPlugin.log.LogMessage(__instance.name);

        }
    }

    [HarmonyPatch(typeof(Ship), "TorpedoSpeed")]
    public class Ship_TorpedoSpeed_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipTorpedoSpeed.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "ModifySpeedTorpedo")]
    public class Ship_ModifySpeedTorpedo_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipTorpedoSpeed.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "Acceleration")]
    public class Ship_Acceleration_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipAcceleration.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "SpeedModifier")]
    public class Ship_SpeedModifier_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipSpeed.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "SpeedMax")]
    public class Ship_SpeedMax_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipSpeed.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "GetShipTurningRadius")]
    public class Ship_GetShipTurningRadius_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipTurningRadius.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "GetVisibilityRange")]
    public class Ship_GetVisibilityRange_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipGetVisibilityRange.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "GetSpottingRange")]
    public class Ship_GetSpottingRange_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipGetSpottingRange.Value;

            }

        }
    }

    [HarmonyPatch(typeof(Ship), "GetTorpedoDetectionRange")]
    public class Ship_GetTorpedoDetectionRange_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipGetTorpedoDetectionRange.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "Weight")]
    public class Ship_Weight_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipWeight.Value;

            }

        }
    }
    [HarmonyPatch(typeof(Ship), "PartWeight")]
    public class Ship_PartWeight_patch
    {
        public static void Postfix(Ship __instance, ref float __result)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                __result = __result * modifyPlugin.playerShipWeight.Value;

            }

        }
    }
    
   [HarmonyPatch(typeof(Ship), "TechGunGrade")]
    public class Ship_TechGunGrade_patch
    {
        public static void Postfix(Ship  __instance, ref int __result, PartData gun)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
                // modifyPlugin.log.LogMessage(string.Format("result-{0} gun-{1}",__result,gun.name));

                if (__result < 0)
                {
                    __result = 0;
                }


            }
            //modifyPlugin.log.LogMessage(string.Format("result{0}gun{1}",__result,gun.nameUi));

        }
    }
    [HarmonyPatch(typeof(Ship), "TechTorpedoGrade")]
    public class Ship_TechTorpedoGrade_patch
    {
        public static void Postfix(Ship __instance, ref int __result, PartData torpedo)
        {
            if (__instance.player != null && __instance.player.isMain)
            {
               // modifyPlugin.log.LogMessage(string.Format("result-{0} torpedo-{1}", __result, torpedo.name));

                if (__result <0)
                {
                    __result = 0;
                }


            }
        }
    }
}

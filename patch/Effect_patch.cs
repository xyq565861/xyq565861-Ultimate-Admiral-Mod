using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ultimateModify
{
    [HarmonyPatch(typeof(Effect), "Hit")]
    public class Effect_Hit_patch
    {
        public static bool Pretfix( Ship ship)
        {

            if (ship != null && ship.player != null && ship.player.isMain)
            {
                
                return false;
            }
            return true;
        }
        

    }
}

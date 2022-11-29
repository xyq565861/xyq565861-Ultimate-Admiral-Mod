using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Reflection;
using UnhollowerRuntimeLib;

namespace ultimateModify
{
    [BepInPlugin("com.mod.UltimateAdmiral.FD", "FdMagicBox", "0.0.2")]
    public class modifyPlugin : BasePlugin
    {
        public static BepInEx.Logging.ManualLogSource log;

        public modifyPlugin()
        {
            log = Log;
        }
        public override void Load()
        {
            // Plugin startup logic


            Log.LogMessage("FdMagicBox registering component in Il2Cpp");

            //try
            //{
            //    // Register our custom Types in Il2Cpp
            //    ClassInjector.RegisterTypeInIl2Cpp<TrainerComponent>();

            //    var go = new GameObject("TrainerObject");
            //    go.AddComponent<TrainerComponent>();
            //    Object.DontDestroyOnLoad(go);
            //}
            //catch
            //{
            //    log.LogError("[Trainer] FAILED to Register Il2Cpp Type: TrainerComponent!");
            //}

            try
            {

                playerGunRange = Config.Bind<float>("Gun", "playerGunRange", 1, "玩家炮台射程倍率，默认值1为100%");
                playerGunHitChance = Config.Bind<float>("Gun", "playerGunHitChance", 1, "玩家炮台命中倍率，默认值1为100%");
                playerDamageMod = Config.Bind<float>("Gun", "playerDamageMod", 1, "玩家炮台伤害倍率，默认值1为100%");
                playerPenetration = Config.Bind<float>("Gun", "playerPenetration", 1, "玩家炮台穿透倍率，默认值1为100%");
                playerShellSize = Config.Bind<float>("Gun", "playerShellSize", 1, "玩家炮台炮弹尺寸倍率，默认值1为100%");
                playerShellVelocity = Config.Bind<float>("Gun", "playerShellVelocity", 1, "玩家炮台炮弹速度倍率，默认值1为100%");
                playerShellWeight = Config.Bind<float>("Gun", "playerShellWeight", 1, "玩家炮台炮弹重量倍率，默认值1为100%");
                playerGunFireRate = Config.Bind<float>("Gun", "playerGunFireRate", 1, "玩家炮台射速倍率，默认值1为100%");



                playerHullObsolete = Config.Bind<bool>("Player", "playerHullObsolete", false, "船体不过时");
                playerPartUnkocked = Config.Bind<bool>("Player", "playerPartUnkocked", false, "为玩家解锁所有船体部件");
                playerHullUnkocked = Config.Bind<bool>("Player", "playerHullUnkocked", false, "为玩家解锁所有船体");
                playerShipBuildRatio = Config.Bind<float>("Player", "playerShipBuildRatio", 1, "玩家船只建造倍率");
                playerIncome = Config.Bind<float>("Player", "playerIncome", 1, "玩家收入倍率");
                playerCrewPoolIncome = Config.Bind<float>("Player", "playerCrewPoolIncome", 1, "玩家船员池增加倍率");

                playerShipPartBaseAvailable = Config.Bind<bool>("Ship", "playerShipPartBaseAvailable", false, "测试：玩家船只部件忽略船只类型，极不稳定，部分船体由于缺少炮位会直接让游戏卡死，同时解锁全部部件会让捏船界面很卡，同时自动捏船由于多了许多选择会更卡");
                playerShipPartAvailable = Config.Bind<bool>("Ship", "playerShipPartAvailable", false, "测试：设计模式中为玩家解锁所有类型匹配的船体部件，极不稳定，部分船体由于缺少炮位会直接让游戏卡死，同时解锁全部部件会让捏船界面很卡，同时自动捏船由于多了许多选择会更卡");
                playerShipComponentTypeAvailable = Config.Bind<bool>("Ship", "playerShipComponentTypeAvailable", false, "测试：玩家船只插件忽略船只类型，极不稳定，部分船体由于缺少炮位会直接让游戏卡死，同时解锁全部部件会让捏船界面很卡，同时自动捏船由于多了许多选择会更卡");

                playerShipComponentAvailable = Config.Bind<bool>("Ship", "playerShipComponentAvailable", false, "测试：设计模式中为玩家解锁所有类型匹配的船体插件，极不稳定，部分船体由于缺少炮位会直接让游戏卡死，同时解锁全部部件会让捏船界面很卡，同时自动捏船由于多了许多选择会更卡");
                playerShipHasSmoke = Config.Bind<bool>("Ship", "playerShipHasSmoke", false, "测试：为玩家所有船体解锁发烟器");
                playerShipAlwaysVisible = Config.Bind<bool>("Ship", "playerShipAlwaysVisible", false, "测试：玩家侦测距离无限，但是会造成敌方船只模型丢失，用于整活");
                playerShipNeverPenetrated = Config.Bind<bool>("Ship", "playerShipNeverPenetrated", false, "(暂时失效)玩家船只无法被击中");


                playerShipTorpedoSpeed = Config.Bind<float>("Ship", "playerShipTorpedoSpeed", 1, "玩家船只鱼雷速度倍率");
                playerShipCost = Config.Bind<float>("Ship", "playerShipCost", 1, "玩家船只造价倍率,注意由于电脑在帮你捏船时总会想办法把预算花光,过低的造价会造成自动捏船故障");
                playerShipSpeed = Config.Bind<float>("Ship", "playerShipSpeed", 1, "玩家船只速度倍率");
                playerShipAcceleration = Config.Bind<float>("Ship", "playerShipAcceleration", 1, "玩家船只加速度倍率");

                playerShipTurningRadius = Config.Bind<float>("Ship", "playerShipTurningRadius", 1, "玩家船只转弯半径倍率");
                playerShipWeight = Config.Bind<float>("Ship", "playerShipWeight", 1, "测试：玩家船只重量倍率,注意由于电脑在帮你捏船时总会想办法把预算花光,过低的重量会造成自动捏船故障");
                playerShipGetVisibilityRange = Config.Bind<float>("Ship", "playerShipGetVisibilityRange", 1, "测试：玩家船只可见距离倍率");
                playerShipGetSpottingRange = Config.Bind<float>("Ship", "playerShipGetSpottingRange", 1, "测试：玩家船只发现距离倍率");
                playerShipGetTorpedoDetectionRange = Config.Bind<float>("Ship", "playerShipGetTorpedoDetectionRange", 1, "测试：玩家船只鱼雷发现距离倍率");




                var harmony = new Harmony("FdMagicBox.il2cpp");

               // harmony.PatchAll(typeof(Effect_Hit_patch));


                harmony.PatchAll(typeof(GunData_HitChanceMult_patch));
                harmony.PatchAll(typeof(GunData_Range_patch));
                harmony.PatchAll(typeof(GunData_DamageMod_patch));
                harmony.PatchAll(typeof(GunData_Penetration_patch));
                harmony.PatchAll(typeof(GunData_ShellSize_patch));
                harmony.PatchAll(typeof(GunData_ShellVelocity_patch));
                harmony.PatchAll(typeof(GunData_ShellWeight_patch));
                harmony.PatchAll(typeof(GunData_Firerate_patch));


                harmony.PatchAll(typeof(Player_IsHullObsolete_patch));
                harmony.PatchAll(typeof(Player_IsHullUnlocked_patch));
                harmony.PatchAll(typeof(Player_IsPartUnlocked_patch));
                harmony.PatchAll(typeof(Player_GetShipBuildRatio_patch));
                harmony.PatchAll(typeof(Player_Income_patch));
                harmony.PatchAll(typeof(Player_CrewPoolIncome_patch));


                harmony.PatchAll(typeof(Ship_Cost_patch));
                harmony.PatchAll(typeof(Ship_IsPartAvailable_patch));
                harmony.PatchAll(typeof(Ship_IsPartAvailableBasic_patch));

                harmony.PatchAll(typeof(Ship_IsComponentAvailable_patch));
                harmony.PatchAll(typeof(Ship_IsComponentTypeAvailable_patch));
                harmony.PatchAll(typeof(Ship_CanLaunchSmokeScreen_patch));
                harmony.PatchAll(typeof(Ship_ShipHaveSmoke_patch));
                harmony.PatchAll(typeof(Ship_IsVisibleFor_patchA));
                harmony.PatchAll(typeof(Ship_IsVisibleFor_patchB));
                harmony.PatchAll(typeof(Ship_GetEffectiveArmor_patch));

                harmony.PatchAll(typeof(Ship_TorpedoSpeed_patch));
                harmony.PatchAll(typeof(Ship_ModifySpeedTorpedo_patch));
                harmony.PatchAll(typeof(Ship_Acceleration_patch));
                harmony.PatchAll(typeof(Ship_SpeedModifier_patch));
                harmony.PatchAll(typeof(Ship_SpeedMax_patch));

                harmony.PatchAll(typeof(Ship_GetShipTurningRadius_patch));
                harmony.PatchAll(typeof(Ship_GetVisibilityRange_patch));
                harmony.PatchAll(typeof(Ship_GetSpottingRange_patch));
                harmony.PatchAll(typeof(Ship_GetTorpedoDetectionRange_patch));

                harmony.PatchAll(typeof(Ship_Weight_patch));
                harmony.PatchAll(typeof(Ship_PartWeight_patch));
                //harmony.PatchAll(typeof(Ship_TechGunGrade_patch));
                //harmony.PatchAll(typeof(Ship_TechTorpedoGrade_patch));


            }
            catch( Exception ex)
            {

                Log.LogError("FdMagicBox Harmony - FAILED to Apply Patch's!");
                Log.LogError(ex.Message+ex.StackTrace);
            }
        }



        public static ConfigEntry<float>  playerGunRange;
        public static ConfigEntry<float> playerGunHitChance;
        public static ConfigEntry<float> playerDamageMod;
        public static ConfigEntry<float> playerPenetration;
        public static ConfigEntry<float> playerShellSize;
        public static ConfigEntry<float> playerShellVelocity;
        public static ConfigEntry<float> playerShellWeight;
        public static ConfigEntry<float>  playerGunFireRate;

        public static ConfigEntry<bool> playerHullObsolete;
        public static ConfigEntry<bool> playerPartUnkocked;
        public static ConfigEntry<bool> playerHullUnkocked;
        public static ConfigEntry<float> playerShipBuildRatio;
        public static ConfigEntry<float> playerIncome;
        public static ConfigEntry<float> playerCrewPoolIncome;


        public static ConfigEntry<bool> playerShipPartBaseAvailable;
        public static ConfigEntry<bool> playerShipPartAvailable;
        public static ConfigEntry<bool> playerShipComponentAvailable;

        public static ConfigEntry<bool> playerShipComponentTypeAvailable;
        public static ConfigEntry<bool> playerShipHasSmoke;
        public static ConfigEntry<bool> playerShipAlwaysVisible;
        public static ConfigEntry<bool> playerShipNeverPenetrated;
        public static ConfigEntry<float> playerShipTorpedoSpeed;

        public static ConfigEntry<float> playerShipCost;
        public static ConfigEntry<float> playerShipSpeed;
        public static ConfigEntry<float> playerShipAcceleration;

        public static ConfigEntry<float> playerShipTurningRadius;
        public static ConfigEntry<float> playerShipWeight;
        public static ConfigEntry<float> playerShipGetVisibilityRange;
        public static ConfigEntry<float> playerShipGetSpottingRange;
        public static ConfigEntry<float> playerShipGetTorpedoDetectionRange;



    }


}
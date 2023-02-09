using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DialogUtil
{
    public static class DialogName{

        public static readonly string SHOPDIALOGNAME="ショップ";
        public static readonly string ITEMSDIALOGNAME="持ち物";
        public static readonly string MISSONDIALOGNAME="ミッション";
        public static readonly string SETTINGDIALOGNAME="設定";
        public static readonly string HELPDIALOGNAME="ヘルプ";
    }
    public static class FIlePath{
        private static string BASEPATH="UI/Prefabs/";
        private static string SHOPBASE="Shop/";
        private static string MYITEMBASE="MyItem/";
        private static string MISSIONBASE="Mission/";
        private static string SETTINGBASE="Setting/";


        public static readonly string SHOP_VIEW=BASEPATH+SHOPBASE+"ShopView";
        public static readonly string SHOP_ITEM_BUTTON=BASEPATH+SHOPBASE+"ShopItemButton";
        public static readonly string MYITEM_VIEW=BASEPATH+MYITEMBASE+"MyItemView";
        public static readonly string MYITEM_BUTTON=BASEPATH+MYITEMBASE+"MyItemButton";
        public static readonly string MISSIONVIEW=BASEPATH+MISSIONBASE+"MissionView";
        public static readonly string MISSION=BASEPATH+MISSIONBASE+"Mission";
        public static readonly string SettingView=BASEPATH+SETTINGBASE+"SettingView";
        public static readonly string SETTING=BASEPATH+SETTINGBASE+"Setting";

    }
    public static class PrefabName{
        public static readonly string CONTETNTBACKGROUND="content-background";
        public static readonly string CONTENT="Content";

    }


  
}

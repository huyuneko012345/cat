using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;
using static DialogUtil.DialogName;
using static DialogUtil.PrefabName;
using static DialogUtil.FIlePath;




public class Main : MonoBehaviour
{

    [SerializeField] private Canvas parent;
    [SerializeField] private Dialog dialog;

    private MissionController mission;
    private MyItemController myItemController;

    private FPManager fpManager;
    private const string LAST_LOGIN_KEY = "LastLogin";
    private static string lastLogin = "2023/1/29";
    private static string lastLogin2 = "2023/1/29";
    private static string today;
    void Start()
    {
        this.mission = gameObject.GetComponent<MissionController>();
        this.myItemController = GetComponent<MyItemController>();
        today = DateTimeString(System.DateTime.Now);
        lastLogin = PlayerPrefs.GetString(LAST_LOGIN_KEY, today.ToString());

        this.fpManager = GetComponent<FPManager>();
        this.fpManager.Init();
        if (!isLoginToday())
        {
            this.mission.pickMission();
            mission.ClearValue(5, 1);
        }
    }
    private const string START="start";
    private  const string BACK="back";

    private const string SHOP_BUTTON="shop-button";
    private const string ITEM="item";
    private const string MISSION="mission";
    private const string SETTING="setting";

    private void Awake()
    {
        // 今日ログインしていない場合はスタート画面に戻る用
        if (!isLoginToday())
        {
            SceneManager.LoadScene(START);
        }
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>(BACK).clicked += () => SceneManager.LoadScene(START);

        root.Q<Button>(SHOP_BUTTON).clicked += () =>
        {

            addView(SHOP_VIEW, SHOPDIALOGNAME);
            var content = GameObject.Find(CONTENT);
            CreateShopItem createShopItem = gameObject.GetComponent<CreateShopItem>();
            fpManager.Init(createShopItem.Init());
        };


        root.Q<Button>(ITEM).clicked += () =>
        {

            addView(MYITEM_VIEW, ITEMSDIALOGNAME);
            var content = GameObject.Find(CONTENT);
            content.AddComponent<GridSizeSetter>();

            myItemController.CreateMyItem();




        };

        root.Q<Button>(MISSION).clicked += () =>
        {
            addView(MISSIONVIEW, MISSONDIALOGNAME);
            mission.addMission();



        };

        root.Q<Button>(SETTING).clicked += () =>
        {
            addView(SettingView, SETTINGDIALOGNAME);
            GameObject MissionPrefab = (GameObject)Resources.Load(SETTING);
            GameObject content = GameObject.Find(CONTENT);
            Instantiate(MissionPrefab, content.transform);

        };


    }

    private void addView(string viewPath, string DialogName)
    {
        show(parent, dialog);
        GameObject contentBackGround = GameObject.Find(CONTETNTBACKGROUND);
        GameObject viewPrefab = (GameObject)Resources.Load(viewPath);
        Instantiate(viewPrefab, contentBackGround.transform);
        setDialogName(DialogName);

    }
    private void show(Canvas parent, Dialog dialog)
    {
        var _dialog = Instantiate(dialog);
        _dialog.transform.SetParent(parent.transform, false);
        // _dialog.FixDialog = (res) => Debug.Log(res);
    }
    
    private void setDialogName(string name)
    {
        GameObject nameObj = GameObject.Find(NAME);
        TextMeshProUGUI _text = nameObj.GetComponent<TextMeshProUGUI>();
        _text.text = name;
    }
    private static string DateTimeString(DateTime date)
    {
        return (string.Join("/", date.Year.ToString(), date.Month.ToString(), date.Day.ToString()));
    }
    //最終ログインが今日？
    // 今日:true
    //今日ではない:false
    private static bool isLoginToday()
    {
        today = DateTimeString(System.DateTime.Now);

        if (today == lastLogin)
        {
            return true;
        }
        lastLogin = String.Copy(today);
        PlayerPrefs.SetString(LAST_LOGIN_KEY, lastLogin);
        return false;
    }


}

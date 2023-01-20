using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using ui = UnityEngine.UI;
using TMPro;
using static DialogUtil.DialogName;
using static DialogUtil.PrefabName;
using static DialogUtil.FIlePath;




public class Main : MonoBehaviour
{

    [SerializeField] private Canvas parent;
    [SerializeField] private Dialog dialog;

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("home").clicked += () => Debug.Log("home");

        root.Q<Button>("back").clicked += () => SceneManager.LoadScene("start");

        root.Q<Button>("shop-button").clicked += () =>
        {
            addView(SHOPVIEW, SHOPDIALOGNAME);

            ShopConroller shopConroller = new ShopConroller();
            shopConroller.addItem();
        };


        root.Q<Button>("item").clicked += () =>
        {

            addView(SHOPVIEW, ITEMSDIALOGNAME);

            

        };

        root.Q<Button>("mission").clicked += () =>
        {
            addView(MISSIONVIEW, MISSONDIALOGNAME);
            MissionController mission=new MissionController();
            mission.addMission();
           


        };

        root.Q<Button>("setting").clicked += () =>
        {
            addView(SettingView, SETTINGDIALOGNAME);
            GameObject MissionPrefab = (GameObject)Resources.Load(SETTING);
            GameObject content = GameObject.Find("Content");
            Instantiate(MissionPrefab, content.transform);

        };

        root.Q<Button>("help").clicked += () =>
        {
            Debug.Log("mission");
            show(parent, dialog);
            GameObject contentBackGround = GameObject.Find("content-background");
            setDialogName(HELPDIALOGNAME);
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
        _dialog.FixDialog = (res) => Debug.Log(res);
    }
    private void setDialogName(string name)
    {
        GameObject nameObj = GameObject.Find("Name");
        TextMeshProUGUI _text = nameObj.GetComponent<TextMeshProUGUI>();
        _text.text = name;
    }
}

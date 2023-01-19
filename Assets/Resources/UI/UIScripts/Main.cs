using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using ui = UnityEngine.UI;
using TMPro;
using static DialogUtil.DialogName;
using static DialogUtil.UsingPrefabName;
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
            Debug.Log(SHOPDIALOGNAME);

            show(parent, dialog);
            GameObject contentBackGround = GameObject.Find(CONTETNTBACKGROUND);
            GameObject viewPrefab = (GameObject)Resources.Load(SHOPVIEW);

            Instantiate(viewPrefab, contentBackGround.transform);
            shopConroller shop=new shopConroller();

            setDialogName(SHOPDIALOGNAME);
            GameObject content = GameObject.Find(CONTENT);

            shop.addItem(content);
        };


        root.Q<Button>("item").clicked += () =>
        {

            Debug.Log(ITEMSDIALOGNAME);

            show(parent, dialog);

            GameObject contentBackGround = GameObject.Find("content-background");
            GameObject viewPrefab = (GameObject)Resources.Load("UI/Prefabs/Shop/ShopView");
            GameObject itemButtonPrefab = (GameObject)Resources.Load("UI/Prefabs/Shop/ShopItemButton");

            Instantiate(viewPrefab, contentBackGround.transform);
            GameObject content = GameObject.Find("Content");

            setDialogName(ITEMSDIALOGNAME);

            Instantiate(itemButtonPrefab, content.transform);




        };

        root.Q<Button>("mission").clicked += () =>
        {
            Debug.Log(MISSONDIALOGNAME);
            show(parent, dialog);
            GameObject contentBackGround = GameObject.Find("content-background");
            setDialogName(MISSONDIALOGNAME);

            GameObject viewPrefab = (GameObject)Resources.Load("UI/Prefabs/Mission/MissionView");
            GameObject MissionPrefab = (GameObject)Resources.Load("UI/Prefabs/Mission/Mission");

            Instantiate(viewPrefab, contentBackGround.transform);
            GameObject content = GameObject.Find("Content");
            Instantiate(MissionPrefab, content.transform);


        };

        root.Q<Button>("setting").clicked += () =>
        {
            Debug.Log(SETTINGDIALOGNAME);
            show(parent, dialog);
            GameObject contentBackGround = GameObject.Find("content-background");
            setDialogName(SETTINGDIALOGNAME);
        };

        root.Q<Button>("help").clicked += () =>
        {
            Debug.Log("mission");
            show(parent, dialog);
            GameObject contentBackGround = GameObject.Find("content-background");
            setDialogName(HELPDIALOGNAME);
        };


    }
    public void show(Canvas parent, Dialog dialog)
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

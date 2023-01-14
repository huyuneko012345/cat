using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using ui =UnityEngine.UI;
using TMPro;
using static DialogUtil.DialogName;




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
            Debug.Log(shopDialogName);

            show(parent, dialog);
        
        GameObject contentBackGround=GameObject.Find("content-background");
        GameObject viewPrefab=(GameObject)Resources.Load("UI/Prefabs/ShopView");
        GameObject itemButtonPrefab=(GameObject)Resources.Load("UI/Prefabs/itemButton");

        Instantiate(viewPrefab,contentBackGround.transform);
        GameObject content=GameObject.Find("Content");

        setDialogName(shopDialogName);
        // name.GetComponent<ui.Text>().text="ass";
        Instantiate(itemButtonPrefab,content.transform);
            // root.Add(elem);
            // Debug.Log("asd3");
            // root.RemoveAt(root.childCount-1);     
        };


        root.Q<Button>("item").clicked +=()=>{
            
            Debug.Log(itemsDialogName);

            show(parent, dialog);
         GameObject contentBackGround=GameObject.Find("content-background");
        GameObject viewPrefab=(GameObject)Resources.Load("UI/Prefabs/ShopView");
        GameObject itemButtonPrefab=(GameObject)Resources.Load("UI/Prefabs/itemButton");

        Instantiate(viewPrefab,contentBackGround.transform);
        GameObject content=GameObject.Find("Content");

        setDialogName(itemsDialogName);
        // name.GetComponent<ui.Text>().text="ass";
        Instantiate(itemButtonPrefab,content.transform);
        
        };

        root.Q<Button>("mission").clicked +=()=>{
            Debug.Log(missonDialogName);
            show(parent, dialog);
            GameObject contentBackGround=GameObject.Find("content-background");
            setDialogName(missonDialogName);

        };

        root.Q<Button>("setting").clicked +=()=>{
            Debug.Log(settingDialogName);
            show(parent, dialog);
            GameObject contentBackGround=GameObject.Find("content-background");
            setDialogName(settingDialogName);
        };

        root.Q<Button>("help").clicked +=()=>{
            Debug.Log("mission");
            show(parent, dialog);
            GameObject contentBackGround=GameObject.Find("content-background");
            setDialogName(helpDialogName);
        };


    }
    public void show(Canvas parent,Dialog dialog)
    {
        var _dialog = Instantiate(dialog);
        _dialog.transform.SetParent(parent.transform, false);
        _dialog.FixDialog = (res) => Debug.Log(res);


    }
    private void setDialogName(string name){
        GameObject nameObj=GameObject.Find("Name");
        TextMeshProUGUI _text=nameObj.GetComponent<TextMeshProUGUI>();
        _text.text=name;
    }
}

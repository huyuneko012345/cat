using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;




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
            Debug.Log("shop");

            show(parent, dialog);


            // root.Add(elem);
            // Debug.Log("asd3");
            // root.RemoveAt(root.childCount-1);     
        };


        //  root.Q<Button>("item").clicked +=()=>Debug.Log("item");

        //  root.Q<Button>("cat-list").clicked +=()=>Debug.Log("cat-list");

        //  root.Q<Button>("setting").clicked +=()=>Debug.Log("setting");

        //  root.Q<Button>("help").clicked +=()=>Debug.Log("help");


    }
    public void show(Canvas parent,Dialog dialog)
    {
        var _dialog = Instantiate(dialog);
        _dialog.transform.SetParent(parent.transform, false);
        _dialog.FixDialog = (res) => Debug.Log(res);


    }
}

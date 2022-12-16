using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class sidebarController : MonoBehaviour
{
    private VisualElement sidebar;
    private int _mainPopupIndex=-1;
     private const string POPUP_ANIMATION = "pop_animation-hide";
 void Awake()
 {
    var root=GetComponent<UIDocument>().rootVisualElement;
    root.Q<Button>("btn").clicked+=()=>{
        Debug.Log("メニューボタン押下");
        sidebar=root.Q<VisualElement>("sidebar");
        Vector2 offset=sidebar.layout.position;


        sidebar.experimental.animation.Position(new Vector3(0,0,0),2000);

    };
 }
}

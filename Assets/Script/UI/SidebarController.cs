using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
/*サイドバーの動きを制御するクラス*/
public class SidebarController : MonoBehaviour
{
    private VisualElement sidebar;
    private VisualElement backgroumd;

    private Vector3 pos;
    private bool flg = false;

    private const string BTN="btn";
    private const string SIDEBAR="sidebar";
    private const string GRAYBACKGROUND="gray-background";
    /// <summary>
    ///　サイドバーを左右に動かすクラス
    /// </summary>
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>(BTN).clicked += () =>
        {
            
            sidebar = root.Q<VisualElement>(SIDEBAR);
            Vector2 offset = sidebar.layout.position;
            backgroumd = root.Q<VisualElement>(GRAYBACKGROUND);
            pos = offset;
           
            backgroumd.RegisterCallback<PointerDownEvent>(pointer);
            if (flg)
            {
                moveLeft();
                
            }
            else
            {
                moveRight();
            }

        };
        

    }
    private const int SPEED=100;
    void moveLeft(){
            //サイドバー戻す
                sidebar.experimental.animation.Position(pos, SPEED);
                backgroumd.style.display = DisplayStyle.None;

                flg = false;
        }
    void moveRight(){
        //サイドバー表示
                sidebar.experimental.animation.Position(-pos, SPEED);
                backgroumd.style.display = DisplayStyle.Flex;

                flg = true;
    }
    void pointer(PointerDownEvent eve){
        moveLeft();
    }
   
}

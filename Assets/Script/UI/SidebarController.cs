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

    [SerializeField] public float speed = 10f;
    /// <summary>
    ///　サイドバーを左右に動かすクラス
    /// </summary>
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("btn").clicked += () =>
        {
            
            sidebar = root.Q<VisualElement>("sidebar");
            Vector2 offset = sidebar.layout.position;
            backgroumd = root.Q<VisualElement>("gray-background");
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
    void moveLeft(){
            //サイドバー戻す
                sidebar.experimental.animation.Position(pos, 1000);
                backgroumd.style.display = DisplayStyle.None;

                flg = false;
        }
    void moveRight(){
        //サイドバー表示
                sidebar.experimental.animation.Position(-pos, 1000);
                backgroumd.style.display = DisplayStyle.Flex;

                flg = true;
    }
    void pointer(PointerDownEvent eve){
        moveLeft();
    }
   
}

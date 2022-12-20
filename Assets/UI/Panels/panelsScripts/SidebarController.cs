using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SidebarController : MonoBehaviour
{
    private VisualElement sidebar;

    private bool flg = false;

    [SerializeField] public float speed = 10f;
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("btn").clicked += () =>
        {
            Debug.Log("メニューボタン押下");
            sidebar = root.Q<VisualElement>("sidebar");
            Vector2 offset = sidebar.layout.position;
            VisualElement backgroumd = root.Q<VisualElement>("gray-background");

            Vector3 pos = offset;
            Debug.Log(pos);
            if (flg)
            {
                //サイドバー戻す
                sidebar.experimental.animation.Position(pos, 1000);
                backgroumd.style.display = DisplayStyle.None;

                flg = false;
            }
            else
            {
                //サイドバー表示
                sidebar.experimental.animation.Position(-pos, 1000);
                backgroumd.style.display = DisplayStyle.Flex;

                flg = true;
            }

        };
    }
}

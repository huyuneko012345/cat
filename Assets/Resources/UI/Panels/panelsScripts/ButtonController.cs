using UnityEngine;
using UnityEngine.UIElements;

public sealed class ButtonController :MonoBehaviour
{
//    private readonly Button _button;

//     public ButtonController(VisualElement visualElement)
//     {
//         // VisualElementからButtonを取得する
//         _button = visualElement.Q<Button>("back-arrow");

//         _button.clicked += OnClick;
//     }
//     private void OnClick()
//     {
//         // クリックされたログを出力する
//         Debug.Log($"Clicked: {_button.text}");
//     }
void Awake()
{
                     VisualElement root = GetComponent<UIDocument>().rootVisualElement;

             root.Q<Button>("Button").clicked+=()=>Debug.Log("aaa");  

}
}

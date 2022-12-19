using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    private void Awake() {
         VisualElement root = GetComponent<UIDocument>().rootVisualElement;
         root.Q<Button>("back").clicked +=()=>SceneManager.LoadScene("start");
        
         root.Q<Button>("shop").clicked +=()=>Debug.Log("shop");
         root.Q<Button>("item").clicked +=()=>Debug.Log("item");
         root.Q<Button>("cat-list").clicked +=()=>Debug.Log("cat-list");
         root.Q<Button>("setting").clicked +=()=>Debug.Log("setting");
         root.Q<Button>("help").clicked +=()=>Debug.Log("help");

    }
}

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
    }
}

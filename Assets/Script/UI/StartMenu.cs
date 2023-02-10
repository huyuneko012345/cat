using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/*スタート画面からメイン画面を制御する*/
public class StartMenu : MonoBehaviour
{
   private const string START="start";
   private const string MAIN="main";
   private void Awake() {
    VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    root.Q<Button>(START).clicked += ()=> SceneManager.LoadScene(MAIN);
   }
}

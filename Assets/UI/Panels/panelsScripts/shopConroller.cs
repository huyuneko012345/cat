using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shopConroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        VisualElement root=GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("back-arrow").clicked +=()=>Debug.Log("aaa");
    }
}

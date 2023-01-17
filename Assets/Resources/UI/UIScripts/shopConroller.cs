using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopConroller: MonoBehaviour
{
    private GameObject content;
    private GameObject viewPrefab;
    public void addView(){
        content=GameObject.Find("Content");
        viewPrefab=(GameObject)Resources.Load("UI/Prefabs/ScrollView");
        GameObject _scroll=Instantiate(viewPrefab,content.transform);
    }
}

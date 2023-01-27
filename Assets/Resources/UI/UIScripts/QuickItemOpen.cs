using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Di=System.Diagnostics;
using System;

public class QuickItemOpen : MonoBehaviour
{
    Di.Stopwatch sw;
    
    TimeSpan ts; 
    private Vector3 clickPosition;

    /*[NonSerialized]*/public GameObject _prefab;

    private bool flg=false;
public void PushDown(){
    
    sw.Start();    

}
public void PushUp(){
    
    sw.Stop();
    ts=sw.Elapsed;
    if(isSec()){
        Debug.Log("開いた");
    }
}

public void onClick(){
    // ShowItemData showItemData=GetComponent<ShowItemData>();
    // _prefab=showItemData.GetPrefab;
    flg=true;
    Debug.Log("クリックされた");

}
void Awake()
{
    sw=new Di.Stopwatch();
}

public  bool isSec(){
    if(ts.Seconds>=2){
    return true;
    }
    return false;
}
void Update()
{
    if(flg){
        if(Input.GetMouseButtonDown(0)){
        clickPosition=Input.mousePosition;
        clickPosition.z=10f;
        try{
            Instantiate(_prefab,new Vector3(100,100,100),_prefab.transform.rotation);
        }catch(NullReferenceException){
            Debug.Log("生成できないよ");
            return;
        }
        flg=false;
       
    }
    }
}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Di=System.Diagnostics;
using System;

public class QuickItemOpen : MonoBehaviour
{
    Di.Stopwatch sw;
    
    TimeSpan ts; 


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
}


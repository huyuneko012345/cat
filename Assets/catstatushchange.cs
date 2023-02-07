using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class catstatushchange : MonoBehaviour
{

    private DateTime nowTime;
    public CatDataBase catdb;

    void Start()
    {
        DateTime nowTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
     DateTime nextTime = DateTime.Now;
     Console.WriteLine("時:"+nextTime.Hour);
     Console.WriteLine("時:"+nowTime.Hour);
     int diffelence = nowTime.Hour - nextTime.Hour;
     if (diffelence > 0){
        //catdb.catDataList[0].Hunger - (8*diffelence);
        nowTime = nextTime;
     }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionclercontroller : MonoBehaviour
{

    public MissionDataBase mi;
    public CatDataBase catdb;

    private bool[] inlis = new bool[10]{false,false,false,false,false,false,false,false,false,false,};

    private int number = 0;

    void Update()
    {
        while(mi.MissionDataList.Count > number){
           if(mi.MissionDataList[number].MaxCount == mi.MissionDataList[number].count && false == inlis[number]){
           catdb.catDataList[0].favorability += 10;
           inlis[number] = true;
           
        }
        number += 1;
        }
        number = 0;
    }
}

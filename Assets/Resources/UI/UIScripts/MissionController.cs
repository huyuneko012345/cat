using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;
using TMPro;



public class MissionController : MonoBehaviour
{
    private List<Mission>todayMission;
     private List<Mission>missionList;
    public void addMission()
    {
        
        GameObject MissionPrefab = (GameObject)Resources.Load(MISSION);
        GameObject content = GameObject.Find(CONTENT);
        foreach(Mission mission in todayMission){

        GameObject missionPanel  =Instantiate(MissionPrefab, content.transform);
        TextMeshProUGUI child= missionPanel.GetComponentInChildren<TextMeshProUGUI>(); 
        child.text=mission.missionName;
        var top=missionPanel.transform.GetChild(1).GetChild(0);
        var buttom=missionPanel.transform.GetChild(1).GetChild(1);
        TextMeshProUGUI missionName= top.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>(); 
        TextMeshProUGUI progressRate= top.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>(); 

        missionName.text=mission.missionName;
        progressRate.text=(string.Join("/",mission.count,mission.MaxCount));

        
        }
    }
    public void pickMission(){
        MissionDataBase missionDataBase=(MissionDataBase)Resources.Load("DB/MissionDB");
        List<Mission>missionList=new List<Mission>(missionDataBase.MissionDataList);
                for(int i=0;i<5;i++){

        int index=Random.Range(0,missionList.Count);
        todayMission.Add(missionList[index]);
                }
    }
}

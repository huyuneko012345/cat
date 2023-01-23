using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;
using TMPro;
using UnityEngine.UI;


public class MissionController : MonoBehaviour
{
    private List<Mission>todayMissionList;
    public void addMission()
    {
        
        GameObject MissionPrefab = (GameObject)Resources.Load(MISSION);
        GameObject content = GameObject.Find(CONTENT);
        foreach(Mission mission in todayMissionList){

        GameObject missionPanel  =Instantiate(MissionPrefab, content.transform);
        TextMeshProUGUI child= missionPanel.GetComponentInChildren<TextMeshProUGUI>(); 
        child.text=mission.missionName;
        var top=missionPanel.transform.GetChild(1).GetChild(0);
        var buttom=missionPanel.transform.GetChild(1).GetChild(1);
        TextMeshProUGUI missionName= top.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>(); 
        TextMeshProUGUI progressRate= top.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>(); 
        Slider slider=buttom.transform.Find("Slider").GetComponent<Slider>();
        slider.maxValue=mission.MaxCount;
        slider.value=mission.count;

        missionName.text=mission.missionName;
        progressRate.text=(string.Join("/",mission.count,mission.MaxCount));

        
        }
    }
    public void pickMission(){
        todayMissionList=new List<Mission>();
        MissionDataBase missionDataBase=(MissionDataBase)Resources.Load("DB/MissionDB");
        List<Mission>missionList=new List<Mission>(missionDataBase.MissionDataList);
                for(int i=0;i<5;i++){

        int index=Random.Range(0,missionList.Count);
        todayMissionList.Add(missionList[index]);
        missionList.RemoveAt(index);
                }
    }
}

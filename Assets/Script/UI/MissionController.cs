using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;
using TMPro;
using UnityEngine.UI;


public class MissionController : MonoBehaviour
{
    private const string MISSION_KEY="Mission";
    private static List<Mission>todayMissionList=null;

    private static Dictionary<int,Mission> dic=null;

    private  FPManager fPManager;
    private bool flg=true;
    public void Awake()
    {
        fPManager=GameObject.Find("UIDocument").GetComponent<FPManager>();
        
        var ids=PlayerPrefs.GetString(MISSION_KEY,"1,2,3,4,5").Split(",");
        if(todayMissionList==null){
            todayMissionList=new List<Mission>();
            foreach(string id in ids){
        int key=int.Parse(id);
            GetMission(key);
        }
        if(dic==null){
            dic=new Dictionary<int,Mission>();
            foreach(Mission mission in todayMissionList){
                dic.Add(mission.id,mission);
            }
        }
        }
        
    }
   
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
    private void GetMission(int key){
         MissionDataBase missionDataBase=(MissionDataBase)Resources.Load("DB/MissionDB");
                Mission mission=missionDataBase.MissionDataList.Find(m=>m.id==key);
                todayMissionList.Add(mission);
    }
    public void pickMission(){
        List<int> idList=new List<int>();
        todayMissionList=new List<Mission>();
        MissionDataBase missionDataBase=(MissionDataBase)Resources.Load("DB/MissionDB");
        List<Mission>missionList=new List<Mission>(missionDataBase.MissionDataList);
                for(int i=0;i<5;i++){
        
        int index=UnityEngine.Random.Range(0,missionList.Count);
        missionList[index].ZeroCount();
        todayMissionList.Add(missionList[index]);
        idList.Add(missionList[index].id);
        missionList.RemoveAt(index);
                }
        todayMissionList.Sort((a,b)=>a.id-b.id);
        idList.Sort((a,b)=>a-b);
        
        var strIds=String.Join(",",idList);
        PlayerPrefs.SetString(MISSION_KEY,strIds);
        PlayerPrefs.Save();


    }
    public void ClearValue(int key,int count){
        
       
        if(!dic.ContainsKey(key)){
         return;
       }

        if(dic[key].MaxCount==dic[key].count){
            return;
        }
        if(dic[key].MaxCount<=dic[key].count+count){
            dic[key].count=dic[key].MaxCount;
            int fp=dic[key].fp;
            fPManager.addFP(fp);            
        }else{
            Debug.Log(111);
            dic[key].count+=count;
        }
    }
}

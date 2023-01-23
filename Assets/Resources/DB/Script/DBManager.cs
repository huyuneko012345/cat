using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    [SerializeField] private CatDataBase catDB;
    [SerializeField] private ItemDetaBase itemDB;
    [SerializeField] private MissionDataBase missionDB;
    [SerializeField] private MyItemDB MyItemDB;


    public void addCat(Cat cat)
    {
        catDB.catDataList.Add(cat);
    }
    public void addItem(Item item)
    {
        itemDB.itemDataList.Add(item);
    }
    public void addMission(Mission mission)
    {
        missionDB.MissionDataList.Add(mission);
    }
    public void addMyItem(MyItem myItem){
      MyItemDB.myItemList.Add(myItem);
    }

}

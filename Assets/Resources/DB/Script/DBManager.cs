using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
        [SerializeField] private CatDataBase catDataBase;
    private void addCat(Cat cat){
        catDataBase.catDataList.Add(cat);
    }
     [SerializeField]private ItemDetaBase itemDetaBase;
   private void addItem(Item item){
    itemDetaBase.itemDataList.Add(item);
   }
     [SerializeField]private MissionDataBase missionDataBase;
   private void addMission(Mission mission){
    missionDataBase.MissionDataList.Add(mission);
   }
}

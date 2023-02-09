using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickItemData : MonoBehaviour
{
    private MyItem myItem;
   [SerializeField]private Image sprite;

   private GameObject _prefab;

   public bool isExist{get;set;}=false;
   

   [SerializeField]private int count;
    public void setMyItem(int id)
    {
        this.myItem = MyItemDB.GetValue(id);
       this.sprite.sprite=myItem.item.image;
       this.count=myItem.count;
        this._prefab=myItem.item.prefab;
    }
    public GameObject GetPrefab(){
        return _prefab;
    }
    public MyItem GetMyItem(){
        return this.myItem;
    }
    public void minusCount(int count=1){
        myItem.minusCount(count);
        this.count-=count;
    }
    public int GetCount(){
        return this.count;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MyItemDB : ScriptableObject
{
    public List<MyItem>myItemList=new List<MyItem>();

    public void ClearItem(){
       myItemList.Clear();
    }
    public void AddItem(MyItem myItem){
        myItemList.Add(myItem);
    }

}

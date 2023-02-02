using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MyItemDB : ScriptableObject
{
    public List<MyItem>myItemList=new List<MyItem>();
    private static Dictionary<int, MyItem> dic = null;

    public static MyItem GetValue(int key)
    {
        if (dic == null)
        {
            
            dic = new Dictionary<int, MyItem>();
            MyItemDB myItemDB = (MyItemDB)Resources.Load("DB/MyItemDB");
            foreach (MyItem data in myItemDB.myItemList)
            {
                dic.Add(data.item.id, data);
            }
        }
        Debug.Log(key);
        return dic[key];
    }
    public void ClearItem(){
       myItemList.Clear();
    }
    public void AddItem(MyItem myItem){
        myItemList.Add(myItem);
    }

}

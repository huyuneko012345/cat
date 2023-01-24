using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ItemMasterData : ScriptableObject
{
    [SerializeField] private Item[] data;

    private static Dictionary<int, Item> dic = null;

    public static Item GetValue(int key)
    {
        if (dic == null)
        {
            dic = new Dictionary<int, Item>();
            ItemMasterData itemMasterData = (ItemMasterData)Resources.Load("DB/ItemMasterData");
            foreach (Item data in itemMasterData.data)
            {
                dic.Add(data.id, data);
            }
        }
        return dic[key];
    }
    public static int GetLength(){
        return dic.Count;
    }
}


[CreateAssetMenu]
[Serializable]
public class Item : ScriptableObject     
{

    public int id;
    public string name;
    public string text;

    public int price;
    public Sprite image;
}


using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Text.RegularExpressions;



public class test
{
    [MenuItem("MyGenerator/CreateMyItem")]
    private static void create()
    {
        ItemMasterData ItemMasterData = (ItemMasterData)Resources.Load("DB/ItemMasterData");

        List<Item> ItemList=new List<Item>(ItemMasterData.GetItemList());
        List<Item> foodList=ItemList.FindAll(Item=>Item.typeId==1);
        List<Item> toyList=ItemList.FindAll(Item=>Item.typeId==2);
        List<Item> objList=ItemList.FindAll(Item=>Item.typeId==3);
        CreateMyItem(foodList,"餌");
        CreateMyItem(toyList,"おもちゃ");
        CreateMyItem(objList,"設置物");
        
       
           
    }
    private static void CreateMyItem(List<Item> itemList,string dName){
        foreach(var item in itemList){
            var obj = ScriptableObject.CreateInstance<MyItem>();
            obj.item = item;
            obj.count = 0;
            string fileName = $"{obj.item.name}.asset";
            var path = $"Assets/Resources/DB/MyItem/{dName}";
            if(!Directory.Exists(path)){
                Directory.CreateDirectory(path);
            }
            AssetDatabase.CreateAsset(obj,Path.Combine(path,fileName));
        }
    }
}

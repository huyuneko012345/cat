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

        List<Item> ItemList = new List<Item>(ItemMasterData.GetItemList());
        List<Item> foodList = ItemList.FindAll(Item => Item.typeId == 1);
        List<Item> toyList = ItemList.FindAll(Item => Item.typeId == 2);
        List<Item> objList = ItemList.FindAll(Item => Item.typeId == 3);
        CreateMyItem(foodList, "餌");
        CreateMyItem(toyList, "おもちゃ");
        CreateMyItem(objList, "設置物");
    }
    private static void CreateMyItem(List<Item> itemList, string dName)
    {
        foreach (var item in itemList)
        {
            var obj = ScriptableObject.CreateInstance<MyItem>();
            obj.item = item;
            obj.count = 0;
            string fileName = $"{obj.item.name}.asset";
            var path = $"Assets/Resources/DB/MyItem/{dName}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            AssetDatabase.CreateAsset(obj, Path.Combine(path, fileName));
        }
    }

    private static MyItemDB myItemDB;
    [MenuItem("MyGenerator/SetMyItem")]
    private static void SetMyItem()
    {

        myItemDB = (MyItemDB)Resources.Load("DB/MyItemDB");
        myItemDB.ClearItem();
        Set("餌");
        Set("おもちゃ");
        Set("設置物");

    }

    private static void Set(string dirName)
    {
        DirectoryInfo di = new DirectoryInfo($"Assets\\Resources\\DB\\MyItem\\{dirName}");
        Debug.Log(di);
        FileInfo[] fileInfos = di.GetFiles("*.asset", SearchOption.AllDirectories);
        foreach (var f in fileInfos)
        {

            var fileName = Path.GetFileNameWithoutExtension(f.ToString());
            var a = (MyItem)Resources.Load($"DB/MyItem/{dirName}/{fileName}");
            myItemDB.AddItem(a);
            Debug.Log(fileName);
        }
    }

}

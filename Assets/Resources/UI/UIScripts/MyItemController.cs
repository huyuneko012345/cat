using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;


using TMPro;

public class MyItemController : MonoBehaviour
{
    [SerializeField]private MyItemDB myItemDB;
    [SerializeField]private GameObject buttonPrefab;
    public void CreateMyItem(int typeId=1){
  GameObject content = GameObject.Find(CONTENT);
        
var panel = GameObject.Find("ContentPanel").transform;
        var ItemTab = GameObject.Find("ItemTab(Clone)");
        DeleteItem();
        if (!ItemTab)
        {
            Transform tabTransform = Instantiate((GameObject)Resources.Load("UI/prefabs/ItemTab")).transform;
            tabTransform.SetParent(panel, false);
        }
        List<MyItem> itemList = myItemDB.myItemList;
        List<MyItem> myItemTypeList=itemList.FindAll(item=>item.item.typeId==typeId);
        Debug.Log(String.Join(",",myItemTypeList));
        foreach (MyItem myItem in myItemTypeList)
        {   if(myItem.count>=0){
            Debug.Log(myItem.item.name);
            GameObject itemButton = Instantiate(buttonPrefab, content.transform);
            TextMeshProUGUI name = itemButton.GetComponentInChildren<TextMeshProUGUI>();
            var button = itemButton.transform.Find("Button");
            Image img= button.GetComponent<Image>();
            img.sprite=myItem.item.image;
            name.text = $"{myItem.item.name}({myItem.count})";
            }
        }
        }
    // public void addMyItem(Item item){
    //     MyItemDB myItemDB=(MyItemDB)Resources.Load("DB/MyItemDB");
    //     foreach(MyItem myItem in myItemDB.myItemList){
    //         if(item.GetId()==myItem.item.GetId()){
    //             myItem.addCount(1);
    //             return;
    //         }
    //         var obj=ScriptableObject.CreateInstance<MyItem>();
    //         obj.item=item;
    //         obj.count=1;
    //         string fileName=$"{item.name}.asset";
    //         string path="Assets/Resources/DB/MyItem";

    //     }
        

    // }
    private void DeleteItem(){
        var itembuttons=GameObject.FindGameObjectsWithTag("MyItemButton");
       foreach(var itemButton in itembuttons){
         Destroy(itemButton);   
       }
       
    }
}

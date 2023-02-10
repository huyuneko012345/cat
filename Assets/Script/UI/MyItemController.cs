using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;


using TMPro;
/// <summary>
/// 持ち物画面を制御する
/// </summary>
public class MyItemController : MonoBehaviour
{
    [SerializeField]private MyItemDB myItemDB;
    [SerializeField]private GameObject buttonPrefab;
    [SerializeField]private GameObject ItemescriptionCanvas;
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
        foreach (MyItem myItem in myItemTypeList)
        {   if(myItem.count>0){
          int id=myItem.item.GetId();
            GameObject itemButton = Instantiate(buttonPrefab, content.transform);
            itemButton.GetComponent<ShowItemData>().setMyItem(id,myItem.count);
            
            var button = itemButton.transform.Find("Button").GetComponent<Button>();
            button.onClick.AddListener(()=>{
              OpenItemDescription(id);
            });

            
            }
        }
        }

    private void DeleteItem(){
        var itembuttons=GameObject.FindGameObjectsWithTag("MyItemButton");
       foreach(var itemButton in itembuttons){
         Destroy(itemButton);   
       }
       
    }
    private void OpenItemDescription(int id)
    {
        ItemescriptionCanvas.SetActive(true);
        ItemescriptionCanvas.GetComponent<ShowItemData>().setItem(id);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;

using TMPro;

public class MyItemController : MonoBehaviour
{
    public void CreateMyItem(){
  GameObject content = GameObject.Find(CONTENT);
        MyItemDB myItemDB = (MyItemDB)Resources.Load("DB/MyItemDB");
        GameObject itemButtonPrefab = (GameObject)Resources.Load(MYITEM_BUTTON);
        List<MyItem> itemList = myItemDB.myItemList;
        foreach (MyItem myItem in itemList)
        {   if(myItem.count>0){
            GameObject itemButton = Instantiate(itemButtonPrefab, content.transform);
            TextMeshProUGUI name = itemButton.GetComponentInChildren<TextMeshProUGUI>();
            var button = itemButton.transform.Find("Button");
            Image img= button.GetComponent<Image>();
            img.sprite=myItem.item.image;
            name.text = $"{myItem.item.name}({myItem.count})";
            }
        }
        }
    public void addMyItem(Item item){
        MyItemDB myItemDB=(MyItemDB)Resources.Load("DB/MyItemDB");
        MyItem myItem=new MyItem();
        myItem.item=item;
        myItem.count+=1;
        myItemDB.myItemList.Add(myItem);

    }
}

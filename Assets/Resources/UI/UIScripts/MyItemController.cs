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
    public void CreateMyItem(){
  GameObject content = GameObject.Find(CONTENT);
        // MyItemDB myItemDB = (MyItemDB)Resources.Load("DB/MyItemDB");
        // GameObject itemButtonPrefab = (GameObject)Resources.Load(MYITEM_BUTTON);
        Debug.Log(myItemDB);
        List<MyItem> itemList = myItemDB.myItemList;
        foreach (MyItem myItem in itemList)
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
    public void addMyItem(Item item){
        MyItemDB myItemDB=(MyItemDB)Resources.Load("DB/MyItemDB");
        foreach(MyItem myItem in myItemDB.myItemList){
            if(item.GetId()==myItem.item.GetId()){
                myItem.addCount(1);
                return;
            }
            var obj=ScriptableObject.CreateInstance<MyItem>();
            obj.item=item;
            obj.count=1;
            string fileName=$"{item.name}.asset";
            string path="Assets/Resources/DB/MyItem";

        }
        

    }
}

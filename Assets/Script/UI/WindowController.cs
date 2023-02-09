using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField]private MyItemDB myItemDB;
    public void onBuy(){
        ShowItemData showItemData=GetComponent<ShowItemData>();
        Item item=showItemData.GetItem;
        var myItem= myItemDB.myItemList.Find(myItem=>myItem.item.id==item.id);
        myItem.addCount();
    }

    public void OnCancel(){
        this.gameObject.SetActive(false);
    }
}

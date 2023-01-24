using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static DialogUtil.FIlePath;


public class CreateShopItem : MonoBehaviour
{
    [SerializeField] private int []itemIds;

    [SerializeField]private GameObject yesNoCanvas;

    [SerializeField]private Transform shopContent;
    [SerializeField]private Text itemText;

    public Action<int> Init(){
        Action<int> onChangeFP=(fp)=>{};
        foreach(int id in itemIds){
Transform item=Instantiate((GameObject)Resources.Load(SHOP_ITEM_BUTTON)).transform;
item.SetParent(shopContent,false);
item.GetComponent<ShowItemData>().setItem(id);
/*TODO*/
Button button=item.Find("").GetComponent<Button>();
Button panel=item.GetComponent<Button>();

        }
        return onChangeFP;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemData : MonoBehaviour
{
    private Item item;
    public string name;
    public string text;

    public int price;
    public Sprite image;
    public void setItem(int id){
        this.item=ItemMasterData.GetValue(id);
        this.name=item.name;
        this.text=item.text;
        this.price=item.price;
    }
    public int GetPrice{
        get{
            return item.price;
        }
    }
}

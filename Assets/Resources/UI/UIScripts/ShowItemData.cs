using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowItemData : MonoBehaviour
{
    private Item item;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI text;
    public TextMeshProUGUI price;
    public Image image;
    public void setItem(int id){
        this.item=ItemMasterData.GetValue(id);
        this.ItemName.text=item.name;
        this.text.text=item.text;
        this.price.text=item.price.ToString();
        this.image.sprite=item.image;
    }
    public int GetPrice{
        get{
            return item.price;
        }
    }
}

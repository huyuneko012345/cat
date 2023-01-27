using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowItemData : MonoBehaviour
{
    private Item item;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Image image;

    private GameObject _prefab;
    public void setItem(int id)
    {
        this.item = ItemMasterData.GetValue(id);
        this.ItemName.text = item.name;
        this.text.text = item.text;
        this.price.text = $"{item.price.ToString()}FP";
        this.image.sprite = item.image;
        this._prefab=item.prefab;
    }
    public int GetPrice
    {
        get
        {
            return item.price;
        }
    }
    public Item GetItem{
        get{
            return item;
        }
    }
    public GameObject GetPrefab{
        get{
            return _prefab;
        }
    }
    
}

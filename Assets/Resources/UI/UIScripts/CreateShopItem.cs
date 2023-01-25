using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;
using TMPro;


public class CreateShopItem : MonoBehaviour
{
    [SerializeField] private int[] itemIds;

    [SerializeField] private GameObject yesNoCanvas;
    [SerializeField] private GameObject ItemescriptionCanvas;

    [SerializeField] private Text itemText;

    public Action<int> Init()
    {
        Action<int> onChangeFP = (fp) => { };
        foreach (int id in itemIds)
        {
            Transform item = Instantiate((GameObject)Resources.Load(SHOP_ITEM_BUTTON)).transform;
            GameObject shopContent = GameObject.Find(CONTENT);
            item.SetParent(shopContent.transform, false);
            item.GetComponent<ShowItemData>().setItem(id);
            ShowItemData itemData = item.GetComponent<ShowItemData>();
            TextMeshProUGUI name = item.GetComponentInChildren<TextMeshProUGUI>();
            name.text = itemData.name;
            Image img = item.Find("Button").GetComponent<Image>();
            Debug.Log(itemData.image);
            img.sprite = itemData.image;
            /*TODO*/
            Button button = item.Find("Button").GetComponent<Button>();
            Button shopItemButton = item.GetComponent<Button>();
            int key = id;
            
            button.onClick.AddListener(() =>
            {
                OpenItemDescription(key);
            });
            shopItemButton.onClick.AddListener(() =>
            {
                OpenYesNoWindow(key);
            });
            onChangeFP += (coin) =>
            {
                bool canBuy = coin >= ItemMasterData.GetValue(key).price;
                button.interactable = canBuy;
                shopItemButton.interactable = canBuy;
            };
        }
        return onChangeFP;
    }
    private void ItemTextInit()
    {
        if (ItemMasterData.GetLength() > 0 && itemIds.Length > 0)
        {
            itemText.text = ItemMasterData.GetValue(itemIds[0]).text;
        }
        else
        {
            itemText.text = "品切れ";
        }
    }
    private void OpenItemDescription(int id)
    {
        ItemescriptionCanvas.SetActive(true);
        ItemescriptionCanvas.GetComponent<ShowItemData>().setItem(id);
    }
    private void OpenYesNoWindow(int id)
    {
        Debug.Log(id);
        yesNoCanvas.SetActive(true);
        yesNoCanvas.GetComponent<ShowItemData>().setItem(id);
    }
}

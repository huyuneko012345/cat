using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static DialogUtil.FIlePath;


public class CreateShopItem : MonoBehaviour
{
    [SerializeField] private int[] itemIds;

    [SerializeField] private GameObject yesNoCanvas;

    [SerializeField] private Text itemText;

    public Action<int> Init()
    {
        Action<int> onChangeFP = (fp) => { };
        foreach (int id in itemIds)
        {
            Transform item = Instantiate((GameObject)Resources.Load(SHOP_ITEM_BUTTON)).transform;
            GameObject shopContent=(GameObject)Resources.Load(SHOP_VIEW);
            item.SetParent(shopContent.transform, false);
            item.GetComponent<ShowItemData>().setItem(id);
            /*TODO*/
            Button button = item.Find("").GetComponent<Button>();
            Button panel = item.GetComponent<Button>();
            int key = id;
            button.onClick.AddListener(() =>
            {

            });

        }
        return onChangeFP;
    }
    private void ItemTextInit(){
        if (ItemMasterData.GetLength()>0&&itemIds.Length>0){
            itemText.text=ItemMasterData.GetValue(itemIds[0]).text;
        }else{
            itemText.text="品切れ";
        }
    }
    private void ChangeItemText(int id)
    {
        itemText.text = ItemMasterData.GetValue(id).text;
    }
    private void OpenYesNoWindow(int id)
    {
        ChangeItemText(id);
        yesNoCanvas.SetActive(true);
        yesNoCanvas.GetComponent<ShowItemData>().setItem(id);
    }
}

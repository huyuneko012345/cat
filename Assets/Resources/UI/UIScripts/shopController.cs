using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;
using System;

using TMPro;



public class ShopController : MonoBehaviour
{


    public void CreateItem()
    {
        // GameObject content = GameObject.Find(CONTENT);
        // ItemDetaBase itemDataBase = (ItemDetaBase)Resources.Load("DB/ItemDB");
        // GameObject itemButtonPrefab = (GameObject)Resources.Load(SHOPITEMBUTTON);
        // List<Item> itemList = itemDataBase.itemDataList;
        // foreach (Item item in itemList)
        {
        //     GameObject itemButton = Instantiate(itemButtonPrefab, content.transform);
        //     TextMeshProUGUI name = itemButton.GetComponentInChildren<TextMeshProUGUI>();
        //     var button = itemButton.transform.Find("Button");
        //     Image img= button.GetComponent<Image>();

        //     img.sprite=item.image;
        //     name.text = item.ItemName;
        //     Debug.Log("createshopitem");
        //     Action<int> onChangeFP=(fp)=>{};
        // onChangeFP+=(fp)=>{
        //     /*TODO ショップの購入判定
        //     fpが商品以上ないと購入出来ないようにする；
        //     */
        //     bool canbuy= true;
        //     Debug.Log("fp"+fp);
            
        };
        }
        
    }
//     public Action<int> GetOnChangeFP(){
//         Action<int> onChangeFP=(fp)=>{};
//         onChangeFP+=(fp)=>{
//             /*TODO ショップの購入判定
//             fpが商品以上ないと購入出来ないようにする；
//             */
//             bool canbuy= true;
            
//         };
//         return onChangeFP;
//     }
// }

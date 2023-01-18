using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBaseManager : MonoBehaviour
{
   [SerializeField]private ItemDetaBase itemDetaBase;
   private void addItem(Item item){
    itemDetaBase.itemDataList.Add(item);
   }
}

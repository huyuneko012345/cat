using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickItemData : MonoBehaviour
{
    private MyItem item;
   [SerializeField]private Image sprite;

   [NonSerializedAttribute]private GameObject _prefab;

   [SerializeField]private int count;
    public void setMyItem(int id)
    {
        this.item = MyItemDB.GetValue(id);
       this.sprite.sprite=item.item.image;
       this.count=item.count;
        this._prefab=item.item.prefab;
    }
}

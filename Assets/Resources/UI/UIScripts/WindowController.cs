using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public void onBuy(){
        ShowItemData showItemData=GetComponent<ShowItemData>();
        
    }

    public void OnCancel(){
        this.gameObject.SetActive(false);
    }
}

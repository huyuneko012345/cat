using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTabButtonController : MonoBehaviour
{
    private FPManager fPManager;
    private CreateShopItem createShopItem;
    void Awake()
    {
        fPManager=GameObject.Find("UIDocument").GetComponent<FPManager>();
        createShopItem=GameObject.Find("UIDocument").GetComponent<CreateShopItem>();
    }
    public void OnFoodButtonClick()
    {
        var button = gameObject.transform.Find("FoodButton");
        int id = button.GetComponent<HasType>().GetTypeId;
                 Debug.Log(id);

        fPManager.Init(createShopItem.Init(id));
        
    }
    public void OnToyButtonClick()
    {
        var button = gameObject.transform.Find("ToyButton");
        int id = button.GetComponent<HasType>().GetTypeId; 
        Debug.Log(id);
        fPManager.Init(createShopItem.Init(id));
    }
    public void OnObjButtonClick()
    {
        var button = gameObject.transform.Find("ObjButton");
        int id = button.GetComponent<HasType>().GetTypeId;
         Debug.Log(id);
         fPManager.Init(createShopItem.Init(id));
    }
}

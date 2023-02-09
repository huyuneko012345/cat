using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTabButtonController : MonoBehaviour
{
    private FPManager fPManager;
    private CreateShopItem createShopItem;
    private MyItemController myItemController;
    void Awake()
    {
        fPManager = GameObject.Find("UIDocument").GetComponent<FPManager>();
        createShopItem = GameObject.Find("UIDocument").GetComponent<CreateShopItem>();
        myItemController=GameObject.Find("UIDocument").GetComponent<MyItemController>();
    }
    public void OnFoodButtonClick()
    {
        var button = gameObject.transform.Find("FoodButton");
        int id = button.GetComponent<HasType>().GetTypeId;
        if (isShop())
        {
            fPManager.Init(createShopItem.Init(id));
        }
        if(isMyItem()){
            myItemController.CreateMyItem(id);
        }

    }
    public void OnToyButtonClick()
    {
        var button = gameObject.transform.Find("ToyButton");
        int id = button.GetComponent<HasType>().GetTypeId;
        if (isShop())
        {
            fPManager.Init(createShopItem.Init(id));
        }
        if(isMyItem()){
            myItemController.CreateMyItem(id);
        }
    }
    public void OnObjButtonClick()
    {
        var button = gameObject.transform.Find("ObjButton");
        int id = button.GetComponent<HasType>().GetTypeId;
        if (isShop())
        {
            fPManager.Init(createShopItem.Init(id));
        }
        if(isMyItem()){
            myItemController.CreateMyItem(id);
        }
    }
    private bool isShop()
    {
        var obj = GameObject.Find("ShopView(Clone)");
        if (obj)
        {
            return true;
        }
        return false;
    }
    private bool isMyItem(){
        var obj = GameObject.Find("MyItemView(Clone)");
        if (obj)
        {
            return true;
        }
        return false;
    }

}

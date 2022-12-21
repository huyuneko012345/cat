using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DataListController
{
    VisualTreeAsset m_ListEntryTemplate;
    VisualElement m_DataList;
    Label m_itemName;
    Label m_text;
    public void InitializeCharacterList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        EnumerateAllCharacters();
        // Store a reference to the template for the list entries
        m_ListEntryTemplate = listElementTemplate;

        // Store a reference to the character list element
        
        m_DataList = root.Q<VisualElement>("list");
        
        m_DataList.Clear();
        Debug.Log(m_DataList);
        float screenWidthPer = 0.5f;
        float screenWidth = 0f;
        

        float screenHeightPer = 10f;
        float screenHeight = 0f;
        
        m_DataList.RegisterCallback<GeometryChangedEvent>(v=>{
            screenWidth=m_DataList.contentRect.width;
            screenHeight=m_DataList.contentRect.height;
            
            Button button = new Button();
            button.name="a";
            button.text = "item" + 1;
            button.style.backgroundColor = Color.red;
            button.style.width = screenWidth*0.4f ;
            button.style.height = screenHeight*0.2f ;


            m_DataList.Add(button);

        
            
        });
        
        float padding = (1 - screenWidthPer)/2;
       

        // Store references to the selected character info elements

        // FillDataList();


        // Register to get a callback when an item is selected
        // m_CharacterList.onSelectionChange += OnCharacterSelected;
    }
    List<ItemData> m_AllDatas;
    void EnumerateAllCharacters()
    {
        m_AllDatas = new List<ItemData>();
        m_AllDatas.AddRange(Resources.LoadAll<ItemData>("Data"));
        Debug.Log(m_AllDatas);
    }
    // void FillDataList()
    // {
    //     m_DataList.makeItem = () =>
    //     {
    //         Debug.Log(40);
    //         var newDataEntry = m_ListEntryTemplate.Instantiate();
    //         var newListEntryLogic = new DataListEntryController();
    //         newDataEntry.userData = newListEntryLogic;
    //         Debug.Log(44);
    //         newListEntryLogic.SetVisualElement(newDataEntry);
    //         return newDataEntry;
    //     };
    //     m_DataList.bindItem = (item, i) =>
    //     {
    //         (item.userData as DataListEntryController).SetrData(m_AllDatas[i]);

    //     };
    //     m_DataList.fixedItemHeight = 100;
    //     m_DataList.itemsSource = m_AllDatas;

    // }
}

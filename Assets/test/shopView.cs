using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shopView : MonoBehaviour
{[SerializeField]
VisualTreeAsset m_listEntrytemplate;
    void OnEnable()
    {
        var uiDocument =GetComponent<UIDocument>();
        var dataListController=new DataListController();
        dataListController.InitializeCharacterList(uiDocument.rootVisualElement,m_listEntrytemplate);
    }
}

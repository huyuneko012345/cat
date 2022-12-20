using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DataListEntryController 
{
    Label m_name;
    Label m_text;
    public void SetVisualElement(VisualElement visualElement)
    {
        m_name = visualElement.Q<Label>("name");
        m_text = visualElement.Q<Label>("text");
    }

    //This function receives the character whose name this list 
    //element displays. Since the elements listed 
    //in a `ListView` are pooled and reused, it's necessary to 
    //have a `Set` function to change which character's data to display.

    public void SetrData(ItemData itemData)
    {
        m_name.text = itemData.name;
        m_text.text = itemData.text;
    }
}

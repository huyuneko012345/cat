using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickItemOnClick : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool createFlg = false;
    private GameObject prefab;
    public void OnClick()
    {
        prefab = GetComponent<QuickItemData>().GetPrefab();
        createFlg = true;
    }
    void Update()
    {
        if (!createFlg)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            try
            {
                Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
            }
            finally
            {
                createFlg = false;
                prefab = null;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    BoxCollider boxCollider;
 
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        Debug.Log("start");
       

    }


    void OnMouseDrag()
    {
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
            transform.position = new Vector3 (hit.point.x,hit.point.y , objPos.z);
            Debug.Log(hit.collider.name);
        }
    }
 

}

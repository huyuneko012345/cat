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
 void OnMouseDown() {
    Debug.Log("down");
        boxCollider.enabled = true;
    }

    void OnMouseDrag()
    {
        Debug.Log("drag");
        boxCollider.enabled = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = new Vector3 (hit.point.x, 0, hit.point.z);
            Debug.Log(hit.collider.name);
        }
    }
 
    void OnMouseUp()
    {
        Debug.Log("up");
        boxCollider.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CatSqawnObjectToPlane : MonoBehaviour
{
    public GameObject catPrefab;
    GameObject spwanedObj;

    ARRaycastManager arRaycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();   
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitpose = hits[0].pose;
                if(spwanedObj == null)
                {
                    spwanedObj = Instantiate(catPrefab, hitpose.position, hitpose.rotation);
                }
                else
                {
                    spwanedObj.transform.position = hitpose.position;
                }
            }
        }
        
    }
}

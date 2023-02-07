using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PutOnCat : MonoBehaviour
{
    public GameObject catPrefab;
    public AudioSource audioSource;
    [SerializeField] AudioClip clip;
    GameObject spawnedObj;
    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        Debug.Log("Start");
        print("すあたーと");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Debug.Log("aaaaaaaaaaa");
            if (aRRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                if(spawnedObj == null)
                {
                    spawnedObj = Instantiate(catPrefab, hitPose.position, hitPose.rotation);
                    Debug.Log("座標="+transform.localEulerAngles.y);
                    audioSource.PlayOneShot(clip);
                }
            }
        }
        
    }
}

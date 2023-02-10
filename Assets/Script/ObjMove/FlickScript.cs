using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// objをフリックするとobjがフリックした方向に移動する
/// </summary>
public class FlickScript : MonoBehaviour
{
    public Camera camera;
    public float powerPerPixel;
    public float maxPower;
    Vector3 touchPos;

    void Awake()
    {
        camera = GameObject.Find("AR Camera").GetComponent<Camera>();
    }
    void Start()
    {
        Vector3 local = transform.localEulerAngles;
        local.x = 0;
        local.y = camera.transform.localRotation.y;
        local.z = 0;
        transform.localEulerAngles = local;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            touchPos = Input.mousePosition;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Vector3 local = transform.localEulerAngles;
            local.x = 0;
            local.y = camera.transform.localRotation.y;
            local.z = 0;
            transform.localEulerAngles = local;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 releasePos = Input.mousePosition;
            float swipeDistanceY = releasePos.y - touchPos.y;
            float powerY = swipeDistanceY * powerPerPixel;
            float swipeDistanceX = releasePos.x - touchPos.x;
            float powerX = swipeDistanceX * powerPerPixel;
            float swipeDistanceZ = releasePos.z - touchPos.z;
            float powerZ = swipeDistanceZ * powerPerPixel;

            //powerをマイナスにさせないため
            if (powerX < 0)
            {
                powerX *= -1;
            }
            if (powerY < 0)
            {
                powerY *= -1;
            }
            if (powerZ < 0)
            {
                powerZ *= -1;
            }

            if (powerX > maxPower)
            {
                powerX = maxPower;
            }
            if (powerY > maxPower)
            {
                powerY = maxPower;
            }
            if (powerZ > maxPower)
            {
                powerZ = maxPower;
            }
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(powerX * swipeDistanceX, powerZ * swipeDistanceZ, powerY * swipeDistanceY), ForceMode.Impulse);

        }
    }
}

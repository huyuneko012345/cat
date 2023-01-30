using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPortUtil : MonoBehaviour
{
    [SerializeField]private GameObject viewPort;
    public GameObject GetViewPort{
        get{
            return viewPort;
        }
    }
}

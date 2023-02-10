using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///　猫クリックするとステータスが表示される
/// </summary>
public class DetailController : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update

    [SerializeField] private GameObject DetailCanvas;
    // Update is called once per frame
    void Awake()
    {
        if (this.DetailCanvas == null)
        {
            DetailCanvas = GameObject.Find("DetailCanvas");
            DetailCanvas.SetActive(false);
        }
    }
    // クリック
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        this.DetailCanvas.SetActive(!DetailCanvas.activeSelf);

    }
}

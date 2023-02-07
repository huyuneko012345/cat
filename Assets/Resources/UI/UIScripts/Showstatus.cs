using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showstatus : MonoBehaviour
{
    [SerializeField]private Slider hungerSlider;
    [SerializeField]private Slider favesSlider;
    [SerializeField]private Image emotion;
    [SerializeField]private Image gender;
    [SerializeField]private CatDataBase catDataBase;
    private List<Cat> cats;

    void Awake()
    {
        cats=catDataBase.catDataList;
        hungerSlider.value=cats[0].hunger;
        favesSlider.value=cats[0].favorability;
    }
    void Update()
    {
        hungerSlider.value=cats[0].hunger;
        favesSlider.value=cats[0].favorability;
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UI = UnityEngine.UI;
using UnityEngine.UIElements;

public class FPManager : MonoBehaviour
{
    private const string FP_KEY = "Coin";
    private const int DEFAULT_FP = 10000;

    private Action<int> onChengeFP = (FP) => { };

    [SerializeField] private GameObject yesNoCanvas;

    [SerializeField] private Label fpText;

    public void Init()
    {
        this.onChengeFP += (fp) =>
        {
            VisualElement root = GameObject.Find("UIDocument").GetComponent<UIDocument>().rootVisualElement;
            fpText = root.Q<Label>("FPText");
            fpText.text = fp.ToString();
        };

        yesNoCanvas.transform.Find("Panel/YesNoPanel/ButtonPanel/Yes").GetComponent<UI.Button>().onClick.AddListener(() =>
        {
            SubFP(yesNoCanvas.GetComponent<ShowItemData>().GetPrice);
        });
        //TODO あとで消す
        //確認用
        ChangeFP(10000);
        this.onChengeFP(LoadFP());
    }
    
    public void Init(Action<int> onChengeFP)
    {
        this.onChengeFP+=onChengeFP;

        this.onChengeFP(LoadFP());
    }
    private int LoadFP()
    {
        return PlayerPrefs.GetInt(FP_KEY, DEFAULT_FP);
    }
    private void ChangeFP(int fp)
    {
        PlayerPrefs.SetInt(FP_KEY, fp);
        PlayerPrefs.Save();
        onChengeFP(PlayerPrefs.GetInt(FP_KEY, 0));
    }
    private void addCoin(int fp)
    {
        if (fp < 0)
        {
            return;
        }
        ChangeFP(LoadFP() + fp);
    }
    private void SubFP(int fp)
    {
        if (fp < 0)
        {
            return;
        }
        if (LoadFP() - fp < 0)
        {
            return;
        }
        ChangeFP(LoadFP() - fp);
    }
}

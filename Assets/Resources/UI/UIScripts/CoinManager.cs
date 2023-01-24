using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CoinManager : MonoBehaviour
{
    private const string FP_KEY = "Coin";
    private const int DEFAULT_FP = 10000;

    private Action<int> onChengeFP = (FP) => { };

    [SerializeField] private GameObject yesNoCanvas;

    [SerializeField] private Label coinText;

    public void init(/*Action<int> onChengeCoin*/)
    {
        // this.onChengeCoin += onChengeCoin;
        this.onChengeFP += (coin) =>
        {
            VisualElement root = GameObject.Find("UIDocument").GetComponent<UIDocument>().rootVisualElement;
            coinText=root.Q<Label>("FPText");
            Debug.Log(coinText.text);
            Debug.Log(coin.ToString()   );
            coinText.text = coin.ToString();
            Debug.Log(coinText.text);
        };
        this.onChengeFP(LoadCoin());
    }
    private int LoadCoin()
    {
        return PlayerPrefs.GetInt(FP_KEY, DEFAULT_FP);
    }
    private void ChangeCoin(int coin)
    {
        PlayerPrefs.SetInt(FP_KEY, coin);
        PlayerPrefs.Save();
        onChengeFP(PlayerPrefs.GetInt(FP_KEY, 0));
    }
    private void addCoin(int coin)
    {
        if (coin < 0)
        {
            return;
        }
        ChangeCoin(LoadCoin() + coin);
    }
}

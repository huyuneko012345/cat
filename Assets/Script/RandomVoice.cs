using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 猫の鳴き声を配列内からランダムで出力するクラス
/// </summary>
public class RandomVoice : MonoBehaviour
{
    //スクリーン内で音を出すための変数
    public AudioSource AudioSource;
    //鳴き声のファイルの配列。現在４つの鳴き声を実装
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;
    [SerializeField] AudioClip clip4;

    //
    int voice_rundom = 0;
    //ランダム関数の呼び出し(音声用)
    System.Random voice_set = new System.Random();
    //ランダム関数の呼び出し(鳴き声のインターバル時間)
    System.Random interval = new System.Random();

    //インターバル時間の初期値


    int rundom = 0;
    int randomidle = 0;
    System.Random r1 = new System.Random();
    System.Random r2 = new System.Random();

    private float INTERVA_SECONDS = 10f;


    /// <summary>
    /// 鳴き声を配列からランダムで出力するメソッド
    /// 現在４つ作成
    /// </summary>
    public void catVoice()
    {
        

        //Voiceの抽選
        voice_rundom = voice_set.Next(1, 4);//1~4の乱数
        print("Voice番号：" + voice_rundom);

        switch (voice_rundom)
        {
            case 1:
                print(voice_rundom + "きちゃ");
                AudioSource.PlayOneShot(clip1);

                INTERVA_SECONDS = interval.Next(3, 6);
                break;

            case 2:
                print(voice_rundom + "きちゃ");
                AudioSource.PlayOneShot(clip2);

                INTERVA_SECONDS = interval.Next(3, 6);
                break;


            case 3:
                print(voice_rundom + "きちゃ");
                AudioSource.PlayOneShot(clip3);

                INTERVA_SECONDS = interval.Next(3, 6);
                break;


            case 4:
                print(voice_rundom + "きちゃ");
                AudioSource.PlayOneShot(clip4);

                INTERVA_SECONDS = interval.Next(3, 6);
                break;
        }

        CancelInvoke();
        //インターバル後に上記の処理を繰り返す
        Invoke("catVoice", INTERVA_SECONDS);

    }

    void Start()
    {
        catVoice();
    }
}

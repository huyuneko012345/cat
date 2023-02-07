using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVoice : MonoBehaviour
{
    public AudioSource AudioSource;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;
    [SerializeField] AudioClip clip4;

    

    int rundom = 0;
    int randomidle = 0;
    System.Random r1 = new System.Random();
    System.Random r2 = new System.Random();

    private float INTERVA_SECONDS = 10f;


    //猫の鳴き声を不定期に出すメソッド
    public void catVoice()
    {

        //Voiceの抽選
        rundom = r1.Next(1, 4);//1~4の乱数
        print("Voice番号："+rundom);

        switch (rundom)
        {
            case 1:
            print(rundom+"きちゃ");
                AudioSource.PlayOneShot(clip1);

                INTERVA_SECONDS = r2.Next(3,6);
                break;

            case 2:
            print(rundom+"きちゃ");
                AudioSource.PlayOneShot(clip2);

                INTERVA_SECONDS = r2.Next(3,6);
                break;


            case 3:
            print(rundom+"きちゃ");
                AudioSource.PlayOneShot(clip3);

                INTERVA_SECONDS = r2.Next(3,6);
                break;


            case 4:
            print(rundom+"きちゃ");
                AudioSource.PlayOneShot(clip4);

                INTERVA_SECONDS = r2.Next(3,6);
                break;
        }
        CancelInvoke();
        print(INTERVA_SECONDS+"秒待機");
        Invoke("catVoice", INTERVA_SECONDS);

    }

    void Start()
    {
        Debug.Log("Voice実行");
        catVoice();
    }

    
}

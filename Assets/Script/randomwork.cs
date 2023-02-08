using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class randomwork : MonoBehaviour
{

    public Animator PlayerAnimator;
    private Vector3 targetpos;
    public GameObject cat;
    public CatDataBase catdb;
    int rundom = 0;

    int rundomX = 0;

    int rundomZ = 0;

    int randomidle = 0;

    System.Random r1 = new System.Random();

    System.Random r2 = new System.Random();

    private float speed = 1.0f;

    public Transform target;

    private Transform position;

    private const float START_SECONDS = 10f;

    private float INTERVA_SECONDS = 10f;

    private int count = 2;
    


    public void judgetask()
    {
        Debug.Log(catdb.catDataList[0].interputTask);
        if (catdb.catDataList[0].interputTask == false)
        {

            //タスクの乱数抽選
            rundom = r1.Next(1, 5);//から10

            switch (rundom)
            {
                case 1://歩行
                    //睡眠状態の解除
                    this.PlayerAnimator.SetBool("Sleep", false);
                    //お座り状態を解除
                    this.PlayerAnimator.SetBool("Sit", false);
                    //毛づくろい状態の解除
                    this.PlayerAnimator.SetBool("Sit_action", false);

                    rundomX = r2.Next(-15, 15);//-300から300
                    rundomZ = r2.Next(-15, 15);//-300から300

                    target.transform.position = new Vector3(rundomX, 1, rundomZ);
                    this.PlayerAnimator.SetFloat("Speed", 1f);

                    if (rundomX < 0)
                    {
                        rundomX = rundomX * -1;
                    }

                    if (rundomZ < 0)
                    {
                        rundomZ = rundomZ * -1;
                    }

                    if (rundomX <= rundomZ)
                    {
                        INTERVA_SECONDS = rundomZ + 2;
                        print(INTERVA_SECONDS);
                    }
                    else
                    {
                        INTERVA_SECONDS = rundomX + 2;
                        print(INTERVA_SECONDS);
                    }

                    break;

                case 2://寝る

                    //お座り状態を解除
                    this.PlayerAnimator.SetBool("Sit", false);
                    //毛づくろい状態の解除
                    this.PlayerAnimator.SetBool("Sit_action", false);

                    randomidle = r1.Next(20, 25);//20秒～130秒間でランダムに睡眠時間を抽選

                    print("すいみんちゅうニャ。。。" + randomidle);

                    INTERVA_SECONDS = randomidle;

                    break;

                case 3://お座り

                    //睡眠状態の解除
                    this.PlayerAnimator.SetBool("Sleep", false);
                    //毛づくろい状態の解除
                    this.PlayerAnimator.SetBool("Sit_action", false);

                    randomidle = r1.Next(20, 30);//20秒～30秒間でランダムにお座り時間を抽選

                    print("おすわりちゅうニャ！" + randomidle);

                    INTERVA_SECONDS = randomidle;

                    break;

                case 4:

                    //睡眠状態の解除
                    this.PlayerAnimator.SetBool("Sleep", false);

                    randomidle = 10;//10秒間に毛づくろい時間を選択

                    print("けづくろいちゅうニャ！" + randomidle);

                    INTERVA_SECONDS = randomidle;


                    break;

            }

            
        }
        //待機モーション抽選繰り返し
        CancelInvoke();
        Invoke("judgetask", INTERVA_SECONDS);
    }

    void Start()
    {
        print("ここから");
        target = GameObject.FindGameObjectWithTag("Chase cat").transform;
        
        Invoke("judgetask", 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (catdb.catDataList[0].interputTask == false){
        

        switch (rundom)
        {
            case 1://歩行
                var delta = target.position - cat.transform.position;

                if (delta == Vector3.zero)
                {
                    return;
                }

                //進行方向の取得
                var rotation = Quaternion.LookRotation(delta, Vector3.up);

                //回転の反映
                transform.rotation = rotation;

                //指定座標までの移動
                transform.position = Vector3.MoveTowards(cat.transform.position, target.position, speed * Time.deltaTime);
                if (cat.transform.position == target.position)
                {
                    this.PlayerAnimator.SetFloat("Speed", 0);
                }


                break;

            case 2://睡眠
                this.PlayerAnimator.SetFloat("Speed", 0);
                this.PlayerAnimator.SetBool("Sleep", true);
                break;

            case 3:

                this.PlayerAnimator.SetFloat("Speed", 0);
                this.PlayerAnimator.SetBool("Sit", true);

                break;

            case 4:

                this.PlayerAnimator.SetFloat("Speed", 0);
                this.PlayerAnimator.SetBool("Sit", true);
                this.PlayerAnimator.SetBool("Sit_action", true);

                break;

        }
        }

        if(catdb.catDataList[0].interputTask == true & count%2 == 0){
            //睡眠状態の解除
            this.PlayerAnimator.SetBool("Sleep", false);
            //お座り状態を解除
            this.PlayerAnimator.SetBool("Sit", false);
            //毛づくろい状態の解除
            this.PlayerAnimator.SetBool("Sit_action", false);

            count = count+1;

        }else if(catdb.catDataList[0].interputTask == false & count%2 == 1){
            count = +1;
        }

    }
}

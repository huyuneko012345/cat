using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class catstatushchange : MonoBehaviour
{

    //現在ログイン時間
    private DateTime nowTime;
    //ログイン継続時間
    private DateTime nextTime;
    //前回ログアウト時間
    private DateTime beforTime;
    private int diffelence;
    public CatDataBase catdb;
    public int beforHour;
    System.Random r1 = new System.Random();

    void Start()
    {
        nowTime = DateTime.Now;
        string aaa = PlayerPrefs.GetString("KEY",nowTime.ToString());
        Debug.Log(aaa);
        DateTime befor = DateTime.Parse(aaa);

        //日付のまた越し判定
        if(nowTime.Day > befor.Day){
            
            beforHour = nowTime.Minute + befor.Minute;
            //前回ログイン時と今回ログイン時の経過時間を計算
            diffelence = beforHour - befor.Minute;
        }else{
            
            beforHour = befor.Minute;
            //前回ログイン時と今回ログイン時の経過時間を計算
            diffelence = nowTime.Minute - beforHour;
        }

        
        Debug.Log(diffelence);

        //日付をまたいだ場合diffelenceがマイナス値になるため補正
        if(diffelence < 0){
            Debug.Log("log1");
            diffelence = diffelence*(-1);
        }

        //ステータスの変更
        catdb.catDataList[0].hunger= catdb.catDataList[0].hunger - (8*diffelence);
        catdb.catDataList[0].favorability= catdb.catDataList[0].favorability - (1*diffelence);
        catdb.catDataList[0].mental= catdb.catDataList[0].mental - (r1.Next(1, 11));
        beforTime = nowTime;
    }

    void Update()
    {
     nextTime = DateTime.Now;
     //日付のまた越し判定
        if(nextTime.Day > nowTime.Day){
            beforHour = nowTime.Minute + nextTime.Minute;
            //前回と今回の経過時間を計算
            diffelence = beforHour - nowTime.Minute;
        }else{
            beforHour = nowTime.Minute;
            //前回と今回の経過時間を計算
            diffelence = nextTime.Minute - beforHour;
        }

        //日付をまたいだ場合diffelenceがマイナス値になるため補正
        if(diffelence < 0){
            diffelence = diffelence*(-1);
        }

     if (diffelence > 0){
        //ステータスの変更
        catdb.catDataList[0].hunger= catdb.catDataList[0].hunger - (8*diffelence);
        catdb.catDataList[0].favorability= catdb.catDataList[0].favorability - (1*diffelence);
        catdb.catDataList[0].mental= catdb.catDataList[0].mental - (r1.Next(1, 11));
        nowTime = nextTime;
        beforTime = nextTime;
        PlayerPrefs.SetString("KEY",beforTime.ToString());
        PlayerPrefs.Save();
     }
    }
}

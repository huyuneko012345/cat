using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 時間経過に伴いキャットデータベースの内を変更するクラス
/// </summary>
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

    /// <summary>
    ///前回ログアウト時間から今回ログイン時間までの時間を計算し、キャットデータベースの内容を変更する。
    /// </summary>
    void Start()
    {
        //ログイン時間の取得
        nowTime = DateTime.Now;
        //前回ログアウト時間の取得
        string timekeep = PlayerPrefs.GetString("KEY",nowTime.ToString());
        Debug.Log(timekeep);
        DateTime befor = DateTime.Parse(timekeep);

        //日付のまた越し判定
        if(nowTime.Day > befor.Day){
            
            beforHour = nowTime.Hour + befor.Hour;
            //前回ログイン時と今回ログイン時の経過時間を計算
            diffelence = beforHour - befor.Hour;
        }else{
            
            beforHour = befor.Hour;
            //前回ログイン時と今回ログイン時の経過時間を計算
            diffelence = nowTime.Hour - beforHour;
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

    /// <summary>
    /// 経過時間に伴うステータスの変更を行うメソッド
    /// </summary>
    void Update()
    {
     nextTime = DateTime.Now;
     //日付のまた越し判定
        if(nextTime.Day > nowTime.Day){
            beforHour = nowTime.Hour + nextTime.Hour;
            //前回と今回の経過時間を計算
            diffelence = beforHour - nowTime.Hour;
        }else{
            beforHour = nowTime.Hour;
            //前回と今回の経過時間を計算
            diffelence = nextTime.Hour - beforHour;
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

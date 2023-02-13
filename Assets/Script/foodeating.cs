using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///　@foodeating 猫のごはんを制御するスクリプト
/// 
/// 餌を設置した瞬間からこのスクリプトが動く
/// </summary>
public class foodeating : MonoBehaviour
{
    ///猫のデータベース
    public CatDataBase catdb;
    //設定したアニメーター
    public Animator PlayerAnimator;
    //進みたい場所のポジション
    private Vector3 targetpos;
    //動動かしたい猫の情報
    public GameObject cat; 
    //猫が食べ物を食べるための位置調正    
    private Vector3 nearjust = new Vector3(0.2f,0,0.2f);
    //進みたい場所    
    public Transform target;
    //座標の一時保存
    private Transform position;
    //移動スピード
    private float speed = 1.0f;

    //アップデートのループ対策
    private float count = 0;
    
    /// <summary>
    /// 食べるモーションの予備動作終了するメソッド
    /// </summary>
    public void eatrepeat (){

        print("見ていて、今から食べるよ");
        //食べるモーションの予備動作終了
        this.PlayerAnimator.SetBool("Eating",false);
        //一秒ディレイ
        Invoke("eatrepeat2",1);

        

    }
    /// <summary>
    /// 食べるモーションを開始するメソッド
    /// </summary>
    public void eatrepeat2 (){
        //食べるモーション開始
        this.PlayerAnimator.SetBool("Eating",true);
        //三秒ディレイ
        Invoke("eatrepeat3",3);
        

    }
    /// <summary>
    /// キャットデータベースの値を変更するメソッド
    /// </summary>
    public void eatrepeat3 (){
        //
        catdb.catDataList[0].interputTask = false;
        catdb.catDataList[0].hunger = 100;
        Destroy(this.gameObject);
        MissionController mi = GameObject.Find("UIDocument").GetComponent<MissionController>();
        mi.ClearValue(2,1);
    }
    
    /// <summary>
    /// 開始メソッド
    /// 必要な情報の取得を行う
    /// キャットデータベースの取得
    /// アニメータの取得
    /// 割り込み処理の有効化（interputTask）
    /// </summary>
    void Start()
    {
        //キャットデータベースの取得
        catdb = (CatDataBase)Resources.
        Load("DB/CatDB");
        cat = GameObject.FindGameObjectWithTag("cat");
        target = this.gameObject.transform;
        //アニメータの取得
        PlayerAnimator = cat.GetComponent<Animator>(); 
        //割り込み処理の有効化
        catdb.catDataList[0].interputTask = true;

        ///睡眠状態の解除
        this.PlayerAnimator.SetBool("Sleep", false);
        ///お座り状態を解除
        this.PlayerAnimator.SetBool("Sit", false);
        ///毛づくろい状態の解除
        this.PlayerAnimator.SetBool("Sit_action", false);
        this.PlayerAnimator.SetFloat("Speed", 1f);
        Invoke("eatrepeat",Time.deltaTime+6);

    }

    void Update()
    {
        var delta = target.position - cat.transform.position;

                    if(delta == Vector3.zero){
                        return;
                    }

        //進行方向の取得
         var rotation = Quaternion.LookRotation(delta, Vector3.up);

         //回転の反映
        cat.transform.rotation = rotation;

        //指定座標までの移動
        cat.transform.position = Vector3.MoveTowards(cat.transform.position,target.position - nearjust,speed * Time.deltaTime);
        if (cat.transform.position == target.position - nearjust){
            this.PlayerAnimator.SetFloat("Speed", 0);
            //アップデートのループ対策
            if(count == 0){
                count = +1;
                this.PlayerAnimator.SetBool("Eating",true);
            }
            
        } 
    }
}

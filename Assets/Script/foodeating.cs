using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodeating : MonoBehaviour
{
    public CatDataBase catdb;
    public Animator PlayerAnimator;
    private Vector3 targetpos;
    public GameObject cat; 
    private Vector3 mainas = new Vector3(0.2f,0,0.2f);
    public Transform target;
    private Transform position;
    private float speed = 1.0f;
    private float count = 0;

    public void eatrepeat (){

        print("見ていて、今から食べるよ");

        this.PlayerAnimator.SetBool("Eating",false);
        Invoke("eatrepeat2",1);

        

    }

    public void eatrepeat2 (){
        
        this.PlayerAnimator.SetBool("Eating",true);
        Invoke("eatrepeat3",3);
        

    }

    public void eatrepeat3 (){
        
        this.PlayerAnimator.SetBool("Eating",false);
        catdb.catDataList[0].interputTask = false;
        catdb.catDataList[0].hunger = 100;
        Destroy(this.gameObject);

    }
    
    void Start()
    {
        catdb = (CatDataBase)Resources.Load("DB/CatDB");
        cat = GameObject.FindGameObjectWithTag("cat");
        target = this.gameObject.transform;
        PlayerAnimator = cat.GetComponent<Animator>(); 
        catdb.catDataList[0].interputTask = true;
        
        Debug.Log("猫"+cat);
        Debug.Log("多気"+target);

        //睡眠状態の解除
        this.PlayerAnimator.SetBool("Sleep", false);
        //お座り状態を解除
        this.PlayerAnimator.SetBool("Sit", false);
        //毛づくろい状態の解除
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
        cat.transform.position = Vector3.MoveTowards(cat.transform.position,target.position - mainas,speed * Time.deltaTime);
        if (cat.transform.position == target.position - mainas){
            this.PlayerAnimator.SetFloat("Speed", 0);
            if(count == 0){
                count = +1;
                this.PlayerAnimator.SetBool("Eating",true);
            }
            
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;//使用assetstore的類型
using UnityEngine.UI;

public class BoyControl : MonoBehaviour
{
    [SerializeField] PlatformerCharacter2D character;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Transform centerOfMass;//計算腳色重心
    [SerializeField] AudioSource audioJump;
    [SerializeField] AudioSource audioCoin;
    [SerializeField] AudioSource audioChest;
    [SerializeField] Animator checkGround;//確認是否在地上
    [SerializeField] Text textTotalScore;
    [SerializeField] Text textHighScore;
    // Start is called before the first frame update
    int HighScore;
    void Start()
    {
        rigidbody.centerOfMass = centerOfMass.localPosition;
        //Position前+local取到本地座標 不要取世界座標

        if(PlayerPrefs.HasKey("High Score"))//HasKey:判斷有沒有名為High Score的Key 有就回傳true
        {
            HighScore = PlayerPrefs.GetInt("High Score");//SetInt則是儲存 可換String Float
            textHighScore.text = "最高分數 : " + HighScore;
        }
    }
    float speed;
    bool isJump;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            speed = Mathf.Lerp(speed, 1, 0.1f);//線性差值函式
        }//  改成-=可以倒退     速度上限 每次變化量
        else
        {
            speed = Mathf.Lerp(speed, 0.5f, 0.1f);
        }
        isJump = Input.GetMouseButtonDown(1);
        if (isJump&&checkGround.GetBool("Ground"))//角色動畫裡的Ground為1的時候才執行
        {
            audioJump.Play();
        }
        character.Move(speed, false, isJump);//用UnityStandardAssets._2D類型中的MOVE函式
        //             橫向移動 蹲下 跳躍
    }
    int TotalScore = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            TotalScore += 1;
            audioCoin.Play();
            Destroy(collision.gameObject);
        }else if (collision.tag == "Chest")
        {
            TotalScore += 10;
            audioChest.Play();
        }
        textTotalScore.text = "當前分數 : " + TotalScore;
        if (HighScore < TotalScore)
        {
            HighScore = TotalScore;
            textHighScore.text = "突破最高 : " + HighScore;
            //PlayerPrefs.SetInt("High Score", HighScore);     存檔 : 這程式寫在Update會不停的寫入磁碟 很傷硬碟
            //                  ("要儲存的Kye",要儲存的值)
        }
    } 
    public void SaveHighScore()//創一個公開方法讓別的腳本(EX:ReSet)來存檔
    {
        PlayerPrefs.SetInt("High Score", HighScore);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            Collider2D[] colliders = GetComponentsInChildren<Collider2D>();//GetComponentsInChildren<Collider2D>() 抓其所有子物件的Collider2D
            //因為這腳本掛在此物件最高級了 所以不用再加transform.root
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].isTrigger = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;//使用assetstore的腳本
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    [SerializeField] GameObject[] mobileBotton;//隱藏手機端按鈕用
    // Start is called before the first frame update
    int HighScore;
    void Start()
    {
        rigidbody.centerOfMass = centerOfMass.localPosition;//設定角色重心

        if(PlayerPrefs.HasKey("High Score"))//讀取最高分數
        {
            HighScore = PlayerPrefs.GetInt("High Score");
            textHighScore.text = "最高分數 : " + HighScore;
        }
        if(Application.isMobilePlatform)//判斷是否要隱藏手機端按鈕
            for(int i = 0; i < mobileBotton.Length; i++)
            {
                mobileBotton[i].SetActive(true);
            }
        else
        {
            for (int i = 0; i < mobileBotton.Length; i++)
            {
                mobileBotton[i].SetActive(false);
            }
        }
    }
    float speed;
    bool isSpeedup;
    bool isJump;
    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())//滑鼠不在UI上時才能操作
        {
            if (!Application.isMobilePlatform)//不是手機端才能PC操作
            {
                isSpeedup = Input.GetMouseButton(0);
                isJump = Input.GetMouseButtonDown(1);
            }
        }
        if (isSpeedup)//移動與跳躍
        {
            speed = Mathf.Lerp(speed, 1, 0.1f);
        }
        else
        {
            speed = Mathf.Lerp(speed, 0.5f, 0.1f);
        }
        if (isJump && checkGround.GetBool("Ground"))
        {
            audioJump.Play();
        }
        character.Move(speed, false, isJump);
        isJump = false;
    }
    
    public void Speedup()//手機端移動與跳躍
    {
        isSpeedup = true;
    }
    public void SpeedNormal()
    {
        isSpeedup = false;
    }
    public void Jump()
    {
        isJump = true;
    }
    int TotalScore = 0;
    private void OnTriggerEnter2D(Collider2D collision)//獲得分數與顯示
    {
        if (collision.tag == "Coin")//金幣
        {
            TotalScore += 1;
            audioCoin.Play();
            Destroy(collision.gameObject);
        }else if (collision.tag == "Chest")//寶箱
        {
            TotalScore += 10;
            audioChest.Play();
        }
        textTotalScore.text = "當前分數 : " + TotalScore;//顯示分數
        if (HighScore < TotalScore)
        {
            HighScore = TotalScore;
            textHighScore.text = "突破最高 : " + HighScore;
        }
    } 
    public void SaveHighScore()//讓別的腳本(ReSet)來存檔分數
    {
        PlayerPrefs.SetInt("High Score", HighScore);
    }
    private void OnCollisionEnter2D(Collision2D collision)//碰到障礙物後墜落
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].isTrigger = true;
            }
        }
    }
}

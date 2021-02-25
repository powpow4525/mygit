using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReSet : MonoBehaviour
{
    [SerializeField] GameObject reSetButton;
    [SerializeField] BoyControl boyControl;
    [SerializeField] GameObject youDied;
    [SerializeField] GameObject bg;
    [SerializeField] GameObject speedUp;
    [SerializeField] GameObject jump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)//角色死亡處理
    {
        boyControl.SaveHighScore();//呼叫腳本BoyControl裡的SaveHighScore
        reSetButton.SetActive(true);
        bg.SetActive(false);
        youDied.SetActive(true);
        speedUp.SetActive(false);
        jump.SetActive(false);
        Time.timeScale = 0;
    }
    public void RePlay()//重新載入場景
    {
        SceneManager.LoadScene("Game");
    }
}

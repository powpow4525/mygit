using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] Text textHighScore;
    int HighScore;

    void Start()
    {
        if (PlayerPrefs.HasKey("High Score"))//讀取最高分數
        {
            HighScore = PlayerPrefs.GetInt("High Score");
            textHighScore.text = "最高分數 : " + HighScore;
        }
    }

    void Update()
    {

    }
    public void GameLoad()//給開始鈕讀取遊戲場景
    {
        SceneManager.LoadScene("Game");
    }
}

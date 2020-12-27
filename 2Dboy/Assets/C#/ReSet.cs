using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReSet : MonoBehaviour
{
    [SerializeField] GameObject reSetButton;
    [SerializeField] BoyControl boyControl;
    [SerializeField] GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boyControl.SaveHighScore();//呼叫腳本BoyControl裡的SaveHighScore
        Time.timeScale = 0;
        start.SetActive(true);
        reSetButton.SetActive(true);
    }
    public void RePlay()
    {
        SceneManager.LoadScene("Game");//讀取名為Game的場景  
    }
}

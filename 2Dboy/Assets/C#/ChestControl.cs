using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    [SerializeField] Animator animatorChest;
    bool IsOpen=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)//播放動畫箱子開啟
    {
        if (collision.tag == "Boy"&&IsOpen==false)
        {
            animatorChest.SetTrigger("BoyTrigger");
            IsOpen = true;
        }
    }
}

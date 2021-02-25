using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExtension : MonoBehaviour
{
    [SerializeField] GameObject[] grassCliffCoin;
    void Start()
    {
        
    }
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞偵測生成指定物件
    {
        if (collision.name == "End")//當碰撞器碰到End的時候
        {
            GameObject clone;

            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))//物件Layer為Ground時隨機一個地板生成
            {
                clone = Instantiate(grassCliffCoin[Random.Range(0,grassCliffCoin.Length)],   
                    collision.transform.position, Quaternion.identity);
                clone.name = "GrassCliff";
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Hill"))//生成山的背景
            {
                clone = Instantiate(collision.transform.root.gameObject,
                    collision.transform.position, Quaternion.identity);
                clone.name = "Hill";
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Sky"))//生成天空背景
            {
                clone = Instantiate(collision.transform.root.gameObject,
                    collision.transform.position, Quaternion.identity);
                clone.name = "Sky";
            }
        }
    }
}

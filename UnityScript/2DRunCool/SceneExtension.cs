using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExtension : MonoBehaviour
{
    [SerializeField] GameObject[] GrassCliffCoin;
    //[SerializeField] Sprite CoinSprite; //換圖片用 38~45行
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞偵測
    {
        if (collision.name == "End")//當碰撞器碰到End的時候
        {
            GameObject clone;
            if (collision.tag == "Coin")
            {
                GameObject.Find("Chest");
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                clone = Instantiate(GrassCliffCoin[Random.Range(0,GrassCliffCoin.Length)],//隨機生成陣列中的遊戲物件         
                    collision.transform.position, Quaternion.identity);
                //                      座標      角度.歸零 改成collision.transform.rotation依據當前角度
                clone.name = "GrassCliff";
                

                
                /*Score[] scores = clone.GetComponentsInChildren<Score>();//抓有掛Score腳本元件的
                for(int i = 0; i< 3; i++)
                {
                    int index = Random.Range(0, scores.Length);
                    scores[index].GetComponent<SpriteRenderer>().sprite = CoinSprite;//將這物件的圖片更換成CoinSprite
                    //            抓元件      <圖片渲染器>    ().附檔名?= 要換成的圖片
                    scores[index].name = "Chest";
                }*/
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Hill"))
            {
                clone = Instantiate(collision.transform.root.gameObject,//複製此遊戲物件(如果物件有被改動 就是複製改動過的)
                //                                      parent上一級 root是最高級
                    collision.transform.position, Quaternion.identity);
                clone.name = "Hill";
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Sky"))
            {
                clone = Instantiate(collision.transform.root.gameObject,
                    collision.transform.position, Quaternion.identity);
                clone.name = "Sky";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExtension : MonoBehaviour
{
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
        if (collision.name == "RoadRight")
        {// 場景複製
            GameObject clone = Instantiate(collision.transform.parent.gameObject,
                //                                             parent上一級 改成root是最高級
                collision.transform.position, Quaternion.identity);
            //                      座標      角度
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject coin;//給金幣物件
    [SerializeField] GameObject chest;//給寶箱
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, 10);
        GameObject ScoreGenerate;
        if (index >= 4)
        {
            ScoreGenerate = Instantiate(coin,gameObject.transform.position, Quaternion.identity);
          //                實例化函數 (要生成的物件,生成位置,生成的角度)
        }
        else
        {
            ScoreGenerate = Instantiate(chest,gameObject.transform.position+ new Vector3(0, -0.5f, 0), Quaternion.identity);
        }//                                                                  降低寶箱高度0.5f
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

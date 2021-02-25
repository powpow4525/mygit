using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, 10);
        GameObject ScoreGenerate;
        if (index >= 4)//隨機生成寶箱或金幣
        {
            ScoreGenerate = Instantiate(coin,gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            ScoreGenerate = Instantiate(chest,gameObject.transform.position+ new Vector3(0, -0.5f, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

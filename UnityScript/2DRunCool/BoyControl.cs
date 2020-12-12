using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;//使用assetstore的類型

public class BoyControl : MonoBehaviour
{
    [SerializeField] PlatformerCharacter2D character;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Transform CenterOfMass;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.centerOfMass = CenterOfMass.localPosition;
        //Position前+local取到本地座標 不要取世界座標
    }
    float speed;
    bool isJump;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            speed = Mathf.Lerp(speed, 1, 0.1f);//線性差值函式
        }//  改成-=可以倒退     速度上限 每次變化量
        else
        {
            speed = Mathf.Lerp(speed, 0.5f, 0.1f);
        }
        isJump = Input.GetMouseButtonDown(1);
        character.Move(speed, false, isJump);//用UnityStandardAssets._2D類型中的MOVE函式
        //             橫向移動 蹲下 跳躍
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
}

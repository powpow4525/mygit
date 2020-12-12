using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoy : MonoBehaviour
{
    [SerializeField] Transform boyTransform;
    [SerializeField] float followSpeed=1;
    Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = boyTransform.position;//紀錄最開始的玩家座標
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = boyTransform.position - oldPosition;//計算與玩家差多少座標
        transform.Translate(move.x* followSpeed, 0, 0);//只移動X座標
        oldPosition = boyTransform.position;//再記錄一次玩家座標以便循環計算move
    }
}

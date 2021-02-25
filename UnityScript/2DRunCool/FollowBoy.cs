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
        oldPosition = boyTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = boyTransform.position - oldPosition;//鏡頭跟隨玩家角色
        transform.Translate(move.x* followSpeed, 0, 0);
        oldPosition = boyTransform.position;
    }
}

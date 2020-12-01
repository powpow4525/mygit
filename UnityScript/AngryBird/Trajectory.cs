using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] Transform[] spheres;//加陣列[]可以副數輸入
    [SerializeField] Transform shootBall;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }
    bool isShoot = false;//ture的時候固定描繪軌跡
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShoot = true;//停止描繪軌跡
        }
        if (!isShoot)
        {//描繪軌跡
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint
                (Input.mousePosition + new Vector3(0, 0, 10));
            Vector3 direction = worldPosition - shootBall.position;
                  //目標座標  = 滑鼠座標      - 指定物體(shootBall)座標
            Vector3 velocity = direction.normalized * 20;
            Vector3 gravity = new Vector3(0, -9.81f, 0);
            //      重力    = 向下9.81
            float t = 0.1f;//每0.1秒描繪一次
            for (int i = 0; i < spheres.Length; i++)
            {//拋物線公式ax^2+bx+c
             //ax^2=自由落體1/2GT^2=1/2*重力*時間2次方
             //bx  =每個時間點的速度=速度*時間
             //c   =指定物體的目標座標
                spheres[i].position = 0.5f * gravity * (i * t) * (i * t)
                    + velocity * (i * t) + shootBall.position;
            }
        }
    }
}

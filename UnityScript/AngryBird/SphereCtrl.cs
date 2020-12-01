using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCtrl : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.isKinematic = false;//取消後才會自由落體
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint//從畫面抓座標進來
            (Input.mousePosition/*滑鼠座標*/ + new Vector3(0, 0, 10)/*離射影機遠點不要貼著螢幕*/);
            Vector3 direction = worldPosition - transform.position;//目標座標=滑鼠座標-物體座標
            //rigidbody.velocity = direction.normalized * 20;
        }
    }
}

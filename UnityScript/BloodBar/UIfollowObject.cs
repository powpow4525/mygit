using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIfollowObject : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(target.position);
	    本體座標	       = 遊戲座標轉螢幕座標		       (要跟隨物體的座標)
    }
}

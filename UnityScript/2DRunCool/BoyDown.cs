using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] colliders = transform.root.GetComponentsInChildren<Collider2D>();
        //                                 回最高級 抓所有子物件的Component<要抓的對象> 
        for(int i = 0; i< colliders.Length; i++)
        {
            colliders[i].isTrigger = true;
        }
    }
}

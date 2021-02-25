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
    private void OnCollisionEnter2D(Collision2D collision)//身體碰到障礙物後墜落
    {
        Collider2D[] colliders = transform.root.GetComponentsInChildren<Collider2D>();
        for(int i = 0; i< colliders.Length; i++)
        {
            colliders[i].isTrigger = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    private Animator chestAnimator;
    bool IsOpen=false;
    // Start is called before the first frame update
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boy"&&IsOpen==false)
        {
            chestAnimator.SetTrigger("BoyTrigger");
            IsOpen = true;
        }
    }
}

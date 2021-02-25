using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)//移除不用的地板與寶箱
    {
        if (collision.name == "End")
        {
            Destroy(collision.transform.root.gameObject);
        }
        if (collision.name == "Chest")
        {
            Destroy(collision.transform.root.gameObject);
        }
    }
}

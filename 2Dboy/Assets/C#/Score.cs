using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, 10);
        GameObject G8der;
        if (index >= 5)
        {
            G8der=Instantiate(coin,this.gameObject.transform.position, Quaternion.identity);
            G8der.transform.parent = this.gameObject.transform;
            //G8der.transform.position = Vector3.zero;
        }
        else
        {
            G8der=Instantiate(chest,this.gameObject.transform.position, Quaternion.identity);
            G8der.transform.parent = this.gameObject.transform;
            //G8der.transform.position = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

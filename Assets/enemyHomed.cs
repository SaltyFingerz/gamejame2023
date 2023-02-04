using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHomed : MonoBehaviour
{
    public static Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("now");
            if(other != null)
            target.position = other.gameObject.transform.position;
        }
    }

}

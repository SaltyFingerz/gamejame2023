using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parsnipHoming : MonoBehaviour
{
private Transform target;
    public float speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!target)
        target = SpecialAttack.target;

        else if (target)
        {
            // target = GameObject.FindGameObjectWithTag("Enemy").transform;
            var step = speed * Time.deltaTime; // calculate distance to move
            if (target.transform.position != null)
                transform.position.Set(Mathf.Lerp(transform.position.x, target.transform.position.x, step), Mathf.Lerp(transform.position.y, target.transform.position.y, step), Mathf.Lerp(transform.position.z, target.transform.position.z, step));
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            {
                print("skfj");
                target = other.gameObject.transform;
            }

        }
    }
}

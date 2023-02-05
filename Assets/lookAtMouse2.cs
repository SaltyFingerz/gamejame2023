using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMouse2 : MonoBehaviour
{
    ParticleSystem garlicBreath;
    public Transform target;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GarlicBreath.cannotBreath) { 
         targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            }

        if (target != null)
        {
            print("targetnotNull");
            transform.LookAt(targetPosition); //makes the enemy look at the target/mouse

        }
    }
}

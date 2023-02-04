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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GarlicBreath.cannotBreath) { 
         targetPosition = new Vector3(target.transform.position.x, transform.position.y-1, target.transform.position.z);
            }

        if (target != null)
        {

            transform.LookAt(targetPosition); //makes the enemy look at the player. This line of code was learnt from the tutorial available at: www.youtube.com/watch?v=rP_bEq248e4

        }
    }
}

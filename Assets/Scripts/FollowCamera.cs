using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float offset;
    [SerializeField] private float smoothing = 0.0001f;


    // Update is called once per frame
    void LateUpdate()
    {
        //If player is connected
        if (player)
        {
            //Follow player
            transform.position = player.transform.position;
            Transform requiredTf = transform;
            requiredTf.Translate(Vector3.forward * -offset);

            transform.position = Vector3.MoveTowards(transform.position,requiredTf.position,smoothing*Time.deltaTime);
        }
    }
}

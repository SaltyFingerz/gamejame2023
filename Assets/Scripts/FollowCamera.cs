using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
[SerializeField] public GameObject player;
    [SerializeField] private float offset;


    // Update is called once per frame
    void LateUpdate()
    {
        //If player is connected
        if (player)
        {
            //Follow player
            transform.position = player.transform.position;
            transform.Translate(Vector3.forward * -offset);
        }
    }
}

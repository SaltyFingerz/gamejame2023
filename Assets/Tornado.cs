using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float timeToFollowPlayer = 3;
    public float Speed = 3;
    public float Strenght = 5;
    public float PullStrength = 8;

    GameObject player;
    bool playerGrabbed = false;
    float currentTimeToFollow;
    Vector3 currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeToFollow = timeToFollowPlayer;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (currentTimeToFollow <= 0)
            {
                Vector3 newPos;
                newPos = transform.position + currentDirection * Speed * Time.deltaTime;
                transform.position = newPos;
            }
            else
            {
                Vector3 previousPos = transform.position;

                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);

                currentDirection = transform.position - previousPos;
                currentDirection.Normalize();

                currentTimeToFollow -= Time.deltaTime;
            }

            if (playerGrabbed)
            {
                currentTimeToFollow = 0;
                player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, PullStrength * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            if (other.CompareTag("Player"))
            {
                playerGrabbed = true;
            }

            if (!other.CompareTag("Player") && !other.CompareTag("Ground") && !other.CompareTag("Enemy"))
            {
                if (playerGrabbed)
                {
                    player.GetComponent<PlayerController>().TakeDamage(Strenght);
                }
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            if (other.CompareTag("Player"))
            {
                playerGrabbed = false;
            }
        }
    }
}

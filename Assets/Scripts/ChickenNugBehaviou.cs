using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenNugBehaviou : MonoBehaviour
{
    public float Strength = 5;
    public float Speed = 2;
    public float AttackCooldown = 2;

    public GameObject player;
    bool isPlayerInRange = false;
    private float currentCooldown=0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = Vector3.zero, newPosition = Vector3.zero;
        if (player)
        {
            oldPosition = transform.position;
            currentCooldown -= Time.deltaTime;
            if (isPlayerInRange)
            {
                if (currentCooldown <= 0)
                {
                    //CHICKEN NUGGE ATTACK ANIMATION
                    player.GetComponent<PlayerController>().TakeDamage(Strength);
                    currentCooldown = AttackCooldown;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
            }
            newPosition = transform.position;

            if (newPosition.x > oldPosition.x)
            {
                //Nugge is moving to the right ANIMATION
            }
            else if (newPosition.x < oldPosition.x)
            {
                //Nugge is moving to the left ANIMATION
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}

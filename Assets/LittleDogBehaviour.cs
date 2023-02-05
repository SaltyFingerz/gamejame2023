using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDogBehaviour : MonoBehaviour
{
    public float Speed = 10;
    public float Strength = 5;
    public Vector3 targetLocation;
    public GameObject warningPrefab;

    private GameObject player;
    private GameObject warning;
    // Start is called before the first frame update
    void Start()
    {
        warning = Instantiate(warningPrefab, targetLocation, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,targetLocation)<=1)
        {
            //Explode
            if(player)
            {
                player.GetComponent<PlayerController>().TakeDamage(Strength);

            }                
            Destroy(warning);
            Destroy(gameObject);
        }
        else
        {
            //Move
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            if (other.CompareTag("Player"))
            {
                player = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            if (other.CompareTag("Player"))
            {
                player = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(Strength);
            Destroy(warning);
            Destroy(gameObject);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePath : MonoBehaviour
{
    public float Strength = 1;
    public float timeDamageIntervals = 1;
    public float lifespan=5;

    private float currentLifespan;
    private float currentDamageInterval;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentDamageInterval = timeDamageIntervals;
        currentLifespan = lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldDamage = false;
        currentDamageInterval -= Time.deltaTime;
        currentLifespan -= Time.deltaTime;
        if(currentDamageInterval <= 0)
        {
            shouldDamage = true;
            currentDamageInterval = timeDamageIntervals;
        }
        else
        {
            shouldDamage = false;
        }

        if(player)
        {
            if(shouldDamage)
            {
                player.GetComponent<PlayerController>().TakeDamage(Strength);
            }
        }

        if(currentLifespan<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
        {
            if(other.CompareTag("Player"))
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
}

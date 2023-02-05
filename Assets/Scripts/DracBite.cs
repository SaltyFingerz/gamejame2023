using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracBite : MonoBehaviour
{
    public int zoomTimes = 3;
    public float cooldownBetweenZooms = 2;
    public float Strength = 2;
    public float LeachedHealth = 2;
    public float zoomSpeed=10;

    float currentZoomCooldown;
    int currentAmountOfZooms;
    private GameObject player;
    bool AttackInProgress = false;
    Vector3 originalPos;
    bool isZooming = false;
    Vector3 nextLockedPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackInProgress)
        {
            if (currentZoomCooldown <= 0)
            {
                if (currentAmountOfZooms <= zoomTimes)
                {
                    isZooming = true;
                }
                else
                {
                    AttackInProgress = false;
                }
                currentZoomCooldown = cooldownBetweenZooms;
            }
            else
            {
                currentZoomCooldown -= Time.deltaTime;
            }

            if(isZooming)
            {
                if(currentAmountOfZooms==zoomTimes)
                {
                    transform.position = Vector3.MoveTowards(transform.position, originalPos, zoomSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextLockedPos, zoomSpeed * Time.deltaTime);
                }

                if(Vector3.Distance(transform.position,nextLockedPos)<1)
                {
                    currentAmountOfZooms++;
                    isZooming = false;
                    nextLockedPos = player.transform.position;
                }
            }
        }
    }

    public void Attack()
    {
        AttackInProgress = true;
        currentAmountOfZooms = 0;
        currentZoomCooldown = cooldownBetweenZooms;
        originalPos = transform.position;
        nextLockedPos = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
        {
            if(other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().TakeDamage(Strength);
                GetComponentInParent<HotDogulaBehaviour>().LeechHealth(LeachedHealth);
            }
        }
    }
}

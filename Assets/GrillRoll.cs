using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillRoll : MonoBehaviour
{
    public GameObject HotDogula;
    public GameObject HottDogToSpawn;

    private Vector3 dogulaOriginalPosition;
    private RollDirection attackDirection;
    private BoxCollider box;
    bool AttackInProgress = false;
    int randomLane;
    GameObject spawnedHottDog;
    bool hottSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        attackDirection = (RollDirection)Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackInProgress)
        {
            if (!hottSpawned)
            {
                Vector3 hottSpawnPoint;
                hottSpawnPoint.y = dogulaOriginalPosition.y;
                if (attackDirection == RollDirection.Up)
                {
                    hottSpawnPoint.z = transform.position.z - box.size.z / 2 + 3;
                }
                else
                {
                    hottSpawnPoint.z = transform.position.z + box.size.z / 2 - 3;
                }
                hottSpawnPoint.x = transform.position.x + randomLane * box.size.x / 2;

                spawnedHottDog = Instantiate(HottDogToSpawn, hottSpawnPoint, Quaternion.identity);
                spawnedHottDog.GetComponent<HottDogBehaviour>().direction = attackDirection;
                hottSpawned = true;
            }
            else
            {
                if(!spawnedHottDog)
                {
                    AttackInProgress = false;
                    hottSpawned = false;
                    spawnedHottDog = null;
                }
            }
        }
    }

    public void Attack()
    {
        AttackInProgress = true;
        dogulaOriginalPosition = HotDogula.transform.position;
        attackDirection = (RollDirection)Random.Range(0, 2);

        Vector3 dogulaNewPos;
        dogulaNewPos.x = transform.position.x;
        dogulaNewPos.y = dogulaOriginalPosition.y;
        if (attackDirection == RollDirection.Up)
        {
            dogulaNewPos.z = transform.position.z - box.size.z / 2;
        }
        else
        {
            dogulaNewPos.z = transform.position.z + box.size.z / 2;
        }
        HotDogula.transform.position = dogulaNewPos;
        randomLane = Random.Range(-1, 2);
    }
}

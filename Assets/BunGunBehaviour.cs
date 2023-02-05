using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunGunBehaviour : MonoBehaviour
{
    public int AmountOfSausagesToShoot = 5;
    public float generalTimeBetweenShots=1;
    public GameObject littleDogiesToShoot;
    public GameObject dogula;

    private List<Vector3> shootingLocations = new List<Vector3>();
    private int sausagesShot = 0;
    bool AttackInProgress = false;
    float currentTimeBetweenShots = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeBetweenShots = generalTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackInProgress)
        {
            currentTimeBetweenShots -= Time.deltaTime;
            if(sausagesShot<AmountOfSausagesToShoot/2)
            {
                if(currentTimeBetweenShots<=0)
                {
                    if (littleDogiesToShoot)
                    {
                        SpawnDoggie();
                    }
                    currentTimeBetweenShots = generalTimeBetweenShots;
                }
            }
            else
            {
                if(currentTimeBetweenShots<=generalTimeBetweenShots/2)
                {
                    SpawnDoggie();
                    currentTimeBetweenShots = generalTimeBetweenShots;
                }
            }
        }
    }

    public void Attack()
    {
        for(int i = 0; i<AmountOfSausagesToShoot;i++)
        {
            Vector3 newRandomPos;
            newRandomPos.y = transform.position.y;
            newRandomPos.x = Random.Range(GetComponent<BoxCollider>().bounds.min.x, GetComponent<BoxCollider>().bounds.max.x);
            newRandomPos.z = Random.Range(GetComponent<BoxCollider>().bounds.min.z, GetComponent<BoxCollider>().bounds.max.z);
            shootingLocations.Add(newRandomPos);
        }

        AttackInProgress = true;
    }

    void SpawnDoggie()
    {
        GameObject newDoggie = Instantiate(littleDogiesToShoot, dogula.transform.position, Quaternion.identity);
        newDoggie.GetComponent<LittleDogBehaviour>().targetLocation = shootingLocations[sausagesShot];
        sausagesShot++;
        if(sausagesShot>=AmountOfSausagesToShoot)
        {
            AttackInProgress = false;
            sausagesShot = 0;
            currentTimeBetweenShots = generalTimeBetweenShots;
            shootingLocations.Clear();
        }
    }
}

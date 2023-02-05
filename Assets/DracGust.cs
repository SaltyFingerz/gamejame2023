using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracGust : MonoBehaviour
{
    public GameObject TornadoToSpawn;
    public int AmountOfTornadosToSpawn = 2;

    GameObject spawnedTornado;
    bool AttackInProgress = false;
    int currentAmountOfTornadosSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackInProgress)
        {
            if(currentAmountOfTornadosSpawned<AmountOfTornadosToSpawn)
            {
                if(!spawnedTornado)
                {
                    spawnedTornado = Instantiate(TornadoToSpawn, transform.position,Quaternion.identity);
                    currentAmountOfTornadosSpawned++;
                }
            }
        }
    }

    public void Attack()
    {
        AttackInProgress = true;
        currentAmountOfTornadosSpawned = 0;
        spawnedTornado = null;
    }
}

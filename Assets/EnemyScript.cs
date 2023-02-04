using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int enemyHealth = 5;
    bool enemyVulnerableToBreath = true;
    bool enemyVulnerableToSnips = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnParticleCollision(GameObject TargetedParticle)
    {
        if (enemyVulnerableToBreath && TargetedParticle.CompareTag("garlic"))
            StartCoroutine(damageEnemyGarl());
        else if (enemyVulnerableToSnips && TargetedParticle.CompareTag("snips"))
            StartCoroutine(damageEnemySnips());
        
    }

    IEnumerator damageEnemyGarl()
    {
        print("damagingenemy");
        enemyHealth -= 1;
        enemyVulnerableToBreath = false;
        yield return new WaitForSeconds(1);
        enemyVulnerableToBreath = true;

    }


    IEnumerator damageEnemySnips()
    {
        print("damagingenemy");
        enemyHealth -= 4;
        enemyVulnerableToSnips = false;
        yield return new WaitForSeconds(2);
        enemyVulnerableToSnips = true;
    }

    }

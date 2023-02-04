using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5;
    bool enemyVulnerableToBreath = true;
    bool enemyVulnerableToSnips = true;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    //Returns false if object is dead
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
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
        currentHealth -= 1;
        enemyVulnerableToBreath = false;
        yield return new WaitForSeconds(1);
        enemyVulnerableToBreath = true;

    }


    IEnumerator damageEnemySnips()
    {
        print("damagingenemy");
        currentHealth -= 4;
        enemyVulnerableToSnips = false;
        yield return new WaitForSeconds(2);
        enemyVulnerableToSnips = true;
    }

}

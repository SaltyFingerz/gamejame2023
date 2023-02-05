using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AttackEnum { BunGun, GrillRoll, DracBite, DracGust, None}
public class HotDogulaBehaviour : MonoBehaviour
{
    public GameObject BunAttackRange;
    public GameObject GrillRollRange;
    public float maxHealth = 100;
    public float TranformationHealth = 50;
    public float AttackCooldown = 7;

    private float currentHealth;
    private float currentAttackCooldown=0;
    private AttackEnum currentAttack;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //currentAttackCooldown = AttackCooldown;
        currentAttack = AttackEnum.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAttackCooldown <= 0)
        {
            if (maxHealth > TranformationHealth)
            {
                currentAttack = (AttackEnum)Random.Range(0, 1);
            }
            else
            {
                currentAttack = (AttackEnum)Random.Range(0, 4);
            }

            currentAttackCooldown = AttackCooldown;
        }
        else
        {
            currentAttackCooldown -= Time.deltaTime;
        }

        switch (currentAttack)
        {
            case AttackEnum.BunGun:
                BunAttackRange.GetComponent<BunGunBehaviour>().dogula = gameObject;
                BunAttackRange.GetComponent<BunGunBehaviour>().Attack();
                break;

            case AttackEnum.GrillRoll:
                GrillRollRange.GetComponent<GrillRoll>().HotDogula = gameObject;
                GrillRollRange.GetComponent<GrillRoll>().Attack();
                break;

            case AttackEnum.DracBite:
                GetComponent<DracBite>().Attack();
                break;

            case AttackEnum.DracGust:
                GetComponent<DracGust>().Attack();
                break;
        }
        currentAttack = AttackEnum.None;
    }

    public void LeechHealth(float amount)
    {
        GetComponent<Enemy>().AddHealth(amount);
    }
}
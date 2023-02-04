using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPunchRangeBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponentInParent<Beetroot>().AddEnemyToGroundPunchRange(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponentInParent<Beetroot>().RemoveEnemyToGroundPunchRange(other.gameObject);
        }
    }
}

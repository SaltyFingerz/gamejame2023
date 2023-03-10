using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchRangeBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !other.isTrigger)
        {
            GetComponentInParent<Beetroot>().AddEnemyToPunchRange(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && !other.isTrigger)
        {
            GetComponentInParent<Beetroot>().RemoveEnemyToPunchRange(other.gameObject);
        }
    }
}

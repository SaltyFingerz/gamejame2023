using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDetectionRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<ChickenNugBehaviou>().isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<ChickenNugBehaviou>().isPlayerInRange = false;
        }
    }
}

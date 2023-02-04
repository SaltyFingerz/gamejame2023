using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDetectionRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<ChickenNugBehaviou>().player = other.gameObject;
        }
    }
}

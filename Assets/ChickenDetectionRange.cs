using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDetectionRange : MonoBehaviour
{
    public AudioClip aggroSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<ChickenNugBehaviou>().isPlayerInRange = true;
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(aggroSound);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Trigger : MonoBehaviour
{
    public GameObject Tutorial_To_View;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Tutorial_To_View.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Tutorial_To_View.SetActive(false);
        }
    }
}

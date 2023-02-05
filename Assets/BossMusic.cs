using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    public GameObject bossBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("play");
           // GameObject.FindWithTag("music").SetActive(false);
            GetComponent<AudioSource>().Play();
            bossBar.SetActive(true);
        }
    }
}

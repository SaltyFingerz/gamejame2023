using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Loader : MonoBehaviour
{
    public GameObject Tutorial_OnLoad;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial_OnLoad.SetActive(true);
        StartCoroutine(removeUI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator removeUI()
    {
        yield return new WaitForSeconds(5f);
        Tutorial_OnLoad.SetActive(false);
    }
}

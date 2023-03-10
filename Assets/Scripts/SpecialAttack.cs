using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public ParticleSystem parsnipAttack;
    //public GameObject singleParsnip;
    public static Transform target;
    bool canSnip = true;
    public GameObject SnipUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.F) && canSnip)
        {
            // singleParsnip.gameObject.SetActive(true);
            // singleParsnip.transform.position = transform.position;

            StartCoroutine(snipOut());
        }

       if(canSnip)
        {
            SnipUI.SetActive(true);

        }
       else
            SnipUI.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            target = other.transform;
        }
    }

    IEnumerator snipOut()
    {
        parsnipAttack.Play();
        canSnip = false;
        yield return new WaitForSeconds(13);
        canSnip = true;

    }
}

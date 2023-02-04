using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogula : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30;
    private float currentHealth = 30;
    Animator DogulaAnimator;
    // Start is called before the first frame update
    void Start()
    {
        DogulaAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 30)
        {
            print("healthlessthan30");
           DogulaAnimator.SetTrigger("Transform");
        }
    }

  
}

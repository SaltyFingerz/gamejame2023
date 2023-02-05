using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBreath : MonoBehaviour
{

    public ParticleSystem breathAttack;
    public static bool cannotBreath;
    Animator GarlAnimator;
    public GameObject Renderer;

    // Start is called before the first frame update
    void Start()
    {
        GarlAnimator = Renderer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !cannotBreath)
        {
            StartCoroutine(breathOut());
            
        }
       
    }

    IEnumerator breathOut()
    {
        breathAttack.Play();
        GarlAnimator.SetTrigger("Attack");
        cannotBreath = true;
        yield return new WaitForSeconds(2);
        cannotBreath = false;

    }
}

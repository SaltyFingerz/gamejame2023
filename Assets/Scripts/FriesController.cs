using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesController : MonoBehaviour
{
    public float Strength = 2;
    public float MovementSpeed = 5;
    public float DiveSpeed = 20;
    public float DiveRange = 5;
    private GameObject player;
    Animator FryAnimator;
    bool isLocked = false;
    Vector3 lockedPosition;
    public GameObject Renderer;
    public AudioClip deathSquish;
    // Start is called before the first frame update
    void Start()
    {
        FryAnimator = Renderer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = Vector3.zero, newPosition = Vector3.zero;
        if (player)
        {
            oldPosition = transform.position;
            if (!isLocked)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MovementSpeed * Time.deltaTime);
                if(Vector3.Distance(transform.position,player.transform.position) <= DiveRange)
                {
                 
                    isLocked = true;
                    lockedPosition = player.transform.position;
                    FryAnimator.SetTrigger("Jump");
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, lockedPosition, DiveSpeed * Time.deltaTime);
            }
            newPosition = transform.position;
        }

        Vector3 characterScale = transform.localScale;

        if(newPosition.x > oldPosition.x)
        {
            
            Renderer.GetComponent<SpriteRenderer>().flipX = false;
            FryAnimator.SetTrigger("Walk");
            characterScale.x = 1;
        }
        else if (newPosition.x < oldPosition.x)
        {
            
            Renderer.GetComponent<SpriteRenderer>().flipX = true;
            FryAnimator.SetTrigger("Walk");
            characterScale.x = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isLocked)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                return;
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(Strength);
        }
        //Frie Dies ANIMATION
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(deathSquish);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(dontDieYet());
    }

    IEnumerator dontDieYet()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

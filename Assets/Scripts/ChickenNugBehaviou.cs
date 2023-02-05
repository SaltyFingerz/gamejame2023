using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenNugBehaviou : MonoBehaviour
{
    public float Strength = 5;
    public float Speed = 2;
    public float AttackCooldown = 2;

    public GameObject player;
    public bool isPlayerInRange = false;
    private float currentCooldown=0;
    Animator NugAnimator;
    public GameObject Renderer;
    // Start is called before the first frame update
    void Start()
    {
        NugAnimator = Renderer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = Vector3.zero, newPosition = Vector3.zero;
        if (player)
        {
            oldPosition = transform.position;
            currentCooldown -= Time.deltaTime;
            if (isPlayerInRange)
            {
                if (currentCooldown <= 0)
                {
                    NugAnimator.SetTrigger("Attack");
                    player.GetComponent<PlayerController>().TakeDamage(Strength);
                    currentCooldown = AttackCooldown;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
            }
            newPosition = transform.position;

            if (newPosition.x > oldPosition.x)
            {
                Renderer.GetComponent<SpriteRenderer>().flipX = false;
                NugAnimator.SetTrigger("Walk");
            }
            else if (newPosition.x < oldPosition.x)
            {
                Renderer.GetComponent<SpriteRenderer>().flipX = true;
                NugAnimator.SetTrigger("Walk");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<ChickenNugBehaviou>().player = other.gameObject;
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RollDirection { Up, Down};
public class HottDogBehaviour : MonoBehaviour
{
    public float Strength = 5;
    public float Speed = 5;
    public RollDirection direction;
    public float CoolldownBeforRoll = 0;
    public GameObject firePath;

    private float currentCooldown=0;
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = CoolldownBeforRoll;
        Instantiate(firePath, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown<=0)
        {
            Vector3 newPos = transform.position;
            if(direction==RollDirection.Up)
            {
               newPos.z = transform.position.z + Speed * Time.deltaTime;
            }
            else
            {
                newPos.z = transform.position.z - Speed * Time.deltaTime;
            }
            transform.position = newPos;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("FirePath"))
        {
            //Spawn New Fire Path
            Instantiate(firePath, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ground"))
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(Strength);
            }
            Destroy(gameObject);
        }
    }
}

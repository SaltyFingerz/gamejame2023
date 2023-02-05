using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FacingDirection { Right, Left};
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementConstant = 7f;
    [Range(0, 0.05f)] [SerializeField] private float movementSmoothing = .001f;
    Rigidbody playerRigidBody;
    [SerializeField]private float maxHealth = 25;
    public GameObject Renderer;
    private float CurrentHealth;
    public FacingDirection facing;

    public AudioClip deathSquish;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        CurrentHealth = maxHealth;
        facing = FacingDirection.Right;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputVector = Vector3.ClampMagnitude(inputVector, 1f);

        Vector3 movementVector = inputVector * movementConstant;
        Vector3 redundantVelocity = Vector3.zero;
        playerRigidBody.velocity = Vector3.SmoothDamp(playerRigidBody.velocity, movementVector, ref redundantVelocity, movementSmoothing);

        if(playerRigidBody.velocity.x>0)
        {
            Renderer.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            facing = FacingDirection.Right;
        }
        else if (playerRigidBody.velocity.x<0)
        {
            Renderer.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            facing = FacingDirection.Left;
        }

       /*if(facing == FacingDirection.Left)
        {
            Renderer.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (facing == FacingDirection.Right)
        {
            Renderer.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }*/

    }
    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            StartCoroutine(dontDieYet());
        }
    }
    public GameObject DeathMenu;
    IEnumerator dontDieYet()
    {
        DeathMenu.SetActive(!DeathMenu.activeSelf);
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(deathSquish);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetroot : MonoBehaviour
{
    [SerializeField] private float PunchDamage = 5;
    [SerializeField] private GameObject PunchRange;

    [SerializeField] private float GroundPunchDamage = 10;

    private List<GameObject> PunchRangeEnemies = new List<GameObject>();
    private List<GameObject> GroundPunchRangeEnemies = new List<GameObject>();
    public GameObject Renderer;
    Animator BeetAnimator;

    public AudioClip punchSound;
    public AudioClip groundSound;
    public float PunchCooldown = 0.8f;
    public float GroundPunchCooldown = 2;

    float currentPunchCooldown = 0;
    float currentGroundPunchCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        BeetAnimator = Renderer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPunchCooldown -= Time.deltaTime;
        GroundPunchCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (currentPunchCooldown <= 0)
            {
                MainAttack(Input.mousePosition);
                currentPunchCooldown = PunchCooldown;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentGroundPunchCooldown <= 0)
            {
                SecondaryAttack();
                BeetAnimator.SetTrigger("Ground");

                AudioSource ac = GetComponent<AudioSource>();
                ac.PlayOneShot(groundSound);
                currentGroundPunchCooldown = GroundPunchCooldown;
            }
        }

        if (GroundPunchRangeEnemies.Count > 0)
        {
            if (!GroundPunchRangeEnemies[GroundPunchRangeEnemies.Count - 1])
            {
                GroundPunchRangeEnemies.RemoveAt(GroundPunchRangeEnemies.Count - 1);
            }
        }

        if (PunchRangeEnemies.Count > 0)
        {
            if (!PunchRangeEnemies[PunchRangeEnemies.Count - 1])
            {
                PunchRangeEnemies.RemoveAt(PunchRangeEnemies.Count - 1);
            }
        }
    }

    public void AddEnemyToPunchRange(GameObject enemy)
    {
        PunchRangeEnemies.Add(enemy);
    }

    public void AddEnemyToGroundPunchRange(GameObject enemy)
    {
        GroundPunchRangeEnemies.Add(enemy);
    }
    public void RemoveEnemyToPunchRange(GameObject enemy)
    {
        PunchRangeEnemies.Remove(enemy);
    }

    public void RemoveEnemyToGroundPunchRange(GameObject enemy)
    {
        GroundPunchRangeEnemies.Remove(enemy);
    }

    void MainAttack(Vector3 mousePos)
    {
        foreach (GameObject enemy in PunchRangeEnemies)
        {
            if (enemy)
            {


                if (mousePos.x - Screen.width / 2 >= 0)
                {
                    //Right
                    if (enemy.transform.position.x >= transform.position.x)
                    {
                        print("punch");
                        enemy.GetComponent<Enemy>().TakeDamage(PunchDamage);
                      //  BeetAnimator.SetTrigger("PunchR");
                        GetComponent<PlayerController>().facing = FacingDirection.Right;
                    }

                }
                else
                {
                    //Left
                    if (enemy.transform.position.x < transform.position.x)
                    {
                        print("punch");
                        enemy.GetComponent<Enemy>().TakeDamage(PunchDamage);
                       // BeetAnimator.SetTrigger("PunchL");

                        GetComponent<PlayerController>().facing = FacingDirection.Left;
                    }
                }
              
            }
             
            
        }
          if (PunchRangeEnemies.Count == 0 && GetComponent<PlayerController>().facing == FacingDirection.Left) 
            {
                if (mousePos.x - Screen.width / 2 >= 0)
                    BeetAnimator.SetTrigger("PunchR");
                else
                    BeetAnimator.SetTrigger("PunchL");

            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(punchSound);
        } 
          else
        {
            if (mousePos.x - Screen.width / 2 >= 0)
                BeetAnimator.SetTrigger("PunchL");
            else
                BeetAnimator.SetTrigger("PunchR");
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(punchSound);
        }
        //Animation
    }

    void SecondaryAttack()
    {
        foreach (GameObject enemy in GroundPunchRangeEnemies)
        {
            if (enemy)
            {
                enemy.GetComponent<Enemy>().TakeDamage(GroundPunchDamage);
            }
        }
    }
}

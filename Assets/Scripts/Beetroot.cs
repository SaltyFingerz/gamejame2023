using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetroot : MonoBehaviour
{
    [SerializeField] private float PunchDamage = 5;
    [SerializeField] private GameObject PunchRange;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float GroundPunchDamage = 10;
    [SerializeField] private GameObject GroundPunchRange;

    private List<GameObject> PunchRangeEnemies = new List<GameObject>();
    private List<GameObject> GroundPunchRangeEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MainAttack(Input.mousePosition);
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            SecondaryAttack();
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
                if(Mathf.Abs(mousePos.x - Screen.width/2) > Mathf.Abs(mousePos.y - Screen.height / 2))
                {
                    if(mousePos.x - Screen.width / 2>=0)
                    {
                        //Right
                        if(enemy.transform.position.x >= transform.position.x)
                        {
                            enemy.GetComponent<Enemy>().TakeDamage(PunchDamage);
                        }                        

                    }
                    else
                    {
                        //Left
                        if (enemy.transform.position.x < transform.position.x)
                        {
                            enemy.GetComponent<Enemy>().TakeDamage(PunchDamage);
                        }
                    }
                }
                else
                {
                    if (mousePos.y - Screen.height / 2 <= 0)
                    {
                        //Down
                        if (enemy.transform.position.z <= transform.position.z)
                        {
                            enemy.GetComponent<Enemy>().TakeDamage(PunchDamage);
                        }
                    }
                    else
                    {
                        //Up
                        if (enemy.transform.position.z > transform.position.z)
                        {
                            enemy.GetComponent<Enemy>().TakeDamage(PunchDamage);
                        }
                    }
                }
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public Image HealthBar;
    public float DisplayCurrentHealth;
    public float MaximumHealth = 30f;
    public GameObject dogula;
    public GameObject DogulaName;
    public GameObject AlugodName;


    private void Start()
    {
        DogulaName.SetActive(true);
        AlugodName.SetActive(false);

        HealthBar = GetComponent<Image>();
       
    }

    private void Update()
    {
        DisplayCurrentHealth = dogula.GetComponent<Enemy>().GetHealth();
        HealthBar.fillAmount = DisplayCurrentHealth / MaximumHealth;
        if (DisplayCurrentHealth <= 70f)
        {
            DogulaName.SetActive(false);
            AlugodName.SetActive(true);
            
        }
      
    }
}

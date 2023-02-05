using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Bar_Script : MonoBehaviour
{
    public Image HealthBar;
    public float DisplayCurrentHealth;
    public float MaximumHealth = 25f;
    public GameObject Dogula;
    public GameObject Alugod;
    //PlayerController Player;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
      //  Player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
      // DisplayCurrentHealth = Player.GetCurrentHealth();
      // HealthBar.fillAmount = DisplayCurrentHealth / MaximumHealth;
      if (DisplayCurrentHealth == (1/2 * MaximumHealth))
            {
            Dogula.SetActive(!Dogula.activeSelf);
            Alugod.SetActive(!Alugod.activeSelf);

        }
    }

}

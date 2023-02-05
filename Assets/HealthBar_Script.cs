using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{
    public Image HealthBar;
    public float DisplayCurrentHealth;
    public float MaximumHealth = 15f;
    PlayerController Player;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        DisplayCurrentHealth = Player.GetCurrentHealth();
        HealthBar.fillAmount = DisplayCurrentHealth / MaximumHealth;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthBar = default;
    public static Healthbar instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Updates the healthbar according to the players health;
    /// </summary>
    /// <param name="health"></param>
    public void UpdateHealthBar(float health)
    {
        healthBar.fillAmount = health / 100f;
    }
}

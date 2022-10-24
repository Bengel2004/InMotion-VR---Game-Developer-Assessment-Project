using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthBarParent = default;
    [SerializeField] private Image healthBar = default;
    public static Healthbar instance = null;

    private float defaultBarsize = 13.5f;
    private float currentIncrementedBarSize = 0f;
    private float barSizeIncrement = 2.25f;

    // 13.5 + 2.25
    // 13.5 was tested to work best in editor. 2.25 workst best for the current segment setup.
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
    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthBar.fillAmount = health / maxHealth;
    }

    /// <summary>
    /// Adds another health segment to the healthbar.
    /// </summary>
    public void IncreaseHealthbarHealth()
    {
        currentIncrementedBarSize += barSizeIncrement;
        healthBarParent.pixelsPerUnitMultiplier = defaultBarsize + currentIncrementedBarSize;
    }
}

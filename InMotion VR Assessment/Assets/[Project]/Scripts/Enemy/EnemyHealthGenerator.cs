using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyHealthGenerator
{
    /* Research has shown that if the health of enemies vary, players may precieve them as stronger or weaker as they are "harder to kill".
     * This was scientifically proven by the Developers of Halo.
     */
    public float minHealth = 100f;
    public float maxHealth = 100f;

    public float GenerateRandomizedHealth()
    {
        return Mathf.Round(Random.Range(minHealth, maxHealth));
    } 
}

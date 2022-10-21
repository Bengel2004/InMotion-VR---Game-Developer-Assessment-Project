using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NielsDev.Objects;

public class EnemySwarm : MonoBehaviour
{
    [SerializeField] private Enemy_Ship[] swarmShips = default;
    private int swarmCount = 0;

    private void Start()
    {
        swarmShips = transform.GetComponentsInChildren<Enemy_Ship>();
    }

    private void OnEnable()
    {
        ResetSwarm();
        swarmCount = transform.childCount;
    }

    /// <summary>
    /// Updates the swarmcount, if a ship dies it removes a number. If no ships are left, a new swarm gets respawned.
    /// </summary>
    public void UpdateSwarm()
    {
        swarmCount--;
        if(swarmCount == 0)
        {
            WaveSpawner.instance.GenerateNewSwarm();
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Resets the swarm so all ships are "respawned".
    /// </summary>
    public void ResetSwarm()
    {
        foreach(Enemy_Ship ship in swarmShips)
        {
            ship.ResetObject();
        }
    }
}

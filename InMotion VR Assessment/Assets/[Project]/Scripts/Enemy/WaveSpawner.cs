using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private int currentRoundsTillNextBoss;
    [SerializeField] private int roundsTillNextBoss;
    [SerializeField] private float minRoundsTillBoss = 3;
    [SerializeField] private float maxRoundsTillBoss = 6;
    private ObjectPooler enemyShipPool = default;

    public static WaveSpawner instance = null;
    private EnemySwarm activeSwarm;

    bool isFirstRound = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        enemyShipPool = GetComponent<ObjectPooler>();
        StartCoroutine(SpawnFirstWave());
    }

    /// <summary>
    /// Calculates how many rounds it takes for them to generate a boss encounter.
    /// </summary>
    private void GenerateNextBossEncounter()
    {
        roundsTillNextBoss = Mathf.RoundToInt(Random.Range(minRoundsTillBoss, maxRoundsTillBoss));
        currentRoundsTillNextBoss = 0;
    }

    /// <summary>
    /// Waits a few seconds before spawning the 1st wave.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnFirstWave()
    {
        yield return new WaitForSeconds(1f);
        GenerateNextBossEncounter();
        GenerateNewSwarm();
    }


    /// <summary>
    /// Generates a new swarm to spawn in.
    /// </summary>
    public void GenerateNewSwarm()
    {
        currentRoundsTillNextBoss++;

        if (currentRoundsTillNextBoss == roundsTillNextBoss)
        {
            enemyShipPool.GetNext((int)EnemyShipPooler.BossShipWave, transform.position, Quaternion.identity);
            GenerateNextBossEncounter();
        }
        else
        {
            enemyShipPool.GetNext(Mathf.RoundToInt(Random.Range(0f, 2f)), transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Easy for me to remember in what order the enemy ships are assigned in the Object Pool.
    /// </summary>
    private enum EnemyShipPooler
    {
        SmallShipWave = 0,
        MediumShipWave = 1,
        MixedShipWave = 2,
        BossShipWave = 3
    }
}


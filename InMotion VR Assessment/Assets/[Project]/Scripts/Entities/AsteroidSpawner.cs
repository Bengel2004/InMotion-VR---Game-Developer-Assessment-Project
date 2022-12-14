using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    private float timestamp = 0.0f;
    private Transform thePlayer;
    private ObjectPooler asteroidSpawnPool;
    const int LARGEASTEROIDSPAWNCHANCE = 20; // 20%

    private void Start()
    {
        timestamp = Time.time + 0.0f;
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        asteroidSpawnPool = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        if (Time.time > timestamp && thePlayer != null && SimpleGameManger.GameIsRunning)
        {
            // Gets random position on the edges of the screen
            float _randomX = Random.Range(-15, 15);
            float _randomY = Random.Range(-9, 9);
            if (_randomX > -8 && _randomX < 8)
                return;

            Vector3 _spawnPoint = new Vector3(_randomX, _randomY, 0f);

            // Angles asteroid thorwards player
            Vector2 _direction = thePlayer.transform.position - _spawnPoint;
            float _angle = (Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg) - 90f;
            Quaternion _tempRot = Quaternion.AngleAxis(_angle, Vector3.forward);

            asteroidSpawnPool.GetNext(0, _spawnPoint, _tempRot);
            timestamp = Time.time + spawnTime;
        }
    }
}
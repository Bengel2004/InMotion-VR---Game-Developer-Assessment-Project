using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.PowerUps
{
    public class PowerupSystem : MonoBehaviour
    {
        public static PowerupSystem instance = null;

        private ObjectPooler healthPooler = default;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            healthPooler = GetComponent<ObjectPooler>();
            SpawnRandomPowerUp();
        }

        /// <summary>
        /// Spawns a random power up.
        /// </summary>
        public void SpawnRandomPowerUp()
        {
            healthPooler.GetNext(Mathf.RoundToInt(Random.Range(0f, 1f)), transform.position, Quaternion.identity);
        }
    }
}

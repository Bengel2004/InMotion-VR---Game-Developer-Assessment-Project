using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects
{
    public class Enemy_Ship : Object
    {
        [SerializeField] private EnemyHealthGenerator healthGenerator = new EnemyHealthGenerator();
        [SerializeField] private float rateOfFire = 60;
        private float timestamp;

        private bool canShoot = false;

        private SpriteRenderer renderer = default;

        [SerializeField] private ParticleSystem[] projectiles = default;

        private ObjectPooler damageEffectPooler = default;

        private EnemySwarm swarmMaster = default;
        // Start is called before the first frame update
        void Start()
        {
            health = healthGenerator.GenerateRandomizedHealth();
            renderer = GetComponent<SpriteRenderer>();
            timestamp = Time.time;

            damageEffectPooler = GameObject.Find("[DamageEffectsPooler]").GetComponent<ObjectPooler>();
            swarmMaster = transform.parent?.GetComponent<EnemySwarm>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.time > timestamp && canShoot && SimpleGameManger.GameIsRunning)
            {
                timestamp = Time.time + (60 / rateOfFire);
                foreach(ParticleSystem projectile in projectiles)
                {
                    projectile.Play();
                }
            }
        }

        private void OnBecameVisible()
        {
            canShoot = true;
        }

        private void OnBecameInvisible()
        {
            canShoot = false;
        }

        /// <summary>
        /// Gets executed when the enemy dies, spawns an explosion shockwave.
        /// </summary>
        public override void OnDeath()
        {
            base.OnDeath();
            gameObject.SetActive(false);
            damageEffectPooler.GetNext(0, transform.position, transform.rotation);
            swarmMaster.UpdateSwarm();
        }

        /// <summary>
        /// Fully resets the Enemy to a "respawned" state.
        /// </summary>
        public override void ResetObject()
        {
            base.ResetObject();
            canShoot = false;
            timestamp = Time.time;
            health = healthGenerator.GenerateRandomizedHealth();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects
{
    public class Enemy_Ship : Object
    {
        [SerializeField] private EnemyHealthGenerator healthGenerator = new EnemyHealthGenerator();
        [SerializeField] private float shootDelayTime = 0f;
        [SerializeField] private float rateOfFire = 60;
        private float timestamp;
        private SpriteRenderer renderer = default;

        [SerializeField] private ParticleSystem[] projectiles = default;

        private ObjectPooler damageEffectPooler = default;

        private EnemySwarm swarmMaster = default;
        // Start is called before the first frame update
        void Start()
        {
            health = healthGenerator.GenerateRandomizedHealth();
            renderer = GetComponent<SpriteRenderer>();
            timestamp = Time.time + shootDelayTime;

            damageEffectPooler = GameObject.Find("[DamageEffectsPooler]").GetComponent<ObjectPooler>();
            swarmMaster = transform.parent?.GetComponent<EnemySwarm>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.time > timestamp)
            {
                timestamp = Time.time + (60 / rateOfFire);
                foreach(ParticleSystem projectile in projectiles)
                {
                    projectile.Play();
                }
            }
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
            timestamp = Time.time + shootDelayTime;
            health = healthGenerator.GenerateRandomizedHealth();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects
{
    public class Enemy_SmallShip : Object
    {
        [SerializeField] private float shootDelayTime = 0f;
        [SerializeField] private float rateOfFire = 60;
        private float timestamp;
        private SpriteRenderer renderer = default;

        [SerializeField] private ParticleSystem[] projectiles = default;

        private ObjectPooler damageEffectPooler = default;
        // Start is called before the first frame update
        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            timestamp = Time.time + shootDelayTime;

            damageEffectPooler = GameObject.Find("DamageEffectsPooler").GetComponent<ObjectPooler>();
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

        public override void OnDeath()
        {
            base.OnDeath();
            gameObject.SetActive(false);
            damageEffectPooler.GetNext(0, transform.position, transform.rotation);
        }
    }
}
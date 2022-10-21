using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects
{
    public class Player : Object
    {
        private ObjectPooler damageEffectPooler = default;
        // Start is called before the first frame update
        void Start()
        {
            damageEffectPooler = GameObject.Find("[DamageEffectsPooler]").GetComponent<ObjectPooler>();
            Healthbar.instance.UpdateHealthBar(health);
        }

        public override void DamageEntity(float damage)
        {
            base.DamageEntity(damage);
            Healthbar.instance.UpdateHealthBar(health);
        }

        public override void OnDeath()
        {
            base.OnDeath();
            gameObject.SetActive(false);
            damageEffectPooler.GetNext(0, transform.position, transform.rotation);
        }

        public override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);

            // add ability here to pick up health points.
        }
    }
}
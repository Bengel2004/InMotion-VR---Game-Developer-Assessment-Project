using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects
{
    public class Player : Object
    {
        private ObjectPooler damageEffectPooler = default;

        public float maxHealth;
        // Start is called before the first frame update
        private void Start()
        {
            maxHealth = health;
            damageEffectPooler = GameObject.Find("[DamageEffectsPooler]").GetComponent<ObjectPooler>();
            Healthbar.instance.UpdateHealthBar(health ,maxHealth);
        }

        /// <summary>
        /// Damages the current player.
        /// </summary>
        /// <param name="damage"></param>
        public override void DamageEntity(float damage)
        {
            base.DamageEntity(damage);
            Healthbar.instance.UpdateHealthBar(health, maxHealth);
        }

        /// <summary>
        /// Function is triggered when the player dies.
        /// </summary>
        public override void OnDeath()
        {
            base.OnDeath();
            gameObject.SetActive(false);
            damageEffectPooler.GetNext(0, transform.position, transform.rotation);

            SimpleGameManger.instance.GameOver();
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
        }

        /// <summary>
        /// Fully restores health of the player.
        /// </summary>
        public void ResetHealth()
        {
            health = maxHealth;
            Healthbar.instance.UpdateHealthBar(health, maxHealth);
        }

        /// <summary>
        /// Increases the max health of the player and fully restores it.
        /// </summary>
        /// <param name="value"></param>
        public void IncreaseHealth(float value)
        {
            Healthbar.instance.IncreaseHealthbarHealth();
            maxHealth += value;
            ResetHealth();
        }
    }
}
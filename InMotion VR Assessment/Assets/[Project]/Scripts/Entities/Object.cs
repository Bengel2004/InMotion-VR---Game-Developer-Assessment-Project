using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects 
{ 
    public abstract class Object : MonoBehaviour
    {
        public float health = 100f;
        public float damage = 10f; // 'Sidenote, in theory, the player Object could use this to ram enemies.
        public float scoreValue = 10f;
        private bool isAlive = true;

        /// <summary>
        /// Receives damage funtion triggered from other projectiles/objects.
        /// </summary>
        /// <param name="damage"></param>
        public virtual void DamageEntity(float damage) 
        {
            health -= damage;
            if(health <= 0 && isAlive)
            {
                OnDeath();
            }
        }

        /// <summary>
        /// Gets executed when the object dies, adds score, and other behaviour.
        /// </summary>
        public virtual void OnDeath() 
        {
            isAlive = false;
            ScoreSystem.instance.UpdateScore(scoreValue);
        }

        public virtual void ResetObject()
        {
            isAlive = true;
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Enables damage on objects through collision and other behaviour.
        /// </summary>
        /// <param name="collision"></param>
        public virtual void OnCollisionEnter(Collision collision)
        {
            NielsDev.Objects.Object tempObject = collision.gameObject.GetComponent<NielsDev.Objects.Object>();

            if (tempObject != null)
            {
                tempObject.DamageEntity(damage);
            }
        }
    }
}

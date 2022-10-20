using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects 
{ 
    public abstract class Object : MonoBehaviour
    {
        public float health = 100f;
        public float damage = 10f; // 'Sidenote, in theory, the player Object could use this to ram enemies.
        private bool isAlive = true;


        public void DamageEntity(float damage) 
        {
            health -= damage;
            if(health <= 0 && isAlive)
            {
                OnDeath();
            }
        }

        public virtual void OnDeath() 
        {
            isAlive = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            NielsDev.Objects.Object tempObject = collision.gameObject.GetComponent<NielsDev.Objects.Object>();

            if (tempObject != null)
            {
                tempObject.DamageEntity(damage);
            }
        }
    }
}

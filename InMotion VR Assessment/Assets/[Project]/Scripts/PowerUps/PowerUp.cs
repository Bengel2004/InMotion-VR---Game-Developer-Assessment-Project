using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.PowerUps
{
    public abstract class PowerUp : MonoBehaviour
    {
        [SerializeField] protected float value;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ActivatePowerUp(collision);

                gameObject.SetActive(false);
            }
        }

        public abstract void ActivatePowerUp(Collider2D collision);

        private void OnBecameVisible()
        {
            gameObject.SetActive(true);
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
            PowerupSystem.instance.SpawnRandomPowerUp();
        }
    }
}
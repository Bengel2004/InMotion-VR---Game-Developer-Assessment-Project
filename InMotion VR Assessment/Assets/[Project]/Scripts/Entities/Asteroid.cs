using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects
{
    public class Asteroid : Object
    {
        private float speed;
        [SerializeField] private float minSpeed = 250f;
        [SerializeField] private float maxSpeed = 500f;

        [SerializeField] private Sprite[] asteroidSprites = default;

        private ObjectPooler damageEffectPooler = default;

        private Rigidbody2D rb = default;

        private SpriteRenderer renderer = default;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length - 1)];
            gameObject.AddComponent<PolygonCollider2D>();
            damageEffectPooler = GameObject.Find("[DamageEffectsPooler]").GetComponent<ObjectPooler>();
        }

        private void OnEnable()
        {
            CalculateForce();
            ResetObject();
        }

        private void OnDisable()
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        public override void OnDeath()
        {
            base.OnDeath();
            gameObject.SetActive(false);
            damageEffectPooler.GetNext(1, transform.position, transform.rotation);
        }

        /// <summary>
        /// Calculates a random force.
        /// </summary>
        private void CalculateForce()
        {
            float _randomSpeed = Random.Range(minSpeed, maxSpeed);
            speed = Mathf.Round((_randomSpeed / 100)) * 100;

            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            // Small delay to prevent code execution bug.
            Invoke("ApplyForce", .02f);
        }

        /// <summary>
        /// Applies the forward force.
        /// </summary>
        public void ApplyForce()
        {
            rb.AddRelativeForce(new Vector2(0, speed));
        }



    }
}
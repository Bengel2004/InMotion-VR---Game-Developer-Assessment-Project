using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NielsDev.Objects
{
    public class Asteroid : Object
    {
        [SerializeField] private Sprite[] asteroidSprites = default;
        private SpriteRenderer renderer = default;

        private ObjectPooler damageEffectPooler;
        // Start is called before the first frame update
        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length - 1)];
            gameObject.AddComponent<PolygonCollider2D>();

            damageEffectPooler = GameObject.Find("[DamageEffectsPooler]").GetComponent<ObjectPooler>();
        }

        public override void OnDeath()
        {
            base.OnDeath();
            gameObject.SetActive(false);
            damageEffectPooler.GetNext(1, transform.position, transform.rotation);
        }
    }
}
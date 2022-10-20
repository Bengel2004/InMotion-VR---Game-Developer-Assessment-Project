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
            damageEffectPooler = GameObject.Find("DamageEffectsPooler").GetComponent<ObjectPooler>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnDeath()
        {
            base.OnDeath();
            gameObject.SetActive(false);
            damageEffectPooler.GetNext(0, transform.position, transform.rotation);
        }
    }
}
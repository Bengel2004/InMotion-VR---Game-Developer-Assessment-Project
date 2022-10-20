using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NielsDev.Objects;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    private void OnParticleCollision(GameObject other)
    {
        NielsDev.Objects.Object tempObject = other.GetComponent<NielsDev.Objects.Object>();

        if(tempObject != null)
        {
            tempObject.DamageEntity(damage);
        }
    }
}

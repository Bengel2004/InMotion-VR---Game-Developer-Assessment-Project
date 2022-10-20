using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    private void OnParticleCollision(GameObject other)
    {
        Object tempObject = other.GetComponent<Object>();

        if(tempObject != null)
        {
            tempObject.DamageEntity(damage);
        }
    }
}

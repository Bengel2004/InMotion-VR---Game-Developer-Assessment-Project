using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SmallShip : Object
{
    private SpriteRenderer renderer = default;
    [SerializeField] private Animator explosionAnim = default;
    [SerializeField] private Animator shockwaveAnim = default;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDeath()
    {
        base.OnDeath();
        renderer.enabled = false;
        explosionAnim.Play("Explosion");
        shockwaveAnim.Play("Shockwave");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Object
{
    [SerializeField] private Sprite[] asteroidSprites = default;
    private SpriteRenderer renderer = default;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length - 1)];
        gameObject.AddComponent<PolygonCollider2D>();
    }

    public override void OnDeath()
    {
        base.OnDeath();
        gameObject.SetActive(false);
    }
}

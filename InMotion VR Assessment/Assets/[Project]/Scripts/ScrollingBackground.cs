using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollspeed = 1f;
    [SerializeField] private float edge = 3f;

    private float rightEdge;
    private float leftEdge;
    private Vector3 distanceBetweenEdges;

    private void Start()
    {
        CalculateEdges();

        distanceBetweenEdges = new Vector3(rightEdge - leftEdge, 0f, 0f);
    }

    private void Update()
    {
        transform.localPosition += scrollspeed * Vector3.right * Time.deltaTime;

        if (PassedEdge())
        {
            MoveRightSpriteToOppositeEdge();
        }
    }

    /// <summary>
    /// Calculates the edges of the sprite.
    /// </summary>
    private void CalculateEdges()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        rightEdge = transform.position.x + renderer.bounds.extents.x / edge;
        leftEdge = transform.position.x - renderer.bounds.extents.x / edge;
    }

    /// <summary>
    /// Moves the sprite to the otherside of the screen to create a "scrolling effect"
    /// </summary>
    private void MoveRightSpriteToOppositeEdge()
    {
        if (scrollspeed > 0f)
            transform.position -= distanceBetweenEdges;
        else
            transform.position += distanceBetweenEdges;
    }

    /// <summary>
    /// Checks if the sprite point has passed the edge of the screen.
    /// </summary>
    /// <returns></returns>
    private bool PassedEdge()
    {
        return scrollspeed > 0 && transform.position.x > rightEdge || scrollspeed < 0 && transform.position.x < leftEdge;
    }


    private void OnDrawGizmos()
    {
        //Draws the edges of the screen to where the sprite will be reset.
        Gizmos.DrawCube(new Vector3(rightEdge, 0f, 0f), new Vector3(0.1f, 2f, 0.1f));
        Gizmos.DrawCube(new Vector3(leftEdge, 0f, 0f), new Vector3(0.1f, 2f, 0.1f));
    }
}

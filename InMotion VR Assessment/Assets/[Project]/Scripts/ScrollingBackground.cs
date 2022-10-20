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

    void Start()
    {
        CalculateEdges();

        distanceBetweenEdges = new Vector3(rightEdge - leftEdge, 0f, 0f);
    }

    private void CalculateEdges()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        rightEdge = transform.position.x + renderer.bounds.extents.x / edge;
        leftEdge = transform.position.x - renderer.bounds.extents.x / edge;
    }

    private void MoveRightSpriteToOppositeEdge()
    {
        if (scrollspeed > 0f)
            transform.position -= distanceBetweenEdges;
        else
            transform.position += distanceBetweenEdges;
    }

    private bool PassedEdge()
    {
        return scrollspeed > 0 && transform.position.x > rightEdge || scrollspeed < 0 && transform.position.x < leftEdge;
    }



    void Update()
    {
        transform.localPosition += scrollspeed * Vector3.right * Time.deltaTime;

        if (PassedEdge())
        {
            MoveRightSpriteToOppositeEdge();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector3(rightEdge, 0f, 0f), new Vector3(0.1f, 2f, 0.1f));
        Gizmos.DrawCube(new Vector3(leftEdge, 0f, 0f), new Vector3(0.1f, 2f, 0.1f));
    }
}

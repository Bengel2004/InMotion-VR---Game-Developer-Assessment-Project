using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] movementPoints = default;
    private int currentPoint = 0;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, movementPoints[currentPoint], step);

        if (Vector3.Distance(transform.position, movementPoints[currentPoint]) < 0.001f)
        {
            if(currentPoint + 1 <= movementPoints.Length - 1)
                currentPoint++;
            else
                currentPoint = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach(Vector3 movementPoint in movementPoints)
        {
            Gizmos.DrawSphere(movementPoint, 1);
        }
    }
}

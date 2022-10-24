using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private MovementPattern[] movementPattern = default;
    private MovementPattern currentMovementPattern = default;
    private int currentPoint = 0;

    // A new random movement pattern is assigned whenever the object gets respawned.
    private void OnEnable()
    {
        currentMovementPattern = movementPattern[Mathf.RoundToInt(Random.Range(0, movementPattern.Length - 1f))];
    }

    // Update is called once per frame
    private void Update()
    {
        if (SimpleGameManger.GameIsRunning) 
        {
            var step = currentMovementPattern.speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, currentMovementPattern.movementPoints[currentPoint], step);

            if (Vector3.Distance(transform.position, currentMovementPattern.movementPoints[currentPoint]) < 0.001f)
            {
                if (currentPoint + 1 <= currentMovementPattern.movementPoints.Length - 1)
                    currentPoint++;
                else
                    currentPoint = 0;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach(Vector3 movementPoint in currentMovementPattern.movementPoints)
        {
            Gizmos.DrawSphere(movementPoint, 1);
        }
    }
}

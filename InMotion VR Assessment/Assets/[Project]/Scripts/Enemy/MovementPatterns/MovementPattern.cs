using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Movement Pattern", menuName = "Ship AI/Movement Pattern", order = 1)]
public class MovementPattern : ScriptableObject
{
    public string movementName;
    public float speed = 4f;
    public Vector3[] movementPoints = default;
}

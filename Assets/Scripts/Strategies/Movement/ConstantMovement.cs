using UnityEngine;

public class ConstantMovement : IMovementStrategy
{
    public void Move(Vector3 position, Vector3 velocity, Vector3 acceleration)
    {
        Debug.Log($"Moving using ConstantMovement");
    }
}

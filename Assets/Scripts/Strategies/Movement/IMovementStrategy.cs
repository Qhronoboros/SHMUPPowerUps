using UnityEngine;

public interface IMovementStrategy
{
    void Move(Vector3 position, Vector3 velocity, Vector3 acceleration);
}

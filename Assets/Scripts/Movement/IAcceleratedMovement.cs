using UnityEngine;

public interface IAcceleratedMovement : IMovement
{
    void Move(Vector2 velocity);
    void IncreaseVelocity(Vector2 velocity, Vector2 acceleration);
    void DecreaseVelocity(Vector2 velocity, Vector2 acceleration);
}

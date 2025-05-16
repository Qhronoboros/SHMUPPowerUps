using UnityEngine;

public interface IConstantMovement : IMovement
{
    void Move(Vector2 velocity);
}

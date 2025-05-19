using UnityEngine;

public interface IPhysics : IEntity
{
    Vector3 Velocity { get; }
    Vector3 Acceleration { get; }
    
    void Move(float deltaTime);
}
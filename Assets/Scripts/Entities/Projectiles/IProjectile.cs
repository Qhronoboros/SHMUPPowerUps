using System.Numerics;

public interface IProjectile : IPhysics, IPrototype
{
    IMovementStrategy MovementStrategy { get; }
    ITargetFinderStrategy TargetFinderStrategy { get; }
    float AttackDamage { get; set; }
}
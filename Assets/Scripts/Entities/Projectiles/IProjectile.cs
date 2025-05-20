public interface IProjectile : IPhysics, IPrototype, IDestroyable
{
    MovementOverTime MovementOverTimeApproach { get; }
    IMovementStrategy MovementStrategy { get; }
    TargetFinding TargetFindingApproach { get; }
    ITargetFinderStrategy TargetFinderStrategy { get; }
    float AttackDamage { get; set; }
}
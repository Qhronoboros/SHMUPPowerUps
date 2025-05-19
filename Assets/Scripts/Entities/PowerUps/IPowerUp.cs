public interface IPowerUp : IEntity, IPrototype, IDestroyable
{
    WeaponStatsDecorator WeaponStatsDecorator { get; }
    ShooterLaunch ShooterLaunchApproach { get; }
    MovementOverTime MovementOverTimeApproach { get; }
    TargetFinding TargetFindingApproach { get; }
    
    void ActivatePowerUp();
    bool CompareSelfWithWeapon(IWeapon weapon);
}

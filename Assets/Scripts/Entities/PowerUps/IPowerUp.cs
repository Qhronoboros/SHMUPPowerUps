public interface IPowerUp : IEntity
{
    public WeaponStatsDecorator WeaponStatsDecorator { get; }
    public ShooterLaunch ShooterLaunchApproach { get; }
    public MovementOverTime MovementOverTimeApproach { get; }
    public TargetFinding TargetFindingApproach { get; }
}

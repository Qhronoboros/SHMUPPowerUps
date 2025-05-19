using UnityEngine;

public class PowerUp : IPowerUp
{
    public GameObject AttachedGameObject { get; private set; }
    public WeaponStatsDecorator WeaponStatsDecorator { get; private set; }
    public ShooterLaunch ShooterLaunchApproach { get; private set; }
    public MovementOverTime MovementOverTimeApproach { get; private set; }
    public TargetFinding TargetFindingApproach { get; private set; }
    
    public PowerUp(GameObject gameObject)
    {
        AttachedGameObject = gameObject;
    }
    
    public void ActivatePowerUp()
    {
        
    }
}

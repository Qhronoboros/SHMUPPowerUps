using UnityEngine;

public class Projectile : IProjectile
{
    public Timer lifeSpanTimer;
    
    public GameObject AttachedGameObject { get; private set; }
    public Vector3 Velocity { get; private set; }
    public Vector3 Acceleration { get; private set; }
    
    public MovementOverTime MovementOverTimeApproach { get; private set; }
    public IMovementStrategy MovementStrategy { get; private set; }
    public TargetFinding TargetFindingApproach { get; private set; }
    public ITargetFinderStrategy TargetFinderStrategy { get; private set; }
    public float AttackDamage { get; set; }

    public Projectile(GameObject gameObject, Vector3 position, Vector3 velocity, float lifeSpan,
        MovementOverTime movementOverTimeApproach, TargetFinding targetFindingApproach, bool active)
    {
        AttachedGameObject = gameObject;
        AttachedGameObject.transform.position = position;
        Velocity = velocity;
        
        // Setup timer
        lifeSpanTimer = new Timer(lifeSpan);
        if (active)
        {
            lifeSpanTimer.OnTimerEnd += DestroySelf;
            lifeSpanTimer.StartTimer();
        }
        
        MovementOverTimeApproach = movementOverTimeApproach;
        switch (movementOverTimeApproach)
        {
            case MovementOverTime.NONE: MovementStrategy = new ConstantMovement(); break;
            case MovementOverTime.CONSTANT: MovementStrategy = new ConstantMovement(); break;
            case MovementOverTime.ACCELERATED: MovementStrategy = new AcceleratedMovement(); break;
        }

        TargetFindingApproach = targetFindingApproach;
        switch (targetFindingApproach)
        {
            case TargetFinding.NONE: TargetFinderStrategy = null; break;
            case TargetFinding.CLOSEST: TargetFinderStrategy = new ClosestTarget(); break;
            case TargetFinding.FURTHEST: TargetFinderStrategy = new FurthestTarget(); break;
            case TargetFinding.RANDOM: TargetFinderStrategy = new RandomTarget(); break;
        }
    }

    public void Move(float deltaTime)
    {
        lifeSpanTimer.CountTimer(deltaTime);
        MovementStrategy.Move(AttachedGameObject.transform.position, Velocity, Acceleration);
    }

    public IPrototype Clone()
    {
        Debug.Log("Cloned Projectile");
        
        return new Projectile(GameObject.Instantiate(AttachedGameObject), Vector3.zero,
            Vector3.zero,lifeSpanTimer.duration, MovementOverTimeApproach, TargetFindingApproach, true);
    }
    
    public void DestroySelf()
    {
        GameObject.Destroy(AttachedGameObject);
    }
}

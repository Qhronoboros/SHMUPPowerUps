using UnityEngine;

public class Projectile : IProjectile
{
    public GameObject AttachedGameObject { get; private set; }
    public Vector3 Velocity { get; private set; }
    public Vector3 Acceleration { get; private set; }
    public IMovementStrategy MovementStrategy { get; private set; }
    public ITargetFinderStrategy TargetFinderStrategy { get; private set; }
    public float AttackDamage { get; set; }
    
    public Timer lifeSpanTimer;
        
    public Projectile(GameObject gameObject, Vector3 position, Vector3 velocity, float lifeSpan,
        IMovementStrategy movementStrategy, ITargetFinderStrategy targetFinderStrategy, bool active)
    {
        AttachedGameObject = gameObject;
        AttachedGameObject.transform.position = position;
        Velocity = velocity;
        
        lifeSpanTimer = new Timer(lifeSpan);
        if (active)
        {
            lifeSpanTimer.OnTimerEnd += DestroySelf;
            lifeSpanTimer.StartTimer();
        }

        MovementStrategy = movementStrategy;
        TargetFinderStrategy = targetFinderStrategy;
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
            Vector3.zero,lifeSpanTimer.duration, MovementStrategy, TargetFinderStrategy, true);
    }
    
    public void DestroySelf()
    {
        GameObject.Destroy(AttachedGameObject);
    }
}

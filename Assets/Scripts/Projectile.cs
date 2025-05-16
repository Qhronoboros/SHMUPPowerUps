using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : IConstantMovement
{
    public Vector2 position;
    public Vector2 velocity;
    public Timer lifeSpanTimer;
    
    public Projectile(Vector2 position, Vector2 velocity, float lifeSpan)
    {
        this.position = position;
        this.velocity = velocity;
        
        lifeSpanTimer = new Timer(lifeSpan);
        // lifeSpanTimer.OnTimerEnd += 
        lifeSpanTimer.StartTimer();
    }

    public void Move(Vector2 velocity)
    {
        position += velocity;
    }
}

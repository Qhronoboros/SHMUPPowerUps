using UnityEngine;

public class FanShooter : IShooterStrategy
{
    public void SpawnProjectiles(IProjectile projectile, int projectileAmount, Vector3 actorfacingDirection)
    {
        Debug.Log($"Using FanShooter");
    }
}

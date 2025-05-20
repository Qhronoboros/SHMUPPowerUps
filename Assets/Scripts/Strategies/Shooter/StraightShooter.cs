using UnityEngine;

public class StraightShooter : IShooterStrategy
{
    public void SpawnProjectiles(IProjectile projectile, int projectileAmount, Vector3 actorfacingDirection)
    {
        Debug.Log($"Using StraightShooter");
    }
}

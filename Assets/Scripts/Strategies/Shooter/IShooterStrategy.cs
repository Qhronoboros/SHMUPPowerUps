using UnityEngine;

public interface IShooterStrategy
{
    void SpawnProjectiles(IProjectile projectile, int projectileAmount, Vector3 actorfacingDirection);
}

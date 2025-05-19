using UnityEngine;

public interface IWeapon
{
    IWeaponStats WeaponStats { get; }
    IShooterStrategy ShooterStrategy { get; }
    IProjectile Projectile { get; }
    
    void Shoot(GameObject actor, float attackDamage);
}

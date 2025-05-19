using UnityEngine;

public interface IWeapon
{
    IWeaponStats WeaponStats { get; }
    ShooterLaunch ShooterLaunchApproach { get; }
    IShooterStrategy ShooterStrategy { get; }
    IProjectile Projectile { get; }
    
    void SetWeaponStats(IWeaponStats weaponStats);
    void Update(float deltaTime);
    void Shoot(GameObject actor, float attackDamage);
}

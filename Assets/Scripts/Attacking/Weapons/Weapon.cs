
using UnityEngine;

public class Weapon : IWeapon
{
    public IWeaponStats WeaponStats { get; private set; }
    public IShooterStrategy ShooterStrategy { get; private set; }
    public IProjectile Projectile { get; private set; }

    public Weapon(IWeaponStats weaponStats, IShooterStrategy shooterStrategy, IProjectile projectile)
    {
        WeaponStats = weaponStats;
        ShooterStrategy = shooterStrategy;
        Projectile = projectile;
    }

    public void Shoot(GameObject actor, float attackDamage)
    {
        IProjectile clonedProjectile = Projectile.Clone() as IProjectile;
        clonedProjectile.AttachedGameObject.transform.position = actor.transform.position;
        clonedProjectile.AttackDamage = attackDamage * WeaponStats.GetAttackMultiplier();

        GameManager.instance.projectiles.Add(clonedProjectile);       
        
        ShooterStrategy.SpawnProjectiles(clonedProjectile, WeaponStats.GetProjectileAmount(), actor.transform.forward);
    }
}


using UnityEngine;

public class Weapon : IWeapon
{    
    private Timer _shootCooldownTimer;

    public IWeaponStats WeaponStats { get; private set; }
    public ShooterLaunch ShooterLaunchApproach { get; private set; }
    public IShooterStrategy ShooterStrategy { get; private set; }
    public IProjectile Projectile { get; private set; }

    public Weapon(IWeaponStats weaponStats, ShooterLaunch shooterLaunchApproach, IProjectile projectile)
    {
        WeaponStats = weaponStats;
        ShooterLaunchApproach = shooterLaunchApproach;
        
        switch (ShooterLaunchApproach)
        {
            case ShooterLaunch.NONE: ShooterStrategy = new StraightShooter(); break;
            case ShooterLaunch.STRAIGHT: ShooterStrategy = new StraightShooter(); break;
            case ShooterLaunch.FAN: ShooterStrategy = new FanShooter(); break;
            case ShooterLaunch.CIRCLE: ShooterStrategy = new CircleShooter(); break;
        }
        
        Projectile = projectile;
        
        // Setup timer
        _shootCooldownTimer = new Timer(1.0f / WeaponStats.GetAttackSpeed());
    }

    // Replaces the WeaponStats with the given WeaponStats
    public void SetWeaponStats(IWeaponStats weaponStats)
    {
        Debug.Log($"Before Stats: AttackMultiplier = {WeaponStats.GetAttackMultiplier()}, "
            + $"AttackSpeed = {WeaponStats.GetAttackSpeed()}, ProjectileAmount = {WeaponStats.GetProjectileAmount()}");
        WeaponStats = weaponStats;
        Debug.Log($"After Stats: AttackMultiplier = {WeaponStats.GetAttackMultiplier()}, "
            + $"AttackSpeed = {WeaponStats.GetAttackSpeed()}, ProjectileAmount = {WeaponStats.GetProjectileAmount()}");
        
        UpdateShootTimer(weaponStats.GetAttackSpeed());
    }

    // Shoots a projectile when the timer is not running (not on cooldown)
    public void Shoot(GameObject actor, float attackDamage)
    {
        if (_shootCooldownTimer.counting) return;
        
        IProjectile clonedProjectile = Projectile.Clone() as IProjectile;
        clonedProjectile.AttachedGameObject.transform.position = actor.transform.position;
        clonedProjectile.AttackDamage = attackDamage * WeaponStats.GetAttackMultiplier();

        GameManager.instance.projectiles.Add(clonedProjectile);       
        
        ShooterStrategy.SpawnProjectiles(clonedProjectile, WeaponStats.GetProjectileAmount(), actor.transform.forward);
        
        _shootCooldownTimer.StartTimer();
    }
    
    // Countdown timer
    public void Update(float deltaTime) => _shootCooldownTimer.CountTimer(deltaTime);
    
    // Update the duration of the timer using the attackSpeed
    private void UpdateShootTimer(float attackSpeed) => _shootCooldownTimer.duration = 1.0f / attackSpeed;
}

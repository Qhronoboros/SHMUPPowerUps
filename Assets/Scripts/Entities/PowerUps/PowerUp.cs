using System.Collections.Generic;
using UnityEngine;

public class PowerUp : IPowerUp
{
    public GameObject AttachedGameObject { get; private set; }
    public WeaponStatsDecorator WeaponStatsDecorator { get; private set; }
    public ShooterLaunch ShooterLaunchApproach { get; private set; }
    public MovementOverTime MovementOverTimeApproach { get; private set; }
    public TargetFinding TargetFindingApproach { get; private set; }
    
    public PowerUp(GameObject gameObject, WeaponStatsDecorator weaponStatsDecorator, ShooterLaunch shooterLaunchApproach,
        MovementOverTime movementOverTimeApproach, TargetFinding targetFindingApproach)
    {
        AttachedGameObject = gameObject;
        WeaponStatsDecorator = weaponStatsDecorator;
        ShooterLaunchApproach = shooterLaunchApproach;
        MovementOverTimeApproach = movementOverTimeApproach;
        TargetFindingApproach = targetFindingApproach;
    }
    
    // Gets called when colliding with player
    public void ActivatePowerUp()
    {
        Attacker attacker = GameManager.instance.playerShip.attacker;
    
        IWeapon weapon = CompareSelfWithWeaponList(attacker.weapons);
    
        if (weapon != null)
        {
            // Decorate weapon and set the decorator as the WeaponStats of the Weapon
            weapon.SetWeaponStats(WeaponStatsDecorator.Decorate(weapon.WeaponStats));
        }
        else
        {
            // Add new Weapon to Weapons list
            // attacker.AddWeapon(new Weapon(new WeaponStats(WeaponStatsDecorator.GetAttackMultiplier)));
        }
        
        DestroySelf();
    }
    
    // Compares enums with each weapon in the list and return the Weapon if the enums are the same
    private IWeapon CompareSelfWithWeaponList(List<IWeapon> weapons)
    {
        foreach (IWeapon weapon in weapons)
        {
            if (CompareSelfWithWeapon(weapon)) 
            {
                Debug.Log($"Found Weapon with same enums with Projectile {weapon.Projectile.AttachedGameObject.name}");
                return weapon;
            }
        }

        Debug.Log("Did not find Weapon with same enums");
        return null;
    }
    
    // Compares enums with the given Weapon
    public bool CompareSelfWithWeapon(IWeapon weapon)
    {
        return weapon.ShooterLaunchApproach == ShooterLaunchApproach
            && weapon.Projectile.MovementOverTimeApproach == MovementOverTimeApproach
            && weapon.Projectile.TargetFindingApproach == TargetFindingApproach;
    }

    public void DestroySelf()
    {
        Debug.Log("PowerUp Destroy Self");
        GameObject.Destroy(AttachedGameObject);
    }

    public IPrototype Clone()
    {
        Debug.Log("Cloned PowerUp");
        
        return new PowerUp(GameObject.Instantiate(AttachedGameObject), WeaponStatsDecorator.Clone() as WeaponStatsDecorator,
            ShooterLaunchApproach, MovementOverTimeApproach, TargetFindingApproach);
    }
}

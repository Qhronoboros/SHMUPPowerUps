using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon _decoratedWeapon;
    protected int _attackDamage;
    protected int _attackSpeed;
    protected int _projectileAmount;
    
    protected WeaponDecorator()
    {
        
    }

    public virtual int GetAttack() => _decoratedWeapon.GetAttack() + _attackDamage;
    public virtual float GetAttackSpeed() => _decoratedWeapon.GetAttackSpeed() + _attackSpeed;
    public virtual int GetProjectileAmount() => _decoratedWeapon.GetProjectileAmount() + _projectileAmount;
}

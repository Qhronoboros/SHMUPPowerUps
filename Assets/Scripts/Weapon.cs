using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IWeapon
{
    private int _attackDamage;
    private int _attackSpeed;
    private int _projectileAmount;

    public int GetAttack() => _attackDamage;
    public float GetAttackSpeed() => _attackSpeed;
    public int GetProjectileAmount() => _projectileAmount;
}

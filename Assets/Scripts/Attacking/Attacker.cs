using System.Collections.Generic;
using UnityEngine;

public class Attacker : IAttacker
{
    public float AttackDamage { get; private set; }
    public List<IWeapon> weapons = new List<IWeapon>();
    
    public Attacker(float attackDamage, List<IWeapon> weapons)
    {
        AttackDamage = attackDamage;
        this.weapons = weapons;
    }
    
    public void Attack(GameObject actor)
    {
        foreach (IWeapon weapon in weapons)
        {
            weapon.Shoot(actor, AttackDamage);
        }
    }
}

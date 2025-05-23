using System.Collections.Generic;
using UnityEngine;

public class Attacker : IAttacker
{
    public List<IWeapon> weapons { get; private set; }
    public float AttackDamage { get; private set; }

    public Attacker(float attackDamage)
    {
        AttackDamage = attackDamage;
        weapons = new List<IWeapon>();
    }
    
    public void AddWeapon(IWeapon weapon) => weapons.Add(weapon);
    
    public void Update(float deltaTime)
    {
        foreach (IWeapon weapon in weapons)
        {
            weapon.Update(deltaTime);
        }
    }
    
    public void Attack(GameObject actor)
    {
        foreach (IWeapon weapon in weapons)
        {
            weapon.Shoot(actor, AttackDamage);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    List<IWeapon> weapons { get; }
    float AttackDamage { get; }
    void Update(float deltaTime);
    void Attack(GameObject actor);
}

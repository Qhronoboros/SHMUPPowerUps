using UnityEngine;

public interface IAttacker
{
    float AttackDamage { get; }
    void Attack(GameObject actor);
}

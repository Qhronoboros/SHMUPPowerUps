using UnityEngine;

public interface IAttacker
{
    float AttackDamage { get; }
    void Update(float deltaTime);
    void Attack(GameObject actor);
}

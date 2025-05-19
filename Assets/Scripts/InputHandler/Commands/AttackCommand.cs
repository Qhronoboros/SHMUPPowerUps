using UnityEngine;

public class AttackCommand : ICommand
{
    private IAttacker _attacker;

    public AttackCommand(IAttacker attacker)
    {
        _attacker = attacker;
    }

    public void Execute(GameObject actor)
    {
        Debug.Log("Attack");
        _attacker.Attack(actor);
    }
}

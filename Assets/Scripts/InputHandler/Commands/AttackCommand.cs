using UnityEngine;

public class AttackCommand : ICommand
{
    private IAttacker _attacker;
    public KeyAction KeyAction { get; private set;}

    public AttackCommand(KeyAction keyAction, IAttacker attacker)
    {
        KeyAction = keyAction;
        _attacker = attacker;
    }

    public void Execute(GameObject actor)
    {
        _attacker.Attack(actor);
    }
}
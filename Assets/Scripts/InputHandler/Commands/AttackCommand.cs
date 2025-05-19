using UnityEngine;

public class AttackCommand : ICommand
{
    public KeyAction KeyAction { get; private set;}
    private IAttacker _attacker;

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

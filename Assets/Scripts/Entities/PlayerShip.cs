using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : IPhysics
{
    // Player Input
    private InputHandler _inputHandler;
    
    public IAttacker attacker;
    public Faction faction;

    public GameObject AttachedGameObject { get; private set; }
    public Vector3 Velocity { get; private set; }
    public Vector3 Acceleration { get; private set; }
    
    public PlayerShip(GameObject gameObject, IAttacker attacker, InputHandler inputHandler)
    {
        AttachedGameObject = gameObject;
        _inputHandler = inputHandler;
        this.attacker = attacker;
        faction = Faction.PLAYER;
    }

    public void Move(float deltaTime)
    {
    }

    // Handle player input and update Attacker
    public void Update(float deltaTime)
    {
        List<ICommand> commandList = _inputHandler.HandleInput();
        
        foreach (ICommand command in commandList)
        {
            command?.Execute(AttachedGameObject);
        }
        
        attacker.Update(deltaTime);
    }
}

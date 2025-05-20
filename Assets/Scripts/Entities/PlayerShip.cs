using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : IPhysics
{
    public GameObject AttachedGameObject { get; private set; }
    public Vector3 Velocity { get; private set; }
    public Vector3 Acceleration { get; private set; }
    
    // Player Input
    private InputHandler _inputHandler;
    
    public Attacker attacker;
    public Faction faction;

    public PlayerShip(GameObject gameObject, Attacker attacker, InputHandler inputHandler)
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

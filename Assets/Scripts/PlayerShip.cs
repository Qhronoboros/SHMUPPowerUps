using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private InputHandler _inputHandler;
    private List<IWeapon> _weapons;

    void Awake()
    {
        _inputHandler = new InputHandler();
        _inputHandler.BindKey(KeyCode.Space, new AttackCommand());
        
        _weapons = new List<IWeapon>();
        
        
    }

    void FixedUpdate()
    {
        _inputHandler.HandleInput()?.Execute(gameObject);
    }
}

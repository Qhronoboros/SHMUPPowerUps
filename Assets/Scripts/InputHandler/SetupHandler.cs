using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupHandler : MonoBehaviour
{
    private InputHandler _inputHandler;

    private void Awake()
    {
        _inputHandler = new InputHandler();
        
        // _inputHandler.BindKey(KeyCode.Space, new AttackCommand());
    }

    void Update()
    {
        // _inputHandler.HandleInput()?.Execute(gameObject);
    }
}

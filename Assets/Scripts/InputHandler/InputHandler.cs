using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    private Dictionary<KeyCode, ICommand> buttonDictionary = new Dictionary<KeyCode, ICommand>();

    public void BindKey(KeyCode button, ICommand command)
    {
        // If the button is already bound to a command, remove the command
        if (buttonDictionary.TryGetValue(button, out ICommand foundCommand))
            UnbindKey(button);
            
        buttonDictionary.Add(button, command);
    }
    
    public void UnbindKey(KeyCode button)
    {
        buttonDictionary.Remove(button);
    }

    // Loop through the keys within the dictionary and determine if the corresponding Key
    public List<ICommand> HandleInput()
    {
        List<ICommand> commandList = new List<ICommand>();
        foreach (KeyCode key in buttonDictionary.Keys)
        {
            ICommand command = GetCommand(key);
            
            if (HasKeyActionOccured(key, command.KeyAction))
                commandList.Add(GetCommand(key));
        }
        
        return commandList;
    }
    
    // Checks if the corresponding KeyAction has occured with the given KeyCode
    private bool HasKeyActionOccured(KeyCode key, KeyAction keyAction)
    {
        return Input.GetKeyDown(key) && (keyAction == KeyAction.NONE || keyAction == KeyAction.PRESSED)
            || Input.GetKey(key) && keyAction == KeyAction.HELD
            || Input.GetKeyUp(key) && keyAction == KeyAction.RELEASED;
    }
    
    public ICommand GetCommand(KeyCode button)
    {
        if (!buttonDictionary.TryGetValue(button, out ICommand foundCommand)) return null;
        return foundCommand;
    }
}

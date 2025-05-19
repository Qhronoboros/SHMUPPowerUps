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

    public List<ICommand> HandleInput()
    {
        List<ICommand> commandList = new List<ICommand>();
        foreach (KeyCode key in buttonDictionary.Keys)
        {
            if (Input.GetKey(key)) commandList.Add(GetCommand(key));
        }
        
        return commandList;
    }
    
    public ICommand GetCommand(KeyCode button)
    {
        if (!buttonDictionary.TryGetValue(button, out ICommand foundCommand)) return null;
        return foundCommand;
    }
}

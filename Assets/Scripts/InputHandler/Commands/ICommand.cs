using UnityEngine;

public interface ICommand
{
    KeyAction KeyAction { get; }
    public void Execute(GameObject actor);
}

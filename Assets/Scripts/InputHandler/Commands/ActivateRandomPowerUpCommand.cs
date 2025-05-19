using UnityEngine;

public class ActivateRandomPowerUpCommand : ICommand
{
    public KeyAction KeyAction { get; private set;}
    
    public ActivateRandomPowerUpCommand(KeyAction keyAction)
    {
        KeyAction = keyAction;
    }
    
    public void Execute(GameObject actor)
    {
        if (GameManager.instance.powerUps.Count == 0) return;
        
        int randomIndex = Random.Range(0, GameManager.instance.powerUps.Count - 1);
        GameManager.instance.powerUps[randomIndex].ActivatePowerUp();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPowerUpCommand : ICommand
{
    private List<IPowerUp> _prototypePowerUps;
    public KeyAction KeyAction { get; private set;}

    public SpawnRandomPowerUpCommand(KeyAction keyAction, List<IPowerUp> prototypePowerUps)
    {
        KeyAction = keyAction;
        _prototypePowerUps = prototypePowerUps;
    }

    // Clone a random PowerUp from the prototypePowerUps list and add it in the PowerUps list (within the GameManager)
    public void Execute(GameObject actor)
    {
        int randomIndex = Random.Range(0, _prototypePowerUps.Count - 1);
        GameManager.instance.powerUps.Add(_prototypePowerUps[randomIndex].Clone() as IPowerUp);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPowerUpCommand : ICommand
{
    public KeyAction KeyAction { get; private set;}
    private List<IPowerUp> _prototypePowerUps;

    public SpawnRandomPowerUpCommand(KeyAction keyAction, List<IPowerUp> prototypePowerUps)
    {
        KeyAction = keyAction;
        _prototypePowerUps = prototypePowerUps;
    }

    public void Execute(GameObject actor)
    {
        int randomIndex = Random.Range(0, _prototypePowerUps.Count - 1);
        GameManager.instance.powerUps.Add(_prototypePowerUps[randomIndex].Clone() as IPowerUp);
    }
}

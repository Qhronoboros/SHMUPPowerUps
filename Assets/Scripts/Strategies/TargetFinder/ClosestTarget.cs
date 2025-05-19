using System.Collections.Generic;
using UnityEngine;

public class ClosestTarget : ITargetFinderStrategy
{
    public IEntity FindTarget(List<IEntity> entities, Faction actorFaction)
    {
        Debug.Log($"Using ClosestTarget");
        return null;
    }
}

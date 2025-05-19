using System.Collections.Generic;
using UnityEngine;

public class FurthestTarget : ITargetFinderStrategy
{
    public IEntity FindTarget(List<IEntity> entities, Faction actorFaction)
    {
        Debug.Log($"Using FurthestTarget");
        return null;
    }
}

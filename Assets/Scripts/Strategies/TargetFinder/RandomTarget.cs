using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : ITargetFinderStrategy
{
    public IEntity FindTarget(List<IEntity> entities, Faction actorFaction)
    {
        Debug.Log($"Using RandomTarget");
        return null;
    }
}

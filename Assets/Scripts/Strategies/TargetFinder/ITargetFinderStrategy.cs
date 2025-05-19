using System.Collections.Generic;

public interface ITargetFinderStrategy
{
    IEntity FindTarget(List<IEntity> entities, Faction actorFaction);
}

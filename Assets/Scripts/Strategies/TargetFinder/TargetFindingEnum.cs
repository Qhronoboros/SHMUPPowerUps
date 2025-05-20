/// <summary>
/// How a projectile finds a target when it has homing capabilities (Could be used by other objects)
/// Used for comparing (Projectiles of ) Weapons and WeaponStatsDecorators
/// </summary>
public enum TargetFinding
{
    NONE,       // Does not home onto potential targets
    CLOSEST,    // Gets a target closest to the object
    FURTHEST,   // Gets a target furthest to the object
    RANDOM      // Gets a random target
}
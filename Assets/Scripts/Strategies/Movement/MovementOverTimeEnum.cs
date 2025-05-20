/// <summary>
/// How a projectile moves (could a also be used by other objects)
/// Used for comparing (Projectiles of ) Weapons and WeaponStatsDecorators
/// </summary>
public enum MovementOverTime
{
    NONE,           // Not Assigned
    CONSTANT,       // Moves with a constant velocity
    ACCELERATED     // Moves using acceleration
}
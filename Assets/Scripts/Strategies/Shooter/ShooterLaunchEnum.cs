/// <summary>
/// The way a Weapon launches a projectile
/// Used for comparing Weapons and WeaponStatsDecorators
/// </summary> 
public enum ShooterLaunch
{
    NONE,       // Not Assigned
    STRAIGHT,   // Shoots forward
    FAN,        // Shoots in a cone pattern starting at the front
    CIRCLE      // Shoots around the shooterObject
}
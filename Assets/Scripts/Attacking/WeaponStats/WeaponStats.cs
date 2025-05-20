public class WeaponStats : IWeaponStats
{
    private float _attackMultiplier;
    private float _attackSpeed;
    private int _projectileAmount;
    
    public WeaponStats(float attackMultiplier, float attackSpeed, int projectileAmount)
    {
        _attackMultiplier = attackMultiplier;
        _attackSpeed = attackSpeed;
        _projectileAmount = projectileAmount;   
    }

    public float GetAttackMultiplier() => _attackMultiplier;
    public float GetAttackSpeed() => _attackSpeed;
    public int GetProjectileAmount() => _projectileAmount;
}

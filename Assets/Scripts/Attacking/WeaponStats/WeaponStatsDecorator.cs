public abstract class WeaponStatsDecorator : IWeaponStats
{
    protected IWeaponStats _decoratedWeaponStats;
    protected float _attackMultiplier;
    protected float _attackSpeed;
    protected int _projectileAmount;
    
    protected WeaponStatsDecorator(float attackMultiplier, float attackSpeed, int projectileAmount)
    {
        this._attackMultiplier = attackMultiplier;
        this._attackSpeed = attackSpeed;
        this._projectileAmount = projectileAmount;
    }
    
    public void Decorate(IWeaponStats weapon)
    {
        _decoratedWeaponStats = weapon;
    }

    public virtual float GetAttackMultiplier() => _decoratedWeaponStats.GetAttackMultiplier() + _attackMultiplier;
    public virtual float GetAttackSpeed() => _decoratedWeaponStats.GetAttackSpeed() + _attackSpeed;
    public virtual int GetProjectileAmount() => _decoratedWeaponStats.GetProjectileAmount() + _projectileAmount;
}

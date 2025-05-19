public class ProjectileAmountDecorator : WeaponStatsDecorator
{
    public ProjectileAmountDecorator(int projectileAmount)
        : base(0.0f, 0.0f, projectileAmount) {}
        
    public override IPrototype Clone() => new ProjectileAmountDecorator(_projectileAmount);
}

public class AttackMultiplierDecorator : WeaponStatsDecorator
{
    public AttackMultiplierDecorator(float attackMultiplier)
        : base(attackMultiplier, 0.0f, 0) {}

    public override IPrototype Clone() => new AttackMultiplierDecorator(_attackMultiplier);
}

public class AttackSpeedDecorator : WeaponStatsDecorator
{
    public AttackSpeedDecorator(float attackSpeed)
        : base(0.0f, attackSpeed, 0) {}

    public override IPrototype Clone() => new AttackSpeedDecorator(_attackSpeed);
}

using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Attack
{
    public abstract class AttackBehaviour : UnitBehaviour
    {
        public abstract float CurrentCooldown { get; }
        public abstract bool Attack(IUnit self, float deltaTime, IUnit target);
    }
}

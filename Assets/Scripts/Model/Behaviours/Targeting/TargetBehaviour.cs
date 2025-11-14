using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Targeting
{
    public abstract class TargetBehaviour : UnitBehaviour
    {
        public abstract IUnit CurrentTarget { get; }

        public abstract IUnit GetTarget(IUnit self, float deltaTime);
    }
}

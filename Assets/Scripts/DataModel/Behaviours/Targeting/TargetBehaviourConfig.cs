using AlvaroPerez.MinionClash.Model.Behaviours.Targeting;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Targeting
{
    public abstract class TargetBehaviourConfig : UnitBehaviourConfig
    {
        public abstract TargetBehaviour Create();
    }
}

using AlvaroPerez.MinionClash.Model.Behaviours.Other;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Other
{
    public abstract class OtherUnitBehaviourConfig : UnitBehaviourConfig
    {
        public abstract OtherUnitBehaviour Create();
    }
}

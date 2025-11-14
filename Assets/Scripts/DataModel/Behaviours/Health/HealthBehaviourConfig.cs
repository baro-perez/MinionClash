using AlvaroPerez.MinionClash.Model.Behaviours.Health;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Health
{
    public abstract class HealthBehaviourConfig : UnitBehaviourConfig
    {
        public abstract HealthBehaviour Create();
    }
}

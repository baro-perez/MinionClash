using AlvaroPerez.MinionClash.Model.Behaviours.Push;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Push
{
    public abstract class PushBehaviourConfig : UnitBehaviourConfig
    {
        public abstract PushBehaviour Create();
    }
}

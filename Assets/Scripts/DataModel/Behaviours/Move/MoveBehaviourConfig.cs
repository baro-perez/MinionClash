using AlvaroPerez.MinionClash.Model.Behaviours.Move;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Move
{
    public abstract class MoveBehaviourConfig : UnitBehaviourConfig
    {
        public abstract MoveBehaviour Create();
    }
}

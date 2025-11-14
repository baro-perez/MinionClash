using AlvaroPerez.MinionClash.Model.Behaviours.Attack;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Attack
{
    public abstract class AttackBehaviourConfig : UnitBehaviourConfig
    {
        public abstract AttackBehaviour Create();
    }
}

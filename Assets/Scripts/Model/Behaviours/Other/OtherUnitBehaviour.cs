using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Other
{
    public abstract class OtherUnitBehaviour : UnitBehaviour
    {
        public abstract void Tick(IUnit self, float deltaTime);
    }
}

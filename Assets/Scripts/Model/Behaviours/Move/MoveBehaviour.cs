using AlvaroPerez.MinionClash.Model.Units;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Move
{
    public abstract class MoveBehaviour : UnitBehaviour
    {
        protected virtual bool CanMoveWithNoTarget => false;

        public Vector2 GetVelocity(IUnit self, float deltaTime, IUnit target)
        {
            if (!self.CanMove || (!CanMoveWithNoTarget && target == null))
            {
                return Vector2.zero;
            }

            return GetVelocityImpl(self, deltaTime, target);
        }

        protected abstract Vector2 GetVelocityImpl(IUnit self, float deltaTime, IUnit target);
    }
}

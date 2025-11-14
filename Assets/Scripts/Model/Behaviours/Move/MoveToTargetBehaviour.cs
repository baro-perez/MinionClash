using AlvaroPerez.MinionClash.Model.Units;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Move
{
    public class MoveToTargetBehaviour : MoveBehaviour
    {
        private float minSqrDistance = 0.25f;

        public MoveToTargetBehaviour(float minDistance)
        {
            this.minSqrDistance = minDistance * minDistance;
        }

        protected override Vector2 GetVelocityImpl(IUnit self, float deltaTime, IUnit target)
        {
            var diff = target.Position - self.Position;
            var sqrDistance = diff.sqrMagnitude;
            if (sqrDistance < minSqrDistance)
            {
                return Vector2.zero;
            }

            var direction = (target.Position - self.Position).normalized;
            return self.Stats.speed * direction;
        }
    }
}

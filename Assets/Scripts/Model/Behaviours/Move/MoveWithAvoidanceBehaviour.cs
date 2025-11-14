using AlvaroPerez.MinionClash.Model.Units;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Move
{
    public class MoveWithAvoidanceBehaviour : MoveBehaviour
    {
        protected override bool CanMoveWithNoTarget => true;

        private float avoidanceDistance;
        private float avoidanceSrqDistance;
        private float avoidanceStrengthFactor;
        private AnimationCurve strengthFactorCurve;
        private MoveBehaviour decorated;

        public MoveWithAvoidanceBehaviour(
            float avoidanceDistance, 
            float avoidanceStrengthFactor,
            AnimationCurve strengthFactorCurve,
            MoveBehaviour decorated)
        {
            this.avoidanceDistance = avoidanceDistance;
            this.avoidanceSrqDistance = avoidanceDistance * avoidanceDistance;
            this.avoidanceStrengthFactor = avoidanceStrengthFactor;
            this.strengthFactorCurve = strengthFactorCurve;
            this.decorated = decorated;
        }

        protected override Vector2 GetVelocityImpl(IUnit self, float deltaTime, IUnit target)
        {
            int count = 0;
            float accumulatedStrength = 0f;
            Vector2 avoidance = Vector2.zero;
            foreach(var unit in ModelManagers.UnitManager.AllUnits)
            {
                if (unit == null || unit == self || unit == target)
                {
                    continue;
                }

                var diff = unit.Position - self.Position;
                if (diff.sqrMagnitude >= avoidanceSrqDistance)
                {
                    continue;
                }

                var magnitude = diff.magnitude;
                var lerp = magnitude / avoidanceDistance;
                var strength = strengthFactorCurve.Evaluate(lerp);
                var dir = diff / magnitude;
                accumulatedStrength += strength;
                avoidance += -dir * strength;
                ++count;
            }

            if (count > 0)
            {
                avoidance /= count;
            }

            accumulatedStrength *= avoidanceStrengthFactor;
            avoidance *= avoidanceStrengthFactor * self.Stats.speed;

            return Vector2.Lerp(decorated.GetVelocity(self, deltaTime, target), avoidance, accumulatedStrength);
        }
    }
}

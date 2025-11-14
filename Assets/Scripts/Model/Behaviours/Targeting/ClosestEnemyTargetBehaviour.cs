using AlvaroPerez.MinionClash.Model.Units;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Targeting
{

    public class ClosestEnemyTargetBehaviour : TargetBehaviour
    {
        private float retargetCooldown = 1f;

        private float retargetCooldownTime = default;
        private IUnit currentTarget;

        public ClosestEnemyTargetBehaviour(float retargetCooldown)
        {
            this.retargetCooldown = retargetCooldown;
        }

        public override IUnit CurrentTarget => currentTarget;

        public override IUnit GetTarget(IUnit self, float deltaTime)
        {
            // Check retarget
            if (retargetCooldownTime > 0 &&
                Unit.IsTargetable(currentTarget))
            {
                retargetCooldownTime -= deltaTime;
                return currentTarget;
            }

            var bestUnit = GetClosestUnit(self);
            retargetCooldownTime = retargetCooldown;
            currentTarget = bestUnit;
            return currentTarget;
        }

        private IUnit GetClosestUnit(IUnit self)
        {
            var currentPosition = self.Position;
            float bestSqrDistance = default;
            IUnit bestUnit = null;
            var enemies = ModelManagers.UnitManager.GetTeam(self.Team.Opposite());
            foreach (var enemy in enemies)
            {
                if (!Unit.IsTargetable(enemy))
                {
                    continue;
                }

                var diff = currentPosition - enemy.Position;
                var sqrDistance = Vector2.SqrMagnitude(diff);
                if (bestUnit == null || sqrDistance < bestSqrDistance)
                {
                    bestUnit = enemy;
                    bestSqrDistance = sqrDistance;
                }
            }

            return bestUnit;
        }
    }
}

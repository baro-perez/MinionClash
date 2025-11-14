using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Attack
{
    public class InstantAttackBehaviour : AttackBehaviour
    {
        private float minDistance;
        private float maxDistance;

        private float disallowMovementCooldown;

        private float currentCooldown;
        private bool disallowMovement;

        public InstantAttackBehaviour(
            float minDistance, 
            float maxDistance,
            float disallowMovementCooldown)
        {
            this.minDistance = minDistance;
            this.maxDistance = maxDistance;
            this.disallowMovementCooldown = disallowMovementCooldown;
        }

        public override float CurrentCooldown => currentCooldown;

        protected override void InitImpl(IModelManagers gameManager, IUnit self)
        {
            base.InitImpl(gameManager, self);
            currentCooldown = self.Stats.atkspd;
        }

        public override bool AllowMovement(IUnit self)
        {
            if (!base.AllowMovement(self))
            {
                return false;
            }

            return !disallowMovement;
        }

        public override bool Attack(IUnit self, float deltaTime, IUnit target)
        {
            currentCooldown -= deltaTime;

            if (disallowMovement &&
                currentCooldown <= self.Stats.atkspd - disallowMovementCooldown)
            {
                disallowMovement = false;
            }

            if (target == null || currentCooldown > 0)
            {
                return false;
            }

            var diff = target.Position - self.Position;
            var sqrDistance = diff.sqrMagnitude;
            var sqrMinDistance = minDistance * minDistance;
            var sqrMaxDistance = maxDistance * maxDistance;

            if (sqrDistance < sqrMinDistance || sqrDistance > sqrMaxDistance)
            {
                return false;
            }

            target.BeAttacked(self.Stats.atk);

            self.RaiseEventsOnAttack(target);
            currentCooldown = self.Stats.atkspd;
            disallowMovement = true;

            return true;
        }
    }
}

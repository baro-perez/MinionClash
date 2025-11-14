using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Attack
{
    public class PushingAttackBehaviour : AttackBehaviour
    {
        private AttackBehaviour decorated;
        private float pushStrength;

        public PushingAttackBehaviour(AttackBehaviour decorated, float pushStrength)
        {
            this.decorated = decorated;
            this.pushStrength = pushStrength;
        }

        public override float CurrentCooldown => decorated.CurrentCooldown;

        public override bool Attack(IUnit self, float deltaTime, IUnit target)
        {
            if (!decorated.Attack(self, deltaTime, target))
            {
                return false;
            }

            var diff = target.Position - self.Position;
            target.BePushed(diff.normalized * pushStrength);
            return true;
        }
    }
}

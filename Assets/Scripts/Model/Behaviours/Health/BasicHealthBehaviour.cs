using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Health
{

    public class BasicHealthBehaviour : HealthBehaviour
    {
        protected override void InitImpl(IModelManagers gameManager, IUnit self)
        {
            base.InitImpl(gameManager, self);
            CurrentHealth = self.Stats.hp;
        }

        public override void Tick(IUnit self, float deltaTime)
        {
        }

        public override void BeHit(float atk)
        {
            var nextHealth = CurrentHealth - atk;
            var hitEventData = new HealthBehaviourEvents.BeHitEventData(atk, CurrentHealth, nextHealth);
            CurrentHealth = nextHealth;

            RaiseBeHit(hitEventData);

            if (!IsAlive)
            {
                RaiseDie(new HealthBehaviourEvents.DieEventData(hitEventData));
            }
        }
    }
}

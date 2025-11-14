using AlvaroPerez.MinionClash.Model.Behaviours.Other;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Health
{
    public abstract class HealthBehaviour : OtherUnitBehaviour, IHealthBehaviour
    {
        // Implements OtherUnitBehaviour to have Tick, making possible behaviours like self-healing

        public event HealthBehaviourEvents.OnHealthChangedFn OnHealthChanged;
        public event HealthBehaviourEvents.OnBeHitFn OnBeHit;
        public event HealthBehaviourEvents.OnDieFn OnDie;

        protected void RaiseBeHit(HealthBehaviourEvents.BeHitEventData data)
        {
            OnBeHit?.Invoke(this, data);
        }

        protected void RaiseDie(HealthBehaviourEvents.DieEventData data)
        {
            OnDie?.Invoke(this, data);
        }

        public bool IsAlive => CurrentHealth > 0;

        private float currentHealth;
        public float CurrentHealth 
        {
            get => currentHealth;
            set
            {
                var prevValue = currentHealth;
                currentHealth = value;
                OnHealthChanged?.Invoke(this, 
                    new HealthBehaviourEvents.HealthChangedEventData(prevValue, currentHealth));
            }
        }

        public abstract void BeHit(float atk);

    }
}

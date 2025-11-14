namespace AlvaroPerez.MinionClash.Model.Behaviours.Health
{
    public static class HealthBehaviourEvents
    {
        public readonly struct HealthChangedEventData
        {
            public readonly float previousHealth;
            public readonly float currentHealth;

            public HealthChangedEventData(float previousHealth, float currentHealth)
            {
                this.previousHealth = previousHealth;
                this.currentHealth = currentHealth;
            }
        }
        public delegate void OnHealthChangedFn(IHealthBehaviour caller, HealthChangedEventData data);

        public readonly struct BeHitEventData
        {
            public readonly float power;
            public readonly float currentHealth;
            public readonly float nextHealth;

            public BeHitEventData(float power, float currentHealth, float nextHealth)
            {
                this.power = power;
                this.currentHealth = currentHealth;
                this.nextHealth = nextHealth;
            }
        }
        
        public delegate void OnBeHitFn(IHealthBehaviour caller, BeHitEventData data);

        public readonly struct DieEventData
        {
            public readonly BeHitEventData hitEventData;

            public DieEventData(BeHitEventData hitEventData)
            {
                this.hitEventData = hitEventData;
            }
        }
        public delegate void OnDieFn(IHealthBehaviour caller, DieEventData data);
    }
}

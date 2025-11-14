namespace AlvaroPerez.MinionClash.Model.Behaviours.Health
{
    /// <summary>
    /// Interface that is visible to other behaviours
    /// </summary>
    public interface IHealthBehaviour
    {
        bool IsAlive { get; }
        float CurrentHealth { get; }

        event HealthBehaviourEvents.OnBeHitFn OnBeHit;
        event HealthBehaviourEvents.OnHealthChangedFn OnHealthChanged;
        event HealthBehaviourEvents.OnDieFn OnDie;
    }
}

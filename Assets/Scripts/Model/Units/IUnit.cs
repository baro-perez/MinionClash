using AlvaroPerez.MinionClash.Model.Behaviours.Health;
using AlvaroPerez.MinionClash.UnitStats;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Units
{
    /// <summary>
    /// Interface of <see cref="Unit"/> that is visible to other behaviours
    /// </summary>
    public interface IUnit
    {
        Team Team { get; }
        UnitClass UnitClass { get; }

        Stats Stats { get; }
        IHealthBehaviour HealthBehaviour { get; }

        Vector2 Position { get; }
        bool CanMove { get; }

        void BeAttacked(float atk);
        void BePushed(Vector2 pushVelocity);

        void RaiseEventsOnAttack(IUnit target);

        event UnitEvents.OnAttackFn OnAttack;
        event UnitEvents.OnPositionChangeFn OnPositionChange;
        event UnitEvents.OnDieFn OnDie;

        void Tick(float deltaTime);
    }
}

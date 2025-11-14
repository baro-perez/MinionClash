using AlvaroPerez.MinionClash.Model.Behaviours.Health;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Units
{
    public static class UnitEvents
    {
        public readonly struct DieEventData
        {
            public readonly HealthBehaviourEvents.DieEventData dieEventData;

            public DieEventData(HealthBehaviourEvents.DieEventData dieEventData)
            {
                this.dieEventData = dieEventData;
            }
        }
        public delegate void OnDieFn(IUnit caller, DieEventData data);

        public readonly struct AttackEventData
        {
            public readonly IUnit target;

            public AttackEventData(IUnit target)
            {
                this.target = target;
            }
        }

        public delegate void OnAttackFn(object caller, AttackEventData data);

        public readonly struct PositionChangeEventData
        {
            public readonly Vector2 prevPosition;
            public readonly Vector2 position;
            public readonly Vector2 velocity;

            public PositionChangeEventData(Vector2 prevPosition, Vector2 position, Vector2 velocity)
            {
                this.prevPosition = prevPosition;
                this.position = position;
                this.velocity = velocity;
            }
        }

        /// <param name="caller">it's <see cref="Object"/> because we don't want to expose <see cref="Unit"/></param>
        public delegate void OnPositionChangeFn(object caller, PositionChangeEventData data);
    }
}

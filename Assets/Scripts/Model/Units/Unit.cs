using AlvaroPerez.MinionClash.Model.Behaviours;
using AlvaroPerez.MinionClash.Model.Behaviours.Health;
using AlvaroPerez.MinionClash.Model.Behaviours.Push;
using AlvaroPerez.MinionClash.UnitStats;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Units
{
    public class Unit : IUnit
    {
        private BehaviourCollection behaviours;

        public event UnitEvents.OnAttackFn OnAttack;
        /// <summary>
        /// called after changing <see cref="Transform"/>.<see cref="Transform.position"/>
        /// </summary>
        public event UnitEvents.OnPositionChangeFn OnPositionChange;
        public event UnitEvents.OnDieFn OnDie;

        public Team Team { get; private set; }
        public UnitClass UnitClass { get; private set; }

        public Vector2 Position { get; private set; }

        public Stats Stats { get; private set; }

        public static bool IsTargetable(IUnit unit)
        {
            return unit != null && unit.HealthBehaviour.IsAlive;
        }

        public IEnumerable<UnitBehaviour> UnitBehaviours => behaviours.UnitBehaviours;
        public IHealthBehaviour HealthBehaviour => behaviours.HealthBehaviour;
        public IPushBehaviour PushBehaviour => behaviours.PushBehaviour;

        public bool CanMove => UnitBehaviours.All(c => c.AllowMovement(this));

        public void Init(
            BehaviourCollection behaviours,
            IModelManagers modelManagers,
            Team team,
            UnitClass unitClass,
            Vector2 position)
        {
            this.behaviours = behaviours;
            Team = team;
            UnitClass = unitClass;
            Stats = modelManagers.StatsFactory.CreateStats(unitClass);
            Position = position;

            foreach (var behaviour in UnitBehaviours)
            {
                behaviour.Init(modelManagers, this);
            }

            behaviours.HealthBehaviour.OnDie += RaiseOnDie;
        }

        public void TearDown()
        {
            behaviours.HealthBehaviour.OnDie -= RaiseOnDie;
        }

        private void RaiseOnDie(object caller, HealthBehaviourEvents.DieEventData data)
        {
            OnDie?.Invoke(this, new UnitEvents.DieEventData(data));
        }

        public void Tick(float deltaTime)
        {
            for (var i = 0; i < behaviours.BeforeBehaviours.Count; i++)
            {
                var behaviour = behaviours.BeforeBehaviours[i];
                if (behaviour == null)
                {
                    continue;
                }

                behaviour.Tick(this, deltaTime);
            }

            behaviours.HealthBehaviour.Tick(this, deltaTime);
            var target = behaviours.TargetBehaviour.GetTarget(this, deltaTime);
            behaviours.PushBehaviour.GetVelocity(this, deltaTime, out var pushVelocity, out var pushMoveFactor);
            var moveVelocity = behaviours.MoveBehaviour.GetVelocity(this, deltaTime, target);
            moveVelocity *= pushMoveFactor;

            ApplyVelocity(deltaTime, moveVelocity + pushVelocity);

            behaviours.AttackBehaviour.Attack(this, deltaTime, target);

            for (var i = 0; i < behaviours.AfterBehaviours.Count; i++)
            {
                var behaviour = behaviours.AfterBehaviours[i];
                if (behaviour == null)
                {
                    continue;
                }

                behaviour.Tick(this, deltaTime);
            }
        }

        private void ApplyVelocity(float deltaTime, Vector2 velocity)
        {
            if (velocity.sqrMagnitude != 0)
            {
                var prevPosition = Position;
                Position += velocity * deltaTime;
                OnPositionChange?.Invoke(this,
                    new UnitEvents.PositionChangeEventData(prevPosition, Position, velocity));
            }
        }

        public void SetVelocity(Vector2 vector2)
        {
        }

        public void BeAttacked(float atk)
        {
            behaviours.HealthBehaviour.BeHit(atk);
        }

        public void RaiseEventsOnAttack(IUnit target)
        {
            OnAttack?.Invoke(this, new UnitEvents.AttackEventData(target));
        }

        protected void RaiseDie(UnitEvents.DieEventData dieEventData)
        {
            OnDie?.Invoke(this, dieEventData);
        }

        public void BePushed(Vector2 pushVelocity)
        {
            PushBehaviour.ApplyPush(pushVelocity);
        }
    }
}

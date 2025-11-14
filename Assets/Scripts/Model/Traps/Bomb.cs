using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;
using System.Collections.Generic;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Traps
{
    public class Bomb : ITrap
    {
        private Vector2 position;

        private float initialRadius;
        private float expandRadius;
        private float expandSpeed;
        private float atkOnCenter;
        private float atkOnEdge;
        private float pushOnCenter;
        private float pushOnEdge;

        public event TrapEvents.OnDieFn OnDie;
        public event BombEvents.OnRadiusChangedFn OnRadiusChanged;

        private HashSet<IUnit> affectedUnits = new HashSet<IUnit>();

        public Vector2 Position => position;
        public float CurrentRadius { get; private set; }

        private List<IUnit> reusableUnitList = new List<IUnit>();

        public Bomb(Vector2 position,
            float initialRadius,
            float expandRadius,
            float expandSpeed,
            float atkOnCenter,
            float atkOnEdge,
            float pushOnCenter,
            float pushOnEdge)
        {
            this.position = position;
            this.initialRadius = initialRadius;
            this.CurrentRadius = 0;
            this.expandRadius = expandRadius;
            this.expandSpeed = expandSpeed;
            this.atkOnCenter = atkOnCenter;
            this.atkOnEdge = atkOnEdge;
            this.pushOnCenter = pushOnCenter;
            this.pushOnEdge = pushOnEdge;
        }

        public void Tick(IModelManagers modelManagers, float deltaTime)
        {
            if (CurrentRadius >= expandRadius)
            {
                return;
            }

            var prevRadius = CurrentRadius;
            var nextRadius =
                CurrentRadius == 0 && initialRadius != 0 ? initialRadius :
                CurrentRadius + expandSpeed * deltaTime;

            var finished = nextRadius >= expandRadius;
            if (finished)
            {
                nextRadius = expandRadius;
            }

            var prevSqrRadius = prevRadius * prevRadius;
            var nextSqrRadius = nextRadius * nextRadius;

            reusableUnitList.Clear();
            reusableUnitList.AddRange(modelManagers.UnitManager.AllUnits);
            for (var i = 0; i < reusableUnitList.Count; i++)
            {
                var unit = reusableUnitList[i];
                if (affectedUnits.Contains(unit))
                {
                    continue;
                }

                var diff = unit.Position - position;
                var sqrDistance = diff.sqrMagnitude;

                // If we supported implosions the equality would be the other way around.... but that's out of scope
                if (sqrDistance >= prevSqrRadius && sqrDistance <= nextSqrRadius)
                {
                    var distance = Mathf.Sqrt(sqrDistance);
                    var dir = diff / distance;
                    var iLerp = Mathf.InverseLerp(initialRadius, expandRadius, distance);
                    var atk = Mathf.Lerp(atkOnCenter, atkOnEdge, iLerp);
                    var push = Mathf.Lerp(pushOnCenter, pushOnEdge, iLerp);
                    unit.BeAttacked(atk);
                    unit.BePushed(push * dir);
                    affectedUnits.Add(unit);
                }
            }

            CurrentRadius = nextRadius;
            OnRadiusChanged?.Invoke(this, new BombEvents.RadiusChangedData(prevRadius, nextRadius));

            if (finished)
            {
                OnDie?.Invoke(this, new TrapEvents.DieEventData());
            }
        }
    }
}

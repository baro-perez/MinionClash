using System.Collections.Generic;
using AlvaroPerez.MinionClash.Model.Behaviours.Attack;
using AlvaroPerez.MinionClash.Model.Behaviours.Health;
using AlvaroPerez.MinionClash.Model.Behaviours.Move;
using AlvaroPerez.MinionClash.Model.Behaviours.Other;
using AlvaroPerez.MinionClash.Model.Behaviours.Push;
using AlvaroPerez.MinionClash.Model.Behaviours.Targeting;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours
{
    public class BehaviourCollection
    {
        // These will be assumed to be non-null
        private HealthBehaviour healthBehaviour;
        private PushBehaviour pushBehaviour;
        private TargetBehaviour targetBehaviour;
        private MoveBehaviour moveBehaviour;
        private AttackBehaviour attackBehaviour;

        // These are optional and will be null-checked
        private OtherUnitBehaviour[] beforeBehaviours;
        private OtherUnitBehaviour[] afterBehaviours;

        public BehaviourCollection(
            HealthBehaviour healthBehaviour,
            PushBehaviour pushBehaviour,
            TargetBehaviour targetBehaviour,
            MoveBehaviour moveBehaviour,
            AttackBehaviour attackBehaviour,
            OtherUnitBehaviour[] beforeBehaviours,
            OtherUnitBehaviour[] afterBehaviours)
        {
            this.healthBehaviour = healthBehaviour;
            this.pushBehaviour = pushBehaviour;
            this.targetBehaviour = targetBehaviour;
            this.moveBehaviour = moveBehaviour;
            this.attackBehaviour = attackBehaviour;
            this.beforeBehaviours = beforeBehaviours;
            this.afterBehaviours = afterBehaviours;
        }

        public IReadOnlyList<OtherUnitBehaviour> BeforeBehaviours => beforeBehaviours;
        public HealthBehaviour HealthBehaviour => healthBehaviour;
        public PushBehaviour PushBehaviour => pushBehaviour;
        public TargetBehaviour TargetBehaviour => targetBehaviour;
        public MoveBehaviour MoveBehaviour => moveBehaviour;
        public AttackBehaviour AttackBehaviour => attackBehaviour;
        public IReadOnlyList<OtherUnitBehaviour> AfterBehaviours => afterBehaviours;

        public IEnumerable<UnitBehaviour> UnitBehaviours
        {
            get
            {
                for (var i = 0; i < beforeBehaviours.Length; i++)
                {
                    var component = beforeBehaviours[i];
                    if (component == null)
                    {
                        continue;
                    }

                    yield return component;
                }

                yield return healthBehaviour;
                yield return targetBehaviour;
                yield return moveBehaviour;
                yield return attackBehaviour;

                for (var i = 0; i < afterBehaviours.Length; i++)
                {
                    var component = afterBehaviours[i];
                    if (component == null)
                    {
                        continue;
                    }

                    yield return component;
                }
            }
        }
    }
}

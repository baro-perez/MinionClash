using AlvaroPerez.MinionClash.DataModel.Behaviours.Attack;
using AlvaroPerez.MinionClash.DataModel.Behaviours.Health;
using AlvaroPerez.MinionClash.DataModel.Behaviours.Move;
using AlvaroPerez.MinionClash.DataModel.Behaviours.Other;
using AlvaroPerez.MinionClash.DataModel.Behaviours.Push;
using AlvaroPerez.MinionClash.DataModel.Behaviours.Targeting;
using AlvaroPerez.MinionClash.Model.Behaviours;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours
{
    [CreateAssetMenu(fileName = nameof(BehaviourCollectionConfig), menuName = "Data/" + nameof(BehaviourCollectionConfig), order = 1)]
    public class BehaviourCollectionConfig : ScriptableObject
    {
        [Header("Main behaviours")]
        // These will be assumed to be non-null
        [SerializeField] [Tooltip("Non-null")] private HealthBehaviourConfig healthBehaviour;
        [SerializeField] [Tooltip("Non-null")] private PushBehaviourConfig pushBehaviourConfig;
        [SerializeField] [Tooltip("Non-null")] private TargetBehaviourConfig targetBehaviour;
        [SerializeField] [Tooltip("Non-null")] private MoveBehaviourConfig moveBehaviour;
        [SerializeField] [Tooltip("Non-null")] private AttackBehaviourConfig attackBehaviour;

        [Header("Extra behaviours")]
        // These are optional and will be null-checked
        [SerializeField] private OtherUnitBehaviourConfig[] beforeBehaviours;
        [SerializeField] private OtherUnitBehaviourConfig[] afterBehaviours;

        public IReadOnlyList<OtherUnitBehaviourConfig> BeforeBehaviour => beforeBehaviours;
        public HealthBehaviourConfig HealthBehaviour => healthBehaviour;
        public PushBehaviourConfig PushBehaviourConfig => pushBehaviourConfig;
        public TargetBehaviourConfig TargetBehaviour => targetBehaviour;
        public MoveBehaviourConfig MoveBehaviour => moveBehaviour;
        public AttackBehaviourConfig AttackBehaviour => attackBehaviour;
        public IReadOnlyList<OtherUnitBehaviourConfig> AfterBehaviour => afterBehaviours;

        public BehaviourCollection Create()
        {
            return new BehaviourCollection(
                healthBehaviour.Create(),
                pushBehaviourConfig.Create(),
                targetBehaviour.Create(),
                moveBehaviour.Create(),
                attackBehaviour.Create(),
                beforeBehaviours.Select(b => b.Create()).ToArray(),
                afterBehaviours.Select(b => b.Create()).ToArray()
                );
        }
    }
}

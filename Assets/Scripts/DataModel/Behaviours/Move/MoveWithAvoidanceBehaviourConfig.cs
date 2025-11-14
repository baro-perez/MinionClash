using AlvaroPerez.MinionClash.Model.Behaviours.Move;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Move
{
    [CreateAssetMenu(fileName = nameof(MoveWithAvoidanceBehaviourConfig), menuName = "Data/Behaviours/" + nameof(MoveWithAvoidanceBehaviourConfig), order = 1)]
    public class MoveWithAvoidanceBehaviourConfig : MoveBehaviourConfig
    {
        [SerializeField] private float avoidanceDistance = 1.6f;
        [Tooltip("Multiplies speed")]
        [SerializeField] private float avoidanceStrengthFactor = 0.75f;
        [SerializeField] private MoveToTargetBehaviourConfig decorated = null;
        [SerializeField] private AnimationCurve strengthFactorCurve = AnimationCurve.Linear(0, 1, 1, 0);

        public override MoveBehaviour Create()
        {
            return new MoveWithAvoidanceBehaviour(
                avoidanceDistance,
                avoidanceStrengthFactor,
                strengthFactorCurve,
                decorated.Create());
        }
    }
}

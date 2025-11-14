using AlvaroPerez.MinionClash.Model.Behaviours.Move;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Move
{
    [CreateAssetMenu(fileName = nameof(MoveToTargetBehaviourConfig), menuName = "Data/Behaviours/" + nameof(MoveToTargetBehaviourConfig), order = 1)]
    public class MoveToTargetBehaviourConfig : MoveBehaviourConfig
    {
        [SerializeField] private float minDistance = 0.25f;

        public override MoveBehaviour Create()
        {
            return new MoveToTargetBehaviour(minDistance);
        }
    }
}

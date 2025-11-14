using AlvaroPerez.MinionClash.Model.Behaviours.Targeting;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Targeting
{
    [CreateAssetMenu(fileName = nameof(ClosestEnemyTargetBehaviourConfig), menuName = "Data/Behaviours/" + nameof(ClosestEnemyTargetBehaviourConfig), order = 1)]
    public class ClosestEnemyTargetBehaviourConfig : TargetBehaviourConfig
    {
        [SerializeField] private float retargetCooldown = 1f;

        public override TargetBehaviour Create()
        {
            return new ClosestEnemyTargetBehaviour(retargetCooldown);
        }
    }
}

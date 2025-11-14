using AlvaroPerez.MinionClash.Model.Behaviours.Attack;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Attack
{
    [CreateAssetMenu(fileName = nameof(InstantAttackBehaviourConfig), menuName = "Data/Behaviours/" + nameof(InstantAttackBehaviourConfig), order = 1)]
    public class InstantAttackBehaviourConfig : AttackBehaviourConfig
    {
        [SerializeField] private float minDistance = 0f;
        [SerializeField] private float maxDistance = 0.26f;
        [SerializeField] private float disallowMovementCooldown = 0.25f;

        public override AttackBehaviour Create()
        {
            return new InstantAttackBehaviour(minDistance, maxDistance, disallowMovementCooldown);
        }
    }
}

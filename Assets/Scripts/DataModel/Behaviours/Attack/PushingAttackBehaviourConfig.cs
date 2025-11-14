using AlvaroPerez.MinionClash.Model.Behaviours.Attack;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Attack
{
    [CreateAssetMenu(fileName = nameof(PushingAttackBehaviourConfig), menuName = "Data/Behaviours/" + nameof(PushingAttackBehaviourConfig), order = 1)]
    public class PushingAttackBehaviourConfig : AttackBehaviourConfig
    {
        [SerializeField] private AttackBehaviourConfig decorated;
        [SerializeField] private float pushStrength = 3f;

        public override AttackBehaviour Create()
        {
            return new PushingAttackBehaviour(decorated.Create(), pushStrength);
        }
    }
}

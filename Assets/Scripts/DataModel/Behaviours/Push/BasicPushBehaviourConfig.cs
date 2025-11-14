using AlvaroPerez.MinionClash.Model.Behaviours.Push;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Push
{
    [CreateAssetMenu(fileName = nameof(BasicPushBehaviourConfig), menuName = "Data/Behaviours/" + nameof(BasicPushBehaviourConfig), order = 1)]
    public class BasicPushBehaviourConfig : PushBehaviourConfig
    {
        [SerializeField] private float decay = 20f;

        public override PushBehaviour Create()
        {
            return new BasicPushBehaviour(decay);
        }
    }
}

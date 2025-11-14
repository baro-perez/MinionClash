using AlvaroPerez.MinionClash.Model.Behaviours.Health;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel.Behaviours.Health
{
    [CreateAssetMenu(fileName = nameof(BasicHealthBehaviourConfig), menuName = "Data/Behaviours/" + nameof(BasicHealthBehaviourConfig), order = 1)]
    public class BasicHealthBehaviourConfig : HealthBehaviourConfig
    {
        public override HealthBehaviour Create()
        {
            return new BasicHealthBehaviour();
        }
    }
}

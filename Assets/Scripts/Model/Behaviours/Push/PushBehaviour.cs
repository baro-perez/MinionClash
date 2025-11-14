using AlvaroPerez.MinionClash.Model.Units;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Push
{
    public abstract class PushBehaviour : UnitBehaviour, IPushBehaviour
    {
        public abstract void ApplyPush(Vector2 pushVelocity);
        public abstract void GetVelocity(IUnit self, float deltaTime, out Vector2 pushVelocity, out float pushMoveFactor);
    }
}

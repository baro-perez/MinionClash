using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Push
{
    public class Push
    {
        private Vector2 maxPush;
        private float maxMagnitude;
        private Vector2 currentPush;

        public Push(Vector2 pushVelocity)
        {
            this.maxPush = pushVelocity;
            this.maxMagnitude = maxPush.magnitude;
            this.currentPush = pushVelocity;
        }

        public bool GetPushVelocity(float deltaTime, float decay, out Vector2 pushVelocity, out float pushMoveFactor)
        {
            if (currentPush == Vector2.zero)
            {
                pushVelocity = Vector2.zero;
                pushMoveFactor = 1f;
                return false;
            }

            var prevPush = currentPush;
            var magnitude = currentPush.magnitude;
            var normalized = currentPush / magnitude;
            currentPush -= normalized * decay * deltaTime;
            if (Vector2.Dot(prevPush, currentPush) <= 0)
            {
                currentPush = Vector2.zero;
            }

            pushMoveFactor = 1 - magnitude / maxMagnitude;
            pushVelocity = prevPush;

            return true;
        }
    }
}


using AlvaroPerez.MinionClash.Model.Units;
using System.Collections.Generic;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model.Behaviours.Push
{
    public class BasicPushBehaviour : PushBehaviour, IPushBehaviour
    {
        private float decay;

        public List<Push> pushes = new List<Push>();

        public BasicPushBehaviour(float decay)
        {
            this.decay = decay;
        }

        public override void ApplyPush(Vector2 pushVelocity)
        {
            pushes.Add(new Push(pushVelocity));
        }

        public override void GetVelocity(IUnit self, float deltaTime, out Vector2 pushVelocity, out float pushMoveFactor)
        {
            pushMoveFactor = 1f;
            pushVelocity = Vector2.zero;

            for (var i = pushes.Count - 1; i >= 0; --i)
            {
                var push = pushes[i];
                if (push.GetPushVelocity(deltaTime, decay, out var thisPushVelocity, out var thisPushMoveFactor))
                {
                    pushVelocity += thisPushVelocity;
                    pushMoveFactor *= thisPushMoveFactor;
                }
                else
                {
                    pushes.RemoveAt(i);
                }
            }
        }
    }
}

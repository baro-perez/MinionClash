using AlvaroPerez.MinionClash.Model.Traps;
using AlvaroPerez.MinionClash.Utils;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Main
{
    public class BombView : MonoBehaviour
    {
        [SerializeField] private Transform areaOfEffect;

        private Bomb model;
        private bool inited;

        public void SetBomb(Bomb bomb)
        {
            Unsubscribe();
            model = bomb;
            transform.position = bomb.Position.ToVectorXZ();
            SetRadius(bomb.CurrentRadius);
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            inited = true;
            model.OnRadiusChanged += OnRadiusChanged;
        }

        private void Unsubscribe()
        {
            if (inited)
            {
                model.OnRadiusChanged -= OnRadiusChanged;
                inited = false;
            }
        }

        private void OnRadiusChanged(Bomb caller, BombEvents.RadiusChangedData data)
        {
            SetRadius(data.newRadius);
        }

        private void SetRadius(float currentRadius)
        {
            var areaOfEffect = this.areaOfEffect != null ? this.areaOfEffect : transform;

            var parentScale = areaOfEffect.parent == null ? Vector3.one : areaOfEffect.parent.lossyScale;
            var scale = Vector3.one * currentRadius;
            var localScale = new Vector3(
                scale.x / parentScale.x,
                scale.y / parentScale.y,
                scale.z / parentScale.z);
            areaOfEffect.localScale = localScale;
        }
    }
}
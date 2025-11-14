using AlvaroPerez.MinionClash.Model.Traps;
using UnityEngine;

namespace AlvaroPerez.MinionClash.DataModel
{
    [CreateAssetMenu(fileName = nameof(BombConfig), menuName = "Data/" + nameof(BombConfig), order = 1)]
    public class BombConfig : ScriptableObject
    {
        [SerializeField] private float initialRadius = 1f;
        [SerializeField] private float expandRadius = 8f;
        [SerializeField] private float expandSpeed = 7f;
        [SerializeField] private float atkOnCenter = 40;
        [SerializeField] private float atkOnEdge = 5f;
        [SerializeField] private float pushOnCenter = 30f;
        [SerializeField] private float pushOnEdge = 5f;

        private float InitialRadius => initialRadius;
        private float ExpandRadius => expandRadius;
        private float ExpandSpeed => expandSpeed;
        private float AtkOnCenter => atkOnCenter;
        private float AtkOnEdge => atkOnEdge;
        private float PushOnCenter => pushOnCenter;
        private float PushOnEdge => pushOnEdge;

        public Bomb Create(Vector2 modelPosition)
        {
            return new Bomb(modelPosition,
                initialRadius, expandRadius, expandSpeed,
                atkOnCenter, atkOnEdge,
                pushOnCenter, pushOnEdge);
        }
    }
}

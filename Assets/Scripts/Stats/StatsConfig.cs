using AlvaroPerez.MinionClash.Model.Units;
using UnityEngine;

namespace AlvaroPerez.MinionClash.UnitStats
{
    [CreateAssetMenu(fileName = nameof(StatsConfig), menuName = "Data/" + nameof(StatsConfig), order = 1)]
    public class StatsConfig : ScriptableObject
    {
        [SerializeField] private SerializableStats baseStats;

        [Header("Shape extra stats")]
        [SerializeField] private SerializableStats cubeStats;
        [SerializeField] private SerializableStats sphereStats;

        [Header("Size extra stats")]
        [SerializeField] private SerializableStats bigStats;
        [SerializeField] private SerializableStats smallStats;

        [Header("Color extra stats")]
        [SerializeField] private SerializableStats redStats;
        [SerializeField] private SerializableStats greenStats;
        [SerializeField] private SerializableStats blueStats;

        public Stats CreateStats(UnitClass unitClass)
        {
            var shapeExtraStats = unitClass.shape switch
            {
                UnitClass.Shape.Cube => cubeStats,
                UnitClass.Shape.Sphere => sphereStats,
                _ => throw new System.IndexOutOfRangeException(),
            };

            var sizeExtraStats = unitClass.size switch
            {
                UnitClass.Size.Big => bigStats,
                UnitClass.Size.Small => smallStats,
                _ => throw new System.IndexOutOfRangeException(),
            };

            var colorExtraStats = unitClass.color switch
            {
                UnitClass.Color.Red => redStats,
                UnitClass.Color.Green => greenStats,
                UnitClass.Color.Blue => blueStats,
                _ => throw new System.IndexOutOfRangeException(),
            };

            return baseStats + shapeExtraStats + sizeExtraStats + colorExtraStats;
        }
    }
}

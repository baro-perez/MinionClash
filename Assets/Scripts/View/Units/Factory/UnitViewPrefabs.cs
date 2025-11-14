using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;
using System;
using UnityEngine;

namespace AlvaroPerez.MinionClash.View.Units.Factory
{
    [CreateAssetMenu(fileName = nameof(UnitViewPrefabs), menuName = "Data/" + nameof(UnitViewPrefabs), order = 1)]
    public class UnitViewPrefabs : ScriptableObject
    {
        [SerializeField] private UnitView smallCubePrefab;
        [SerializeField] private UnitView bigCubePrefab;
        [SerializeField] private UnitView smallSpherePrefab;
        [SerializeField] private UnitView bigSpherePrefab;

        public UnitView GetPrefab(UnitClass unitClass)
        {
            var prefab = unitClass.shape switch
            {
                UnitClass.Shape.Cube => unitClass.size switch
                {
                    UnitClass.Size.Small => smallCubePrefab,
                    UnitClass.Size.Big => bigCubePrefab,
                    _ => throw new IndexOutOfRangeException(),
                },
                UnitClass.Shape.Sphere => unitClass.size switch
                {
                    UnitClass.Size.Small => smallSpherePrefab,
                    UnitClass.Size.Big => bigSpherePrefab,
                    _ => throw new IndexOutOfRangeException(),
                },
                _ => throw new IndexOutOfRangeException(),
            };

            if (prefab == null)
            {
                throw new InvalidOperationException();
            }

            return prefab;
        }
    }
}

using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;
using System;
using UnityEngine;

namespace AlvaroPerez.MinionClash.View.Units.Factory
{
    [Serializable]
    public class UnitViewFactory : IUnitViewFactory
    {
        [SerializeField] private UnitViewPrefabs prefabs;

        public UnitView SpawnUnit(Team team, UnitClass unitClass)
        {
            var prefab = prefabs.GetPrefab(unitClass);

            var unitInstance = UnityEngine.Object.Instantiate(prefab.gameObject);
            var unit = unitInstance.GetComponent<UnitView>();
            unit.InitVisuals(team, unitClass);
            return unit;
        }

        public void DespawnUnitView(UnitView unit)
        {
            UnityEngine.Object.Destroy(unit.gameObject);
        }
    }
}

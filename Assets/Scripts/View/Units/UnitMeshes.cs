using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;
using System;
using UnityEngine;

namespace AlvaroPerez.MinionClash.View.Units
{
    [Serializable]
    public class UnitMeshes
    {
        [SerializeField] private Transform pivot;
        [SerializeField] private UnitClassMeshes unitClassMeshes;

        [Header("Unit base")]
        [SerializeField] private Renderer baseRenderer;
        [SerializeField] private Material allyMaterial;
        [SerializeField] private Material enemyMaterial;

        public Transform Pivot => pivot;

        public void Init(Team team, UnitClass unitClass)
        {
            SetBaseMaterial(team);
            unitClassMeshes.SetMeshesMaterials(team, unitClass);
        }

        private void SetBaseMaterial(Team team)
        {
            var baseMaterial = team switch
            {
                Team.Ally => allyMaterial,
                Team.Enemy => enemyMaterial,
                _ => null,
            };

            if (baseRenderer == null)
            {
                return;
            }

            baseRenderer.sharedMaterial = baseMaterial;
        }
    }
}

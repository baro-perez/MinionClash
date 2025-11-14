using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;
using System.Collections.Generic;
using UnityEngine;

namespace AlvaroPerez.MinionClash.View.Units
{
    public class UnitClassMeshes : MonoBehaviour
    {
        private static Dictionary<Material, Material> enemyMaterials = new Dictionary<Material, Material>();
        private static readonly Color enemyColorFactor = new Color(0.6f, 0.6f, 0.6f, 1f);

        [SerializeField] private Renderer[] uncoloredModelMeshes;
        [SerializeField] private Renderer[] coloredModelMeshes;
        [SerializeField] private Material redMaterial;
        [SerializeField] private Material greenMaterial;
        [SerializeField] private Material blueMaterial;

        public void SetMeshesMaterials(Team team, UnitClass unitClass)
        {
            var coloredMaterial = GetColoredMaterial(team, unitClass);

            foreach (var renderer in coloredModelMeshes)
            {
                if (renderer == null)
                {
                    continue;
                }

                renderer.sharedMaterial = coloredMaterial;
            }

            foreach (var renderer in uncoloredModelMeshes)
            {
                if (renderer == null)
                {
                    continue;
                }

                if (team == Team.Enemy)
                {
                    var enemyMaterial = GetEnemyMaterial(renderer.sharedMaterial);
                    renderer.sharedMaterial = GetEnemyMaterial(enemyMaterial); ;
                }

            }
        }

        private Material GetColoredMaterial(Team team, UnitClass unitClass)
        {
            // Possible improvement if game got more complex: the material is dependant on each render
            // (different materials for each mesh)
            // In this case we would probably create a component on each renderer with this info,
            // or create a dictionary-like structure in this component Renderer->{RGB materials}
            var coloredMaterial = unitClass.color switch
            {
                UnitClass.Color.Red => redMaterial,
                UnitClass.Color.Green => greenMaterial,
                UnitClass.Color.Blue => blueMaterial,
                _ => throw new System.IndexOutOfRangeException(),
            };

            if (team == Team.Enemy)
            {
                coloredMaterial = GetEnemyMaterial(coloredMaterial);
            }

            return coloredMaterial;
        }

        private static Material GetEnemyMaterial(Material originalMaterial)
        {
            if (!enemyMaterials.TryGetValue(originalMaterial, out var enemyMaterial))
            {
                // Create a new material: enemies are darker (in lieu of having colored teams)
                enemyMaterial = Instantiate(originalMaterial);
                enemyMaterial.color = originalMaterial.color * enemyColorFactor;

                enemyMaterials[originalMaterial] = enemyMaterial;
            }

            return enemyMaterial;
        }
    }
}

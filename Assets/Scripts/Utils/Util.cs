using AlvaroPerez.MinionClash.Model.Behaviours;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils
{
    public static class Util
    {
        public static Vector3 ToVectorXZ(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0, vector2.y);
        }
        public static Vector2 FromVectorXZ(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        public static Dictionary<Type, Array> enumValues = new Dictionary<Type, Array>();
        
        public static Array GetEnumValues<T>() where T : Enum
        {
            return GetEnumValues(typeof(T));
        }

        private static Array GetEnumValues(Type type)
        {
            if (!enumValues.TryGetValue(type, out var array))
            {
                array = Enum.GetValues(type);
                enumValues[type] = array;
            }
            return array;
        }

        public static T GetRandEnum<T>() where T: Enum
        {
            Array values = GetEnumValues<T>();
            var index = UnityEngine.Random.Range(0, values.Length);
            return (T)values.GetValue(index);
        }

        public static T RandomFromList<T>(IReadOnlyList<T> items)
        {
            var index = UnityEngine.Random.Range(0, items.Count);
            return items[index];
        }

        public static T GetWeightedRandEnum<T>(params float[] chances) where T : Enum
        {
            Array values = GetEnumValues<T>();
            return GetWeightedRand<T>(chances, values);
        }

        public static T GetWeightedRand<T>(float[] chances, Array values)
        {
            var chanceSum = 0f;
            for (var i = 0; i < chances.Length; i++)
            {
                var chance = chances[i];
                chanceSum += chance;
            }

            if (chanceSum == 0)
            {
                return default;
            }

            var drawn = UnityEngine.Random.Range(0, chanceSum);
            for (var i = 0; i < chances.Length; i++)
            {
                var chance = chances[i];
                if (chance == 0)
                {
                    continue;
                }

                if (drawn <= chance)
                {
                    return (T)values.GetValue(i);
                }

                drawn -= chance;
            }
            return default;
        }

        public static Vector3? IntersectPlaneRay(
            Vector3 planePos, Vector3 planeUp, Vector3 rayOrigin, Vector3 rayForward)
        {
            float d = Vector3.Dot(rayForward, planeUp);
            if (d != 0)
            {
                float t = Vector3.Dot(planePos - rayOrigin, planeUp) / d;
                return rayOrigin + rayForward * t;
            }
            else
            {
                return default;
            }
        }
    }

}

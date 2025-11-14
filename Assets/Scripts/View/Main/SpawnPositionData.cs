using UnityEngine;
using System;

namespace AlvaroPerez.MinionClash.Main
{
    [Serializable]
    public class SpawnPositionData
    {
        [SerializeField] private Transform unitsParent;
        [SerializeField] private Transform spawnOriginEnemy;
        [SerializeField] private Transform spawnOriginAlly;
        [SerializeField] private Vector2 spawnSpan;

        public Transform UnitsParent => unitsParent;
        public Transform SpawnOriginEnemy => spawnOriginEnemy;
        public Transform SpawnOriginAlly => spawnOriginAlly;
        public Vector2 SpawnSpan => spawnSpan;
    }
}
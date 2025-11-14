using AlvaroPerez.MinionClash.Model.Units;
using System;
using UnityEngine;

namespace AlvaroPerez.MinionClash.UnitStats
{
    [Serializable]
    public class StatsFactory : IStatsFactory
    {
        [SerializeField] private StatsConfig config;

        public Stats CreateStats(UnitClass unitClass)
        {
            return config.CreateStats(unitClass);
        }
    }
}

using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.UnitStats
{
    public interface IStatsFactory
    {
        Stats CreateStats(UnitClass unitClass);
    }
}

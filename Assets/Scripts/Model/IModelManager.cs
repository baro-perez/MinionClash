using AlvaroPerez.MinionClash.UnitStats;
using AlvaroPerez.MinionClash.Model.Traps;
using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Model
{
    public interface IModelManagers
    {
        IUnitManager UnitManager { get; }
        IStatsFactory StatsFactory { get; }
        ITrapManager TrapManager { get; }
    }
}
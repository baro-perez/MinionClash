using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.View.Units.Factory
{
    public interface IUnitViewFactory
    {
        UnitView SpawnUnit(Team team, UnitClass unitClass);
        void DespawnUnitView(UnitView unit);
    }
}

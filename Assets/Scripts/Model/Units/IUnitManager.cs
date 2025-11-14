using System.Collections.Generic;

namespace AlvaroPerez.MinionClash.Model.Units
{
    public interface IUnitManager
    {
        IReadOnlyList<IUnit> GetTeam(Team team);
        IEnumerable<IUnit> AllUnits { get; }

        /// <summary>
        /// Removal is managed by <see cref="IUnitManager"/>
        /// </summary>
        void AddUnit(IUnit unitView);

        void RemoveAllUnits();

        event UnitManagerEvents.OnUnitAddedFn OnUnitAdded;
        event UnitManagerEvents.OnUnitRemovedFn OnUnitRemoved;

    }
}

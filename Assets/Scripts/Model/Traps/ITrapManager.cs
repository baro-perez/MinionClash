using System.Collections.Generic;

namespace AlvaroPerez.MinionClash.Model.Traps
{
    public interface ITrapManager
    {
        IReadOnlyList<ITrap> Traps { get; }

        void AddTrap(ITrap unit);
        void RemoveTrap(ITrap unit);

        event TrapManagerEvents.OnTrapAddedFn OnTrapAdded;
        event TrapManagerEvents.OnTrapRemovedFn OnTrapRemoved;
    }
}

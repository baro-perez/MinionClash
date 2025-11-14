using System.Collections.Generic;

namespace AlvaroPerez.MinionClash.Model.Traps
{
    public class TrapManager : ITrapManager
    {
        private List<ITrap> traps = new List<ITrap>();
        public IReadOnlyList<ITrap> Traps => traps;

        public event TrapManagerEvents.OnTrapAddedFn OnTrapAdded;
        public event TrapManagerEvents.OnTrapRemovedFn OnTrapRemoved;

        public void AddTrap(ITrap trap)
        {
            traps.Add(trap);
            SubscribeToTrap(trap);
            OnTrapAdded?.Invoke(this, new TrapManagerEvents.TrapAddedEventData(trap));
        }

        public void RemoveTrap(ITrap trap)
        {
            RemoveTrapImpl(trap);
            traps.Remove(trap);
        }

        private void RemoveTrapImpl(ITrap Trap)
        {
            UnsubscribeToTrap(Trap);
            OnTrapRemoved?.Invoke(this, new TrapManagerEvents.TrapRemovedEventData(Trap));
        }

        public void RemoveAllTraps()
        {
            for (var i = Traps.Count - 1; i >= 0; --i)
            {
                var trap = traps[i];
                RemoveTrapImpl(trap);
                traps.RemoveAt(i);
            }
        }

        private void SubscribeToTrap(ITrap Trap)
        {
            if (Trap != null)
            {
                Trap.OnDie += OnTrapDead;
            }
        }

        private void UnsubscribeToTrap(ITrap Trap)
        {
            if (Trap != null)
            {
                Trap.OnDie -= OnTrapDead;
            }
        }

        private void OnTrapDead(ITrap trap, TrapEvents.DieEventData data)
        {
            RemoveTrap(trap);
        }
    }
}

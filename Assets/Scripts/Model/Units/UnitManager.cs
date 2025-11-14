using System.Collections.Generic;
using System.Linq;

namespace AlvaroPerez.MinionClash.Model.Units
{
    public class UnitManager : IUnitManager
    {
        private IReadOnlyDictionary<Team, List<IUnit>> teams =
            new Dictionary<Team, List<IUnit>>
            {
                { Team.Ally, new List<IUnit>() },
                { Team.Enemy, new List<IUnit>() },
            };

        public event UnitManagerEvents.OnUnitAddedFn OnUnitAdded;
        public event UnitManagerEvents.OnUnitRemovedFn OnUnitRemoved;

        public IEnumerable<IUnit> AllUnits => teams[Team.Ally].Concat(teams[Team.Enemy]);

        public void AddUnit(IUnit unit)
        {
            var list = GetTeamList(unit.Team);
            list.Add(unit);
            SubscribeToUnit(unit);
            OnUnitAdded?.Invoke(this, new UnitManagerEvents.UnitAddedEventData(unit));
        }

        private List<IUnit> GetTeamList(Team team)
        {
            if (!teams.TryGetValue(team, out var list))
            {
                throw new System.ArgumentOutOfRangeException($"{nameof(team)}={team}");
            }

            return list;
        }

        public IReadOnlyList<IUnit> GetTeam(Team team)
        {
            return GetTeamList(team);
        }

        public void RemoveUnit(IUnit unit)
        {
            var list = GetTeamList(unit.Team);
            list.Remove(unit);
            RemoveUnitImpl(unit);
        }

        private void RemoveUnitImpl(IUnit unit)
        {
            UnsubscribeToUnit(unit);
            OnUnitRemoved?.Invoke(this, new UnitManagerEvents.UnitRemovedEventData(unit));
        }

        public void RemoveAllUnits()
        {
            foreach (var item in teams)
            {
                var team = item.Value;
                for (var i = team.Count - 1; i >= 0; --i)
                {
                    var unit = team[i];
                    RemoveUnitImpl(unit);
                    team.RemoveAt(i);
                }
            }
        }

        private void SubscribeToUnit(IUnit unit)
        {
            if (unit != null)
            {
                unit.OnDie += OnUnitDead;
            }
        }

        private void UnsubscribeToUnit(IUnit unit)
        {
            if (unit != null)
            {
                unit.OnDie -= OnUnitDead;
            }
        }

        private void OnUnitDead(IUnit unit, UnitEvents.DieEventData data)
        {
            RemoveUnit(unit);
        }
    }
}

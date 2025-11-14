using AlvaroPerez.MinionClash.Model;
using System.Collections.Generic;
using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Main
{
    public class UnitViewManager
    {
        private Dictionary<IUnit, UnitView> model2view = new Dictionary<IUnit, UnitView>();

        public void Add(IUnit unit, UnitView unitView)
        {
            model2view[unit] = unitView;
            OnUnitViewAdded?.Invoke(this, new UnitViewManagerEvents.UnitViewAddedEventData(unitView));
        }

        public void Remove(IUnit unit)
        {
            var unitView = GetUnitview(unit);
            OnUnitViewRemoved?.Invoke(this, new UnitViewManagerEvents.UnitViewRemovedEventData(unitView));
            model2view.Remove(unit);
        }

        public UnitView GetUnitview(IUnit unit)
        {
            return model2view[unit];
        }

        public event UnitViewManagerEvents.OnUnitViewAddedFn OnUnitViewAdded;
        public event UnitViewManagerEvents.OnUnitViewRemovedFn OnUnitViewRemoved;
    }
}
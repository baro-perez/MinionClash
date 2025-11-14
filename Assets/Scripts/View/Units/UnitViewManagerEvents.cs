using AlvaroPerez.MinionClash.Model;

namespace AlvaroPerez.MinionClash.Main
{
    public static class UnitViewManagerEvents
    {
        public readonly struct UnitViewAddedEventData
        {
            public readonly UnitView unitView;

            public UnitViewAddedEventData(UnitView unitView)
            {
                this.unitView = unitView;
            }
        }
        public delegate void OnUnitViewAddedFn(object caller, UnitViewAddedEventData data);

        public readonly struct UnitViewRemovedEventData
        {
            public readonly UnitView unitView;

            public UnitViewRemovedEventData(UnitView unitView)
            {
                this.unitView = unitView;
            }
        }
        public delegate void OnUnitViewRemovedFn(object caller, UnitViewRemovedEventData data);
    }
}
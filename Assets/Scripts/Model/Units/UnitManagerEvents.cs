namespace AlvaroPerez.MinionClash.Model.Units
{
    public static class UnitManagerEvents
    {
        public readonly struct UnitAddedEventData
        {
            public readonly IUnit unit;

            public UnitAddedEventData(IUnit unit)
            {
                this.unit = unit;
            }
        }
        public delegate void OnUnitAddedFn(object caller, UnitAddedEventData data);

        public readonly struct UnitRemovedEventData
        {
            public readonly IUnit unit;

            public UnitRemovedEventData(IUnit unit)
            {
                this.unit = unit;
            }
        }
        public delegate void OnUnitRemovedFn(object caller, UnitRemovedEventData data);
    }
}

namespace AlvaroPerez.MinionClash.Model.Traps
{
    public static class TrapManagerEvents
    {
        public readonly struct TrapAddedEventData
        {
            public readonly ITrap trap;

            public TrapAddedEventData(ITrap trap)
            {
                this.trap = trap;
            }
        }
        public delegate void OnTrapAddedFn(ITrapManager caller, TrapAddedEventData data);

        public readonly struct TrapRemovedEventData
        {
            public readonly ITrap trap;

            public TrapRemovedEventData(ITrap trap)
            {
                this.trap = trap;
            }
        }
        public delegate void OnTrapRemovedFn(ITrapManager caller, TrapRemovedEventData data);
    }
}

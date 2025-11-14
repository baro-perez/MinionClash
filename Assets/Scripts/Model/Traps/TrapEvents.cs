namespace AlvaroPerez.MinionClash.Model.Traps
{
    public static class TrapEvents
    {
        public readonly struct DieEventData { }
        public delegate void OnDieFn(ITrap caller, DieEventData data);
    }
}

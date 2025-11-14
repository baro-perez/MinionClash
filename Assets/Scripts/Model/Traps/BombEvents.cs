namespace AlvaroPerez.MinionClash.Model.Traps
{
    public static class BombEvents
    {
        public readonly struct RadiusChangedData
        {
            public readonly float prevRadius;
            public readonly float newRadius;

            public RadiusChangedData(float prevRadius, float newRadius)
            {
                this.prevRadius = prevRadius;
                this.newRadius = newRadius;
            }
        }

        public delegate void OnRadiusChangedFn(Bomb caller, RadiusChangedData data);
    }
}

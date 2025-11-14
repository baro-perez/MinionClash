namespace AlvaroPerez.MinionClash.UnitStats
{
    public readonly struct Stats
    {
        public readonly float atk;
        public readonly float hp;
        public readonly float speed;
        public readonly float atkspd;

        public Stats(float atk, float hp, float speed, float atkspd)
        {
            this.atk = atk;
            this.hp = hp;
            this.speed = speed;
            this.atkspd = atkspd;
        }

        public static Stats operator +(Stats a, Stats b)
        {
            return new Stats(
                a.atk + b.atk,
                a.hp + b.hp,
                a.speed + b.speed,
                a.atkspd + b.atkspd);
        }
    }
}

using UnityEngine;

namespace AlvaroPerez.MinionClash.UnitStats
{
    [System.Serializable]
    public struct SerializableStats
    {
        [SerializeField] private float atk;
        [SerializeField] private float hp;
        [SerializeField] private float speed;
        [SerializeField] private float atkspd;

        public SerializableStats(float atk, float hp, float speed, float atkspd)
        {
            this.atk = atk;
            this.hp = hp;
            this.speed = speed;
            this.atkspd = atkspd;
        }

        public float Atk => atk;
        public float Hp => hp;
        public float Speed => speed;
        public float Atkspd => atkspd;

        public static implicit operator Stats(SerializableStats serializableStats)
        {
            return new Stats(serializableStats.atk, serializableStats.hp, serializableStats.speed, serializableStats.atkspd);
        }

        public static SerializableStats operator +(SerializableStats a, SerializableStats b)
        {
            return new SerializableStats(
                a.atk + b.atk,
                a.hp + b.hp,
                a.speed + b.speed,
                a.atkspd + b.atkspd);
        }
    }
}

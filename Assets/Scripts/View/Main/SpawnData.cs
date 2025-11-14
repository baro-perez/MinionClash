using AlvaroPerez.MinionClash.DataModel.Behaviours;
using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Main
{
    public readonly struct SpawnData
    {
        public readonly float time;
        public readonly Team team;
        public readonly UnitClass unitClass;
        public readonly BehaviourCollectionConfig behaviours;

        public SpawnData(float time, Team team, UnitClass unitClass, BehaviourCollectionConfig behaviours)
        {
            this.time = time;
            this.team = team;
            this.unitClass = unitClass;
            this.behaviours = behaviours;
        }
    }
}
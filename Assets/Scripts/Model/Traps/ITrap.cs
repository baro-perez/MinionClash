using AlvaroPerez.MinionClash.Model;

namespace AlvaroPerez.MinionClash.Model.Traps
{
    public interface ITrap
    {
        void Tick(IModelManagers modelManagers, float deltaTime);

        event TrapEvents.OnDieFn OnDie;
    }
}

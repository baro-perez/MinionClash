using AlvaroPerez.MinionClash.Model.Units;
using System;

namespace AlvaroPerez.MinionClash.Model.Behaviours
{
    public abstract class UnitBehaviour
    {
        protected IModelManagers ModelManagers { get; private set; }

        public void Init(IModelManagers modelManagers, IUnit self)
        {
            ModelManagers = modelManagers;
            InitImpl(modelManagers, self);
        }

        protected virtual void InitImpl(IModelManagers modelManagers, IUnit self)
        {
        }

        public virtual bool AllowMovement(IUnit self)
        {
            return true;
        }
    }
}

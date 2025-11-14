using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Behaviours.Health;
using AlvaroPerez.MinionClash.Utils.Ui.Mvvm;
using System;

namespace AlvaroPerez.MinionClash.Ui.Hud
{
    public class UnitViewModel : ViewModel<UnitView>
    {
        private UnitView unit;
        public override UnitView Model
        {
            get => unit;
            set
            {
                Unsubscribe();
                unit = value;
                Subscribe();
                unit.Model.HealthBehaviour.OnHealthChanged += OnHealthChanged;

                Health = unit.Model.HealthBehaviour.CurrentHealth;
                MaxHealth = unit.Model.Stats.hp;
                RefreshAllBindings();
            }
        }

        public Team Team => Model?.Team ?? Team.None;
        public bool IsAlly => Team == Team.Ally;
        public bool IsEnemy => Team == Team.Enemy;

        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public float HealthPercentage => Health / MaxHealth;

        protected override void PopulateBindings()
        {
            RegisterBinding(nameof(Team), () => Team, f => { });
            RegisterBinding(nameof(IsAlly), () => IsAlly, f => { });
            RegisterBinding(nameof(IsEnemy), () => IsEnemy, f => { });
            RegisterBinding(nameof(Health), () => Health, f => {} );
            RegisterBinding(nameof(MaxHealth), () => MaxHealth, f => {} );
            RegisterBinding(nameof(HealthPercentage), () => HealthPercentage, f => {} );
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            if (Model != null)
            {
                unit.Model.HealthBehaviour.OnHealthChanged += OnHealthChanged;
            }
        }

        private void Unsubscribe()
        {
            if (Model != null)
            {
                unit.Model.HealthBehaviour.OnHealthChanged -= OnHealthChanged;
            }
        }

        private void OnHealthChanged(IHealthBehaviour caller, HealthBehaviourEvents.HealthChangedEventData data)
        {
            Health = data.currentHealth;
            RefreshAllBindings();
        }
    }
}
using AlvaroPerez.MinionClash.Utils.Ui.Mvvm;
using System;
using UnityEngine;

namespace AlvaroPerez.MinionClash.UI.HUD
{
    public class BombSpawnerViewModel : ViewModel
    {
        [SerializeField] private BombSpawner bombSpawner;

        public float BombCooldown => bombSpawner.BombCooldown;
        public float CurrentBombCooldown => bombSpawner.CurrentBombCooldown;
        public float BombChargePercent => 1 - Mathf.Clamp01(CurrentBombCooldown / BombCooldown);

        private void Start()
        {
            bombSpawner.OnCurrentBombCooldownChanged += OnCurrentBombCooldownChanged;
        }

        private void OnDestroy()
        {
            bombSpawner.OnCurrentBombCooldownChanged -= OnCurrentBombCooldownChanged;
        }

        private void OnCurrentBombCooldownChanged()
        {
            RefreshAllBindings();
        }

        protected override void PopulateBindings()
        {
            RegisterBinding(nameof(BombCooldown), () => BombCooldown, f => { });
            RegisterBinding(nameof(CurrentBombCooldown), () => CurrentBombCooldown, f => { });
            RegisterBinding(nameof(BombChargePercent), () => BombChargePercent, f => { });
        }
    }
}

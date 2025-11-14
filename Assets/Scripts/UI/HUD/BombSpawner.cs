using AlvaroPerez.MinionClash.DataModel;
using AlvaroPerez.MinionClash.Main;
using AlvaroPerez.MinionClash.Utils;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AlvaroPerez.MinionClash.UI.HUD
{
    public class BombSpawner : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Camera worldCamera;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BombConfig bombConfig;


        [SerializeField] private float bombCooldown = 5f;

        public event Action OnCurrentBombCooldownChanged;

        public float BombCooldown => bombCooldown;
        private float currentBombCooldown;
        public float CurrentBombCooldown
        {
            get => currentBombCooldown;
            private set
            {
                currentBombCooldown = value;
                OnCurrentBombCooldownChanged?.Invoke();
            }
        }

        private void Start()
        {
            CurrentBombCooldown = 0f;
        }

        private void Update()
        {
            CurrentBombCooldown -= Time.deltaTime;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (CurrentBombCooldown > 0)
            {
                return;
            }

            var ray = worldCamera.ScreenPointToRay(eventData.position);
            var position = Util.IntersectPlaneRay(Vector3.zero, Vector3.up, ray.origin, ray.direction);

            if (!position.HasValue)
            {
                return;
            }

            var bomb = bombConfig.Create(position.Value.FromVectorXZ());
            gameManager.TrapViewManager.SpawnBombView(bomb);
            gameManager.TrapManager.AddTrap(bomb);
            CurrentBombCooldown = bombCooldown;
        }
    }
}

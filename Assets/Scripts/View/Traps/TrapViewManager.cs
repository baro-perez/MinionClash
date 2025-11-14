using System;
using AlvaroPerez.MinionClash.Model.Traps;
using System.Collections.Generic;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Main
{
    [Serializable]
    public class TrapViewManager
    {
        [SerializeField] private BombView bombViewPrefab;
        [SerializeField] private Transform bombParent;

        private Dictionary<ITrap, GameObject> model2view = new Dictionary<ITrap, GameObject>();

        private GameManager gameManager;
        public GameManager GameManager
        {
            get => gameManager;
            set
            {
                UnsubscribeToGameManger();
                gameManager = value;
                SubscribeToGameManger();
            }
        }

        public void OnDestroy()
        {
            UnsubscribeToGameManger();
        }

        private void SubscribeToGameManger()
        {
            if (gameManager != null)
            {
                gameManager.TrapManager.OnTrapRemoved += OnTrapRemoved;
            }
        }

        private void UnsubscribeToGameManger()
        {
            if (gameManager != null)
            {
                gameManager.TrapManager.OnTrapRemoved -= OnTrapRemoved;
            }
        }

        public BombView SpawnBombView(Bomb newBomb)
        {
            var bombViewGO = UnityEngine.Object.Instantiate(bombViewPrefab.gameObject);
            bombViewGO.transform.SetParent(bombParent, false);
            var bombView = bombViewGO.GetComponent<BombView>();
            bombView.SetBomb(newBomb);

            model2view.Add(newBomb, bombViewGO);

            return bombView;
        }

        private void OnTrapRemoved(object caller, TrapManagerEvents.TrapRemovedEventData data)
        {
            var trapView = model2view[data.trap];
            UnityEngine.Object.Destroy(trapView);
        }
    }
}
using UnityEngine;
using System;
using AlvaroPerez.MinionClash.Model;
using System.Collections.Generic;
using AlvaroPerez.MinionClash.Utils;
using AlvaroPerez.MinionClash.Model.Units;

namespace AlvaroPerez.MinionClash.Main
{
    [Serializable]
    public class UnitSpawner
    {
        public SpawnPositionData SpawnPositionData { get; set; }

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

        private void SubscribeToGameManger()
        {
            if (gameManager != null)
            {
                gameManager.UnitManager.OnUnitRemoved += OnUnitRemoved;
            }
        }

        private void UnsubscribeToGameManger()
        {
            if (gameManager != null)
            {
                gameManager.UnitManager.OnUnitRemoved -= OnUnitRemoved;
            }
        }

        public bool HasFinished => spawnDatas.Count == 0;

        private float currentTime;

        private Queue<SpawnData> spawnDatas = new Queue<SpawnData>();

        public void Tick(float deltaTime)
        {
            currentTime += deltaTime;

            while (spawnDatas.Count > 0 && spawnDatas.Peek().time <= currentTime)
            {
                SpawnUnit(spawnDatas.Dequeue(), out _);
            }
        }

        private UnitView SpawnUnit(SpawnData spawnData, out Unit newUnit)
        {
            var newUnitView = GameManager.UnitFactory.SpawnUnit(spawnData.team, spawnData.unitClass);
            var behaviours = spawnData.behaviours.Create();
            InitUnitPosition(spawnData, newUnitView);

            newUnit = new Unit();
            newUnit.Init(behaviours, GameManager, spawnData.team, spawnData.unitClass,
                newUnitView.transform.position.FromVectorXZ());

            newUnitView.Model = newUnit;

            GameManager.UnitViewManager.Add(newUnit, newUnitView);
            GameManager.UnitManager.AddUnit(newUnit);

            return newUnitView;
        }

        private void OnUnitRemoved(object caller, UnitManagerEvents.UnitRemovedEventData data)
        {
            var unitview = gameManager.UnitViewManager.GetUnitview(data.unit);
            GameManager.UnitFactory.DespawnUnitView(unitview);
            GameManager.UnitViewManager.Remove(data.unit);
        }

        private void InitUnitPosition(SpawnData spawnData, UnitView newUnit)
        {
            Transform spawnPoint;
            Transform enemySpawnPoint;
            switch (spawnData.team)
            {
                case Team.Ally:
                    spawnPoint = SpawnPositionData.SpawnOriginAlly;
                    enemySpawnPoint = SpawnPositionData.SpawnOriginEnemy;
                    break;
                case Team.Enemy:
                    spawnPoint = SpawnPositionData.SpawnOriginEnemy;
                    enemySpawnPoint = SpawnPositionData.SpawnOriginAlly;
                    break;

                default: throw new IndexOutOfRangeException();
            };

            newUnit.transform.parent = SpawnPositionData.UnitsParent;

            var offset2D = SpawnPositionData.SpawnSpan * UnityEngine.Random.Range(-1f, 1f);
            var localOffset = spawnPoint.rotation * offset2D.ToVectorXZ();
            var position = spawnPoint.position + localOffset;
            newUnit.transform.position = position;
            newUnit.transform.rotation = Quaternion.LookRotation(
                enemySpawnPoint.position - spawnPoint.position);
        }

        public void Populate(IReadOnlyList<SpawnData> spawnDatas)
        {
            this.spawnDatas.Clear();
            foreach(var spawnData in spawnDatas)
            {
                this.spawnDatas.Enqueue(spawnData);
            }

            currentTime = 0f;
        }
    }
}
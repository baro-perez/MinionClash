using UnityEngine;
using AlvaroPerez.MinionClash.Model;
using System.Collections.Generic;
using AlvaroPerez.MinionClash.Utils;
using AlvaroPerez.MinionClash.DataModel.Behaviours;
using System;
using System.Linq;
using AlvaroPerez.MinionClash.Ui.Menu.Model;
using AlvaroPerez.MinionClash.Ui.Menu;
using AlvaroPerez.MinionClash.Model.Units;
using AlvaroPerez.MinionClash.Model.Traps;

namespace AlvaroPerez.MinionClash.Main
{
    public class ClassicGameModeController : GameModeController
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private UnitSpawner unitSpawner;
        [SerializeField] private SpawnPositionData spawnPositionData;

        [Header("Spawnables")]
        [SerializeField] private BehaviourCollectionConfig[] availableBehaviours;

        [Header("Screens")]
        [SerializeField] private GameObject gameSetupMenu;
        [SerializeField] private GameObject ingameUi;
        [SerializeField] private ClassicGameModeVictoryScreenViewModel victoryScreen;

        private GameModel gameModel;
        private ClassicGameResultsModel resultsModel = new ClassicGameResultsModel();

        private List<IUnit> reusableUnitList = new List<IUnit>();
        private List<ITrap> reusableTrapList = new List<ITrap>();
        private void Awake()
        {
            GoBackToMenu();
        }

        public void GoBackToMenu()
        {
            SetScreenActive(gameSetupMenu);
        }

        private void SetScreenActive(GameObject screen)
        {
            gameSetupMenu.SetActive(screen == gameSetupMenu);
            ingameUi.SetActive(screen == ingameUi);
            victoryScreen.gameObject.SetActive(screen == victoryScreen.gameObject);
        }

        protected override void StartGameImpl()
        {
            gameManager.UnitManager.RemoveAllUnits();
            victoryScreen.Model = resultsModel;

            PopulateSpawner(gameManager);
            Unsubscribe(gameManager);

            SetScreenActive(ingameUi);
        }

        private void Unsubscribe(IModelManagers gameManager)
        {
            gameManager.UnitManager.OnUnitAdded += OnUnitAdded;
            gameManager.UnitManager.OnUnitRemoved += CheckWinCondition;
        }

        private void OnUnitAdded(object caller, UnitManagerEvents.UnitAddedEventData data)
        {
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (gameManager != null)
            {
                gameManager.UnitManager.OnUnitRemoved -= CheckWinCondition;
                gameManager.UnitManager.OnUnitAdded -= OnUnitAdded;
            }
        }

        private void PopulateSpawner(GameManager gameManager)
        {
            unitSpawner.SpawnPositionData = spawnPositionData;
            unitSpawner.GameManager = gameManager;

            var spawnDatas = new List<SpawnData>();

            AddSpawnDatas(spawnDatas, Team.Ally, gameModel.AllyTeam);
            AddSpawnDatas(spawnDatas, Team.Enemy, gameModel.EnemyTeam);
            spawnDatas.Sort((x, y) => x.time.CompareTo(y.time));

            unitSpawner.Populate(spawnDatas);
        }

        private void AddSpawnDatas(List<SpawnData> spawnDatas, Team team, TeamModel teamModel)
        {
            for (int i = 0; i < teamModel.NUnits; ++i)
            {
                var color = Util.GetWeightedRandEnum<UnitClass.Color>(
                    teamModel.ChanceRed, teamModel.ChanceGreen, teamModel.ChanceBlue);
                var shape = Util.GetWeightedRandEnum<UnitClass.Shape>(
                    teamModel.ChanceCube, teamModel.ChanceSphere);
                var size = Util.GetWeightedRandEnum<UnitClass.Size>(
                    teamModel.ChanceBig, teamModel.ChanceSmall);

                var unitClass = new UnitClass(size, shape, color);
                var behaviours = Util.RandomFromList(availableBehaviours);

                var time = UnityEngine.Random.Range(0, teamModel.SpawnSpan);

                var spawnData = new SpawnData(time, team, unitClass, behaviours);
                spawnDatas.Add(spawnData);
            }
        }

        protected override void TickImpl(float deltaTime)
        {
            unitSpawner.Tick(deltaTime);

            reusableUnitList.Clear();
            reusableUnitList.AddRange(gameManager.UnitManager.AllUnits);
            for (var i = 0; i < reusableUnitList.Count; i++)
            {
                var unit = reusableUnitList[i];
                unit.Tick(deltaTime);
            }

            reusableTrapList.Clear();
            reusableTrapList.AddRange(gameManager.TrapManager.Traps);
            for (var i = 0; i < reusableTrapList.Count; i++)
            {
                var trap = gameManager.TrapManager.Traps[i];
                trap.Tick(gameManager, deltaTime);
            }
        }

        private void CheckWinCondition(object caller, UnitManagerEvents.UnitRemovedEventData data)
        {
            if (unitSpawner.HasFinished && IsRunning)
            {
                var unitManager = gameManager.UnitManager;
                var allies = unitManager.GetTeam(Team.Ally);
                var enemies = unitManager.GetTeam(Team.Enemy);
                var nAllies = allies.Count;
                var nEnemies = enemies.Count;

                if (nAllies == 0)
                {
                    DeclareWinner(Team.Enemy);
                }
                else if (nEnemies == 0)
                {
                    DeclareWinner(Team.Ally);
                }
            }
        }

        private void DeclareWinner(Team team)
        {
            Debug.Log($"{team} wins");

            resultsModel.Winner = team;
            victoryScreen.RefreshAllBindings();
            SetScreenActive(victoryScreen.gameObject);

            IsRunning = false;
        }

        public void SetInputData(GameModel model)
        {
            this.gameModel = model;
        }
    }
}
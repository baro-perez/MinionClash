using UnityEngine;

using AlvaroPerez.MinionClash.UnitStats;
using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Traps;
using AlvaroPerez.MinionClash.Model.Units;
using AlvaroPerez.MinionClash.View.Units.Factory;

namespace AlvaroPerez.MinionClash.Main
{
    public class GameManager : MonoBehaviour, IModelManagers
    {
        [Header("Managers")]
        [SerializeField] private StatsFactory statsFactory = new StatsFactory();
        [SerializeField] private UnitViewFactory unitFactory = new UnitViewFactory();
        [SerializeField] private TrapViewManager trapViewManager = new TrapViewManager();

        [Header("Game mode")]
        [SerializeField] private GameModeController gameMode;

        private void Awake()
        {
            trapViewManager.GameManager = this;
        }

        // IModelManagers
        public IUnitManager UnitManager { get; } = new UnitManager();
        public IStatsFactory StatsFactory => statsFactory;
        public ITrapManager TrapManager { get; } = new TrapManager();

        // View-Related
        public UnitViewManager UnitViewManager { get; } = new UnitViewManager();
        public IUnitViewFactory UnitFactory => unitFactory;
        public TrapViewManager TrapViewManager => trapViewManager;

    }
}
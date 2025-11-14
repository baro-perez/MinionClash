using AlvaroPerez.MinionClash.Main;
using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Model.Units;
using AlvaroPerez.MinionClash.Utils.Ui.Mvvm;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Ui.Hud
{
    public class GameViewModel : ViewModel
    {
        [SerializeField] private GameManager gameManager;
        [TextArea]
        [SerializeField] private string unitCountFormat = 
            "<color=white>Whites: {0}</color>\n<color=black>Blacks {1}</color>";

        public string UnitCountText { get; private set; }

        protected override void PopulateBindings()
        {
            RegisterBinding(nameof(UnitCountText), () => UnitCountText, f => { });
        }

        private void Start()
        {
            Subscribe();
            UpdateViewModelState();
            RefreshAllBindings();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            gameManager.UnitManager.OnUnitAdded += OnUnitAdded;
            gameManager.UnitManager.OnUnitRemoved += OnUnitRemoved;
        }

        private void Unsubscribe()
        {
            gameManager.UnitManager.OnUnitAdded -= OnUnitAdded;
            gameManager.UnitManager.OnUnitRemoved -= OnUnitRemoved;
        }

        private void OnUnitAdded(object caller, UnitManagerEvents.UnitAddedEventData data)
        {
            UpdateUnitCountText();
            RefreshBinding(nameof(UnitCountText));
        }

        private void OnUnitRemoved(object caller, UnitManagerEvents.UnitRemovedEventData data)
        {
            UpdateUnitCountText();
            RefreshBinding(nameof(UnitCountText));
        }

        private void UpdateViewModelState()
        {
            UpdateUnitCountText();
        }

        private void UpdateUnitCountText()
        {
            var nWhites = gameManager.UnitManager.GetTeam(Team.Ally).Count;
            var nBlacks = gameManager.UnitManager.GetTeam(Team.Enemy).Count;
            UnitCountText = string.Format(unitCountFormat, nWhites, nBlacks);
        }
    }
}
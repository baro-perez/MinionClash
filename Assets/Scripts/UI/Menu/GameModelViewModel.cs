using AlvaroPerez.MinionClash.Main;
using AlvaroPerez.MinionClash.Ui.Menu.Model;
using AlvaroPerez.MinionClash.Utils.Ui.Mvvm;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Ui.Menu
{
    public class GameModelViewModel : ViewModel<GameModel>
    {
        [SerializeField] private ClassicGameModeController controller;

        public override GameModel Model { get; set; } = new GameModel();

        public TeamModel AllyTeam => Model.AllyTeam;
        public TeamModel EnemyTeam => Model.EnemyTeam;

        protected override void PopulateBindings()
        {
            RegisterBinding(nameof(Model), () => Model, v => { } );
            RegisterBinding(nameof(AllyTeam), () => AllyTeam, v => { });
            RegisterBinding(nameof(EnemyTeam), () => EnemyTeam, v => { });
        }

        public void StartGameWithModel()
        {
            controller.SetInputData(Model);
            controller.StartGame();
        }
    }
}
using AlvaroPerez.MinionClash.Main;
using AlvaroPerez.MinionClash.Ui.Menu.Model;
using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Utils.Ui.Mvvm;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Ui.Menu
{
    public class ClassicGameModeVictoryScreenViewModel : ViewModel<ClassicGameResultsModel>
    {
        [SerializeField] private ClassicGameModeController controller;
        public override ClassicGameResultsModel Model { get; set ; }

        public Team Winner => Model?.Winner ?? Team.None;

        public string WinnerName => Winner switch
        {
            Team.Ally => "White",
            Team.Enemy => "Black",
            _ => "Nobody",
        };

        private string WinnerColor => Winner switch
        {
            Team.Ally => "white",
            Team.Enemy => "black",
            _ => "",
        };

        public string WinnerText => $"<color={WinnerColor}>{WinnerName}\nwins</color>";


        protected override void PopulateBindings()
        {
            RegisterBinding(nameof(Winner), () => Winner, v => { });
            RegisterBinding(nameof(WinnerName), () => WinnerName, v => { } );
            RegisterBinding(nameof(WinnerText), () => WinnerText, v => { } );
        }

        public void GoBack()
        {
            controller.GoBackToMenu();
        }
    }
}
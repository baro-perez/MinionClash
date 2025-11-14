using AlvaroPerez.MinionClash.Ui.Menu.Model;
using AlvaroPerez.MinionClash.Utils.Ui.Mvvm;

namespace AlvaroPerez.MinionClash.Ui.Menu
{
    public class TeamViewModel : ViewModel<TeamModel>
    {
        public override TeamModel Model { get; set; }

        public int NUnits{ get => Model.NUnits; set => Model.NUnits = value; }
        public float SpawnSpan { get => Model.SpawnSpan; set => Model.SpawnSpan = value; }

        public float ChanceBig { get => Model.ChanceBig; set => Model.ChanceBig = value; }
        public float ChanceSmall { get => Model.ChanceSmall; set => Model.ChanceSmall = value; }

        public float ChanceCube { get => Model.ChanceCube; set => Model.ChanceCube = value; }
        public float ChanceSphere { get => Model.ChanceSphere; set => Model.ChanceSphere = value; }

        public float ChanceRed { get => Model.ChanceRed; set => Model.ChanceRed = value; }
        public float ChanceGreen { get => Model.ChanceGreen; set => Model.ChanceGreen = value; }
        public float ChanceBlue { get => Model.ChanceBlue; set => Model.ChanceBlue = value; }

        protected override void PopulateBindings()
        {
            RegisterBinding(nameof(NUnits), () => NUnits, v => NUnits = v);
            RegisterBinding(nameof(SpawnSpan), () => SpawnSpan, v => SpawnSpan = v);
            RegisterBinding(nameof(ChanceBig), () => ChanceBig, v => ChanceBig = v);
            RegisterBinding(nameof(ChanceSmall), () => ChanceSmall, v => ChanceSmall = v);
            RegisterBinding(nameof(ChanceCube), () => ChanceCube, v => ChanceCube = v);
            RegisterBinding(nameof(ChanceSphere), () => ChanceSphere, v => ChanceSphere = v);
            RegisterBinding(nameof(ChanceRed), () => ChanceRed, v => ChanceRed = v);
            RegisterBinding(nameof(ChanceGreen), () => ChanceGreen, v => ChanceGreen = v);
            RegisterBinding(nameof(ChanceBlue), () => ChanceBlue, v => ChanceBlue = v);
        }
    }
}
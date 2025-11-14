namespace AlvaroPerez.MinionClash.Ui.Menu.Model
{
    public class TeamModel
    {
        public int NUnits { get; set; } = 20;
        public float SpawnSpan { get; set; } = 10f;

        public float ChanceBig { get; set; } = 1f;
        public float ChanceSmall { get; set; } = 1f;

        public float ChanceCube { get; set; } = 1f;
        public float ChanceSphere { get; set; } = 1f;

        public float ChanceRed { get; set; } = 1f;
        public float ChanceGreen { get; set; } = 1f;
        public float ChanceBlue { get; set; } = 1f;
    }
}
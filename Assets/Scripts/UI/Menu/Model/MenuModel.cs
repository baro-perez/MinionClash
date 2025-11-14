namespace AlvaroPerez.MinionClash.Ui.Menu.Model
{
    public class GameModel
    {
        public TeamModel AllyTeam { get; set; } = new TeamModel();
        public TeamModel EnemyTeam { get; set; } = new TeamModel();
    }
}
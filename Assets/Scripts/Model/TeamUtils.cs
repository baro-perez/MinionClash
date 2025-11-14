namespace AlvaroPerez.MinionClash.Model
{
    public static class TeamUtils
    {
        public static Team Opposite(this Team team)
        {
            return team switch
            {
                Team.Ally => Team.Enemy,
                Team.Enemy =>  Team.Ally,
                Team.None => Team.None,
                _ => throw new System.IndexOutOfRangeException(),
            };
        }
    }
}

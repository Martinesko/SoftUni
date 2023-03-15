using P02_FootballBetting.Data;

namespace Football_Betting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
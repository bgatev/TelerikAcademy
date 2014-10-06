namespace TicTacToe.Data
{
    using TicTacToe.Data.Repositories;
    using TicTacToe.Models;

    public interface ITicTacToeData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<HighScore> HighScores { get; }

        int SaveChanges();
    }
}

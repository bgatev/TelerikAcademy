namespace App.Data
{
    using App.Data.Repositories;
    using App.Models;

    public interface IAppData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}

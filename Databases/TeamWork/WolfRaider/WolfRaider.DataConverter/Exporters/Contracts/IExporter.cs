namespace WolfRaider.DataConverter.Exporters.Contracts
{
    using WolfRaider.Common.Models;

    public interface IExporter<T>
    {
        T ConvertEmployee(Employee employee);

        T ConvertOccupation(Occupation occupation);

        T ConvertNationality(Nationality nationality);

        T ConvertPosition(Position position);

        T ConvertGame(Game game);

        T ConvertSquadHistory(SquadHistory squadHistory);

        T ConvertTeam(Team team);

        T ConvertWorkHistory(WorkHistory workHistory);
    }
}

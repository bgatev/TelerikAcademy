namespace WolfRaider.DataConverter.Importers.Contracts
{
    using WolfRaider.Common.Models;

    public interface IImporter<T>
    {
        Employee ConvertToEmployee(T data);

        Occupation ConvertToOccupation(T data);

        Nationality ConvertToNationality(T data);

        Position ConvertToPosition(T data);

        Game ConvertToGame(T data);

        SquadHistory ConvertToSquadHistory(T data);

        Team ConvertToTeam(T data);

        WorkHistory ConvertToWorkHistory(T data);
    }
}

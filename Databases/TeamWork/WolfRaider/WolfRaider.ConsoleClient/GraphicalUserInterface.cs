using System.Text;
using WolfRaider.Application.Contracts;

namespace WolfRaider.ConsoleClient
{
    public class GraphicalUserInterface
    {
        private readonly IMotherBoard motherBoard;
        private readonly IPrinter printer;

        public GraphicalUserInterface(IMotherBoard motherBoard)
        {
            this.motherBoard = motherBoard;
        }

        public void Start()
        {
           this.motherBoard.GenerateApplicationFolders();


        }

        private void ShowIntroScreen()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Wolf Raider SQL Tool");
            stringBuilder.AppendLine("Select a task:");
            stringBuilder.AppendLine("1. ");
            stringBuilder.AppendLine("2. ");

           
        }
    }
}
